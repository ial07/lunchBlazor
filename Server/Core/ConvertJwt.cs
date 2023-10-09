using System.IdentityModel.Tokens.Jwt;
using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class ConvertJWT
{
    private readonly AppDbContext _AppDbContext;
    public ConvertJWT(AppDbContext dbContext)
    {
        _AppDbContext = dbContext;
    }
    public async Task<Users> ConvertString(string accessToken)
    {
        var tokenAccess = accessToken.Substring("Bearer ".Length);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenAccess);
        string idUser = token.Subject;
        var User = await _AppDbContext.Users.FirstOrDefaultAsync(d => d.UserID == idUser);
        return User;
    }
}