using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.DepartemenService
{
    public class DepartemenService : IDepartemenService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public DepartemenService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<Departemen>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.Departemen.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<Departemen>.ShowDataAsync(
                    departemen,
                    result,
                    model.Page,
                    model.PageSize
                );
                return departemenList;
            }

            catch (CustomException ex)
            {
                throw;
            }
        }

        public async Task<Object> GetId(Guid Id)
        {
            try
            {
                var checkData = await _AppDbContext.Departemen.FirstOrDefaultAsync(x => x.Id == Id);
                if (checkData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                return new { Data = checkData, Code = 200 }; ;
            }
            catch (CustomException ex)
            {
                throw;
            }
        }

        public async Task<Object> Post(CreateDevisiInput items)
        {
            try
            {
                var checkData = await _AppDbContext.Departemen.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new("Data sudah tersedia, silahkan input nama lain");
                }
                var roleData = new Departemen()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.Departemen.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (CustomException ex)
            {
                throw;
            }
        }

        public async Task<Object> Put(Guid id, UpdateDevisiInput items)
        {
            try
            {
                var roleData = await _AppDbContext.Departemen.FindAsync(id) ?? throw new CustomException(400, "Data tidak ditemukan"); ;
                var checkData = await _AppDbContext.Departemen.FirstOrDefaultAsync(x => x.Name == items.Name);
                if (checkData != null)
                {
                    throw new CustomException(400, "Nama tersedia, silahkan update nama lain");
                }
                roleData.Name = items.Name;
                _AppDbContext.Departemen.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (CustomException ex)
            {
                throw;
            }
        }

        public async Task<Object> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.Departemen.FindAsync(id);
                if (roleData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                roleData.IsActive = false;
                _AppDbContext.Departemen.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (CustomException ex)
            {
                throw;
            }
        }
    }
}