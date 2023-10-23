using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly string key;
        private readonly ILogger<AuthService> _logger;

        public AuthService(AppDbContext dbContext, SieveProcessor sieveProcessor, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
            _configuration = configuration;
            _logger = logger;
            this.key = configuration.GetSection("AppSettings")["JwtKey"];
        }

        private string CreateJWT(LoginDto? user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keys = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID), // NOTE: this will be the "User.Identity.Name" value
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserID),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keys), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "manpower.com",
                Audience = "manpower.com",
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Object> LoginAsync([FromBody] LoginDto login)
        {
            string token = CreateJWT(login);
            var httpClient = new HttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "UserID", login.UserID },
                { "Password", login.Password },
                { "ApplicationID", "LunchApp" },
            };
            var content = new FormUrlEncodedContent(parameters);
            try
            {
                var response = await httpClient.PostAsync(_configuration.GetSection("UmsUrlLogin").Value, content);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent.Contains("Your account is invalid !"))
                {
                    throw new CustomException(400, "Your account is invalid !");
                }
                if (responseContent.Contains("Your account is invalid or please check your User ID and Password again !"))
                {
                    throw new CustomException(400, "Your account is invalid or please check your User ID and Password again !");
                }
                Users userResponse = JsonConvert.DeserializeObject<Users>(responseContent);
                var checkData = await _AppDbContext.Users.FirstOrDefaultAsync(x => x.UserID == userResponse.UserID);
                if (checkData == null)
                {
                    var roleData = new Users()
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
                    return new { Data = roleData, accessToken = token };
                }
                return new { code = 200, Data = userResponse, accessToken = token };
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                throw;
            }
        }

        public async Task<PageList<Users>> Get(SieveModel model)
        {
            try
            {
                var Auth = _AppDbContext.Users.AsQueryable();
                var result = _SieveProcessor.Apply(model, Auth);
                var AuthList = await PageList<Users>.ShowDataAsync(
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

        public async Task<Users> Post(LoginDto items)
        {
            try
            {
                var checkData = await _AppDbContext.Users.FirstOrDefaultAsync(x => x.UserID == items.UserID);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new Users()
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

        public async Task<Users> Put(Guid id, LoginDto items)
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

        public async Task<Users> Delete(Guid id)
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

        Task<PageList<Users>> IAuthService.Get(SieveModel model)
        {
            throw new NotImplementedException();
        }
    }
}