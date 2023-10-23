using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.StatusService
{
    public class StatusService : IStatusService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public StatusService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<Status>> Get(SieveModel model)
        {
            try
            {
                var Status = _AppDbContext.Status.Where(d => d.IsActive == true).AsQueryable();
                var result = _SieveProcessor.Apply(model, Status);
                var StatusList = await PageList<Status>.ShowDataAsync(
                    Status,
                    result,
                    model.Page,
                    model.PageSize
                );
                return StatusList;
            }

            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> GetId(int Id)
        {
            try
            {
                var checkData = await _AppDbContext.Status.FirstOrDefaultAsync(x => x.Id == Id);
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
                var checkData = await _AppDbContext.Status.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new Status()
                {
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Status.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return new { code = 200, message = "Data berhasil ditambahkan", data = roleData };
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Put(int id, UpdateDto items)
        {
            try
            {
                var roleData = await _AppDbContext.Status.FindAsync(id) ?? throw new CustomException(400, "Data tidak ditemukan"); ;
                var checkData = await _AppDbContext.Status.FirstOrDefaultAsync(x => x.Name == items.Name & roleData.Name != items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Nama tersedia, silahkan update nama lain");
                }
                roleData.Name = items.Name == roleData.Name ? roleData.Name : items.Name;
                roleData.UpdatedAt = DateTime.Now;
                _AppDbContext.Status.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return new { code = 201, message = "Data berhasil diperbarui", data = roleData };
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Delete(int id)
        {
            try
            {
                var roleData = await _AppDbContext.Status.FindAsync(id);
                if (roleData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                roleData.IsActive = false;
                _AppDbContext.Status.Update(roleData);
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