using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.JenisMppService
{
    public class JenisMppService : IJenisMppService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public JenisMppService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<JenisMpp>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.JenisMpp.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<JenisMpp>.ShowDataAsync(
                    departemen,
                    result,
                    model.Page,
                    model.PageSize
                );
                return departemenList;
            }

            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JenisMpp> Post(CreateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JenisMpp.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new JenisMpp()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.JenisMpp.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JenisMpp> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JenisMpp.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = await _AppDbContext.JenisMpp.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;

                _AppDbContext.JenisMpp.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JenisMpp> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.JenisMpp.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.JenisMpp.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}