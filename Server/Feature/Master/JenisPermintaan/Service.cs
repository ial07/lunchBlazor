using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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
                var JenisPermintaan = _AppDbContext.JenisPermintaan.Where(d => d.IsActive == true).AsQueryable();
                var result = _SieveProcessor.Apply(model, JenisPermintaan);
                var JenisPermintaanList = await PageList<JenisPermintaan>.ShowDataAsync(
                    JenisPermintaan,
                    result,
                    model.Page,
                    model.PageSize
                );
                return JenisPermintaanList;
            }

            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> GetId(Guid Id)
        {
            try
            {
                var checkData = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Id == Id);
                if (checkData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                return new { Data = checkData, Code = 200 }; ;
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Post(CreateDto items)
        {
            try
            {
                var checkData = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Data sudah tersedia, silahkan input nama lain");
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
                return new { code = 200, message = "Data berhasil ditambahkan", data = roleData };
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Put(Guid id, UpdateDto items)
        {
            try
            {
                var roleData = await _AppDbContext.JenisPermintaan.FindAsync(id) ?? throw new CustomException(400, "Data tidak ditemukan"); ;
                var checkData = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Name == items.Name & roleData.Name != items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Nama tersedia, silahkan update nama lain");
                }
                roleData.Name = items.Name == roleData.Name ? roleData.Name : items.Name;
                roleData.UpdatedAt = DateTime.Now;
                _AppDbContext.JenisPermintaan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return new { code = 201, message = "Data berhasil diperbarui", data = roleData };
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.JenisPermintaan.FindAsync(id);
                if (roleData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                roleData.IsActive = false;
                _AppDbContext.JenisPermintaan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return new { code = 201, message = "Data berhasil dihapus", data = roleData }; ; ;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}