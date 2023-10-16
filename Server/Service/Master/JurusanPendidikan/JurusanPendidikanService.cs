using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.JurusanPendidikanService
{
    public class JurusanPendidikanService : IJurusanPendidikanService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public JurusanPendidikanService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<JurusanPendidikan>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.JurusanPendidikan.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<JurusanPendidikan>.ShowDataAsync(
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

        public async Task<JurusanPendidikan> Post(CreateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JurusanPendidikan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new JurusanPendidikan()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.JurusanPendidikan.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JurusanPendidikan> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.JurusanPendidikan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }

                var roleData = await _AppDbContext.JurusanPendidikan.FindAsync(id) ?? throw new("Opss Id not found");
                roleData.Name = items.Name;

                _AppDbContext.JurusanPendidikan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<JurusanPendidikan> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.JurusanPendidikan.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.JurusanPendidikan.Update(roleData);
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