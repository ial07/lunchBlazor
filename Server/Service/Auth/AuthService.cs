using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext dbContext, SieveProcessor sieveProcessor, IConfiguration configuration)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
            _configuration = configuration;
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

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Object> LoginAsync([FromBody] UserForm login)
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
            var checkData = await _AppDbContext.Users.FirstOrDefaultAsync(x => x.UserID == userResponse.UserID);
            if (checkData == null)
            {
                var roleData = new User()
                {
                    UserID = userResponse.UserID,
                    UserName = userResponse.UserName,
                    Department = userResponse.Department,
                    Division = userResponse.Division,
                    Location = userResponse.Location,
                    IsAdmin = false,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                _AppDbContext.Users.Add(userResponse);
                await _AppDbContext.SaveChangesAsync();
                return new { Data = roleData, accessToken = token }; ;
            }
            // Return an HTTP response with the token content in JSON format
            return new { Data = userResponse, accessToken = token };
        }

        public async Task<PageList<User>> Get(SieveModel model)
        {
            try
            {
                var Auth = _AppDbContext.Users.AsQueryable();
                var result = _SieveProcessor.Apply(model, Auth);
                var AuthList = await PageList<User>.ShowDataAsync(
                    Auth,
                    result,
                    model.Page,
                    model.PageSize
                );
                return AuthList;
            }

            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<User> Post(UserForm items)
        {
            try
            {
                var checkData = await _AppDbContext.Users.FirstOrDefaultAsync(x => x.UserID == items.UserID);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new User()
                {
                    UserID = items.UserID,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Users.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<User> Put(Guid id, UserForm items)
        {
            try
            {
                var checkData = await _AppDbContext.Users.FirstOrDefaultAsync(x => x.UserID == items.UserID);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = await _AppDbContext.Users.FindAsync(id) ?? throw new("Opss Id not found");
                roleData.UserID = items.UserID;

                _AppDbContext.Users.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<User> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.Users.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.Users.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        Task<PageList<User>> IAuthService.Get(SieveModel model)
        {
            throw new NotImplementedException();
        }
    }
}