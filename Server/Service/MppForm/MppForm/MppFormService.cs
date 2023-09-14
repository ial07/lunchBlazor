using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.MppFormService
{
    public class MppFormService : IMppFormService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public MppFormService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<MppForm>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.MppForm.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<MppForm>.ShowDataAsync(
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

        public async Task<MppForm> Post(CreateMpp items)
        {
            try
            {
                var roleData = new MppForm()
                {
                    Id = Guid.NewGuid(),
                    NoMpp = items.NoMpp,
                    NrpPemohon = items.NrpPemohon,
                    NamaPemohon = items.NamaPemohon,
                    KategoriLokasiId = items.KategoriLokasiId,
                    DevisiId = items.DevisiId,
                    JenisMppId = items.JenisMppId,
                    StatusId = items.StatusId,
                    TahunMpp = items.TahunMpp,
                    IsApprovalADH = items.IsApprovalADH,
                    IsApprovalHCBP = items.IsApprovalHCBP,
                    IsApprovalBM = false,
                    IsApprovalDivHead = false,
                    IsApprovalPICA1B1 = false,
                    IsApprovalOPCC = false,
                    IsApprovalGMHC = false,
                    IsApprovalDirectorHC = false,
                    IsActive = items.IsActive,
                    IsDraft = items.IsDraft,
                    CreatedAt = DateTime.Now,
                };
                _AppDbContext.MppForm.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<MppForm> Put(Guid id, UpdateMpp items)
        {
            try
            {
                var roleData = await _AppDbContext.MppForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.IsActive = items.IsActive;

                _AppDbContext.MppForm.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<MppForm> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.MppForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.MppForm.Update(roleData);
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