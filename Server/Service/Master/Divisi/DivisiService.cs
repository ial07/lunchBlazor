using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.DivisiService
{
    public class DivisiService : IDivisiService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public DivisiService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<Divisi>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.Divisi.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<Divisi>.ShowDataAsync(
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

        public async Task<Divisi> Post(CreateDevisiInput items)
        {
            try
            {
                var roleData = new Divisi()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = items.IsActive,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Divisi.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<Divisi> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var roleData = await _AppDbContext.Divisi.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.IsActive = items.IsActive;

                _AppDbContext.Divisi.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<Divisi> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.Divisi.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.Divisi.Update(roleData);
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