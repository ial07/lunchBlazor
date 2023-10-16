using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.JenisPermintaanService
{
    public class JenisPermintaanService : IJenisPermintaanService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public JenisPermintaanService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<JenisPermintaan>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.JenisPermintaan.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<JenisPermintaan>.ShowDataAsync(
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

        public async Task<JenisPermintaan> Post(CreateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new JenisPermintaan()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.JenisPermintaan.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JenisPermintaan> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = await _AppDbContext.JenisPermintaan.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;

                _AppDbContext.JenisPermintaan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JenisPermintaan> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.JenisPermintaan.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.JenisPermintaan.Update(roleData);
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