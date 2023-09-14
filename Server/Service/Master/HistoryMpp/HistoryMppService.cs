using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
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

        public async Task<List<HistoryMpp>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.HistoryMpp.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<HistoryMpp>.ShowDataAsync(
                    departemen,
                    result,
                    model.Page,
                    model.PageSize
                );
                return await departemenList.Items.ToListAsync();
            }

            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<HistoryMpp> Post(CreateHistoryMpp items)
        {
            try
            {
                var roleData = new HistoryMpp()
                {
                    Id = Guid.NewGuid(),
                    Notes = items.Notes,
                    UserId = items.UserId,
                    MppId = items.MppId,

                    IsActive = items.IsActive,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.HistoryMpp.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<HistoryMpp> Put(Guid id, CreateHistoryMpp items)
        {
            try
            {
                var roleData = await _AppDbContext.HistoryMpp.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Notes = items.Notes;
                roleData.IsActive = items.IsActive;
                _AppDbContext.HistoryMpp.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<HistoryMpp> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.HistoryMpp.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.HistoryMpp.Update(roleData);
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