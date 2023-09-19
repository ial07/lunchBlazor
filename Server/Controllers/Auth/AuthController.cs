using lunchBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using lunchBlazor.Shared.Models;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _AppDbContext;

        public AuthController(ILogger<AuthController> logger, AppDbContext AppDbContext, IConfiguration configuration)
        {
            _logger = logger;
            _AppDbContext = AppDbContext;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserForm login)
        {
            string token = CreateJWT(login);
            // Create an instance of HttpClient to make the HTTP request
            var httpClient = new HttpClient();

            // Define the login parameters to send in the request
            var parameters = new Dictionary<string, string>
            {
                { "UserID", login.UserID },
                { "Password", login.Password },
                { "ApplicationID", "LunchApp" },
            };

            // Create the request content with the parameters
            var content = new FormUrlEncodedContent(parameters);

            // Send a POST request to the authentication service
            var response = await httpClient.PostAsync(_configuration.GetSection("UmsUrlLogin").Value, content);

            // Read the response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();
            User userResponse = JsonConvert.DeserializeObject<User>(responseContent);
            // Return an HTTP response with the token content in JSON format
            return Ok(new { Data = userResponse, accessToken = token });
        }

        private string CreateJWT(UserForm? user)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Mx0K7BAwAk+YXsKErRDtbTAeEpZEdHcSeKO15Snw/RaKd+Dnfb3XfX60F4AQHaG1")); // NOTE: SAME KEY AS USED IN Program.cs FILE
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, user.UserID), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.UserID),
                new Claim(JwtRegisteredClaimNames.Email, user.UserID),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserID) // NOTE: this could a unique ID assigned to the user by a database
			};

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public class UserForm
        {
            public string? UserID { get; set; }
            public string? Password { get; set; }
        }
    }

}