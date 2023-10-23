using man_power_planning.Server.Data;
using man_power_planning.Shared.Helper;
using man_power_planning.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.PendidikanService
{
    public class PendidikanService : IPendidikanService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public PendidikanService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<Pendidikan>> Get(SieveModel model)
        {
            try
            {
                var Pendidikan = _AppDbContext.Pendidikan.Where(d => d.IsActive == true).AsQueryable();
                var result = _SieveProcessor.Apply(model, Pendidikan);
                var PendidikanList = await PageList<Pendidikan>.ShowDataAsync(
                    Pendidikan,
                    result,
                    model.Page,
                    model.PageSize
                );
                return PendidikanList;
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
                var checkData = await _AppDbContext.Pendidikan.FirstOrDefaultAsync(x => x.Id == Id);
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
                var checkData = await _AppDbContext.Pendidikan.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new Pendidikan()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Pendidikan.Add(roleData);
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
                var roleData = await _AppDbContext.Pendidikan.FindAsync(id) ?? throw new CustomException(400, "Data tidak ditemukan"); ;
                var checkData = await _AppDbContext.Pendidikan.FirstOrDefaultAsync(x => x.Name == items.Name & roleData.Name != items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Nama tersedia, silahkan update nama lain");
                }
                roleData.Name = items.Name == roleData.Name ? roleData.Name : items.Name;
                roleData.UpdatedAt = DateTime.Now;
                _AppDbContext.Pendidikan.Update(roleData);
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
                var roleData = await _AppDbContext.Pendidikan.FindAsync(id);
                if (roleData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                roleData.IsActive = false;
                _AppDbContext.Pendidikan.Update(roleData);
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