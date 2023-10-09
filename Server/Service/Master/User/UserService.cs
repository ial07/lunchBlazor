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

namespace RepositoryPattern.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public UserService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<User>> Get(SieveModel model)
        {
            try
            {
                var User = _AppDbContext.Users.AsQueryable();
                var result = _SieveProcessor.Apply(model, User);
                var UserList = await PageList<User>.ShowDataAsync(
                    User,
                    result,
                    model.Page,
                    model.PageSize
                );
                return UserList;
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

        Task<PageList<User>> IUserService.Get(SieveModel model)
        {
            throw new NotImplementedException();
        }
    }
}