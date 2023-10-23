using man_power_planning.Server.Data;
using man_power_planning.Shared.Helper;
using man_power_planning.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.HistoryMppService
{
    public class HistoryMppService : IHistoryMppService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public HistoryMppService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<HistoryMpp>> Get(SieveModel model)
        {
            try
            {
                var HistoryMpp = _AppDbContext.HistoryMpp.Where(d => d.IsActive == true).AsQueryable();
                var result = _SieveProcessor.Apply(model, HistoryMpp);
                var HistoryMppList = await PageList<HistoryMpp>.ShowDataAsync(
                    HistoryMpp,
                    result,
                    model.Page,
                    model.PageSize
                );
                return HistoryMppList;
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
                var checkData = await _AppDbContext.HistoryMpp.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<Object> Post(CreateHistoryMpp items)
        {
            try
            {
                var roleData = new HistoryMpp()
                {
                    Id = Guid.NewGuid(),
                    Notes = items.Notes,
                    UserId = items.UserId,
                    MppId = items.MppId,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.HistoryMpp.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return new { code = 200, message = "Data berhasil ditambahkan", data = roleData };
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<Object> Put(Guid id, CreateHistoryMpp items)
        {
            try
            {
                var roleData = await _AppDbContext.HistoryMpp.FindAsync(id) ?? throw new CustomException(400, "Data tidak ditemukan"); ;
                roleData.Notes = items.Notes;
                roleData.UpdatedAt = DateTime.Now;
                _AppDbContext.HistoryMpp.Update(roleData);
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
                var roleData = await _AppDbContext.HistoryMpp.FindAsync(id);
                if (roleData == null)
                {
                    throw new CustomException(400, "Data tidak ditemukan");
                }
                roleData.IsActive = false;
                _AppDbContext.HistoryMpp.Update(roleData);
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