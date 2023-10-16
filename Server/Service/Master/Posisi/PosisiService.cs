using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.PosisiService
{
    public class PosisiService : IPosisiService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public PosisiService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<Posisi>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.Posisi.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<Posisi>.ShowDataAsync(
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

        public async Task<Posisi> Post(CreateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.Posisi.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new Posisi()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Posisi.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<Posisi> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.Posisi.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = await _AppDbContext.Posisi.FindAsync(id) ?? throw new("Opss Id not found");
                roleData.Name = items.Name;

                _AppDbContext.Posisi.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<Posisi> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.Posisi.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.Posisi.Update(roleData);
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