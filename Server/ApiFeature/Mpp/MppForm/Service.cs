using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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
                await _AppDbContext.Lokasi.Where(x => x.IsActive == true).OrderBy(x => x.CreatedAt).ToListAsync();
                await _AppDbContext.Divisi.Where(x => x.IsActive == true).OrderBy(x => x.CreatedAt).ToListAsync();
                await _AppDbContext.JenisMpp.Where(x => x.IsActive == true).OrderBy(x => x.CreatedAt).ToListAsync();
                await _AppDbContext.Status.Where(x => x.IsActive == true).OrderBy(x => x.CreatedAt).ToListAsync();
                await _AppDbContext.MppChildForm.Where(x => x.IsActive == true).OrderBy(x => x.CreatedAt).ToListAsync();
                await _AppDbContext.Users.OrderBy(x => x.CreatedAt).ToListAsync();
                // var departemen = _AppDbContext.MppForm.Where(d => (bool)d.IsActive).AsQueryable();
                var departemen = _AppDbContext.MppForm.AsQueryable();
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

        public async Task<Guid> Post(Users userId, string jenis)
        {
            try
            {
                var roleData = new MppForm()
                {
                    Id = Guid.NewGuid(),
                    NoMpp = null,
                    NrpPemohon = null,
                    NamaPemohon = null,
                    UserId = userId.UserID,
                    KategoriLokasiId = null,
                    DivisiId = null,
                    JenisMppId = null,
                    StatusId = null,
                    TahunMpp = null,
                    IsApprovalADH = false,
                    IsApprovalHCBP = false,
                    IsApprovalBM = false,
                    IsApprovalDivHead = false,
                    IsApprovalPICA1B1 = false,
                    IsApprovalOPCC = false,
                    IsApprovalGMHC = false,
                    IsApprovalDirectorHC = false,
                    IsActive = false,
                    IsDraft = false,
                    CreatedAt = DateTime.Now,
                    JenisPengajuan = jenis,
                };
                _AppDbContext.MppForm.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData.Id;
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
                var checkLokasi = await _AppDbContext.Lokasi.FirstOrDefaultAsync(x => x.Id == items.KategoriLokasiId) ?? throw new("Lokasi form Id tidak ditemukan");
                var checkDivisi = await _AppDbContext.Divisi.FirstOrDefaultAsync(x => x.Id == items.DevisiId) ?? throw new("Divisi form Id tidak ditemukan");
                var checkJenisMpp = await _AppDbContext.JenisMpp.FirstOrDefaultAsync(x => x.Id == items.JenisMppId) ?? throw new("JenisMpp form Id tidak ditemukan");
                var checkStatus = await _AppDbContext.Status.FirstOrDefaultAsync(x => x.Id == items.StatusId) ?? throw new("Status form Id tidak ditemukan");
                var roleData = await _AppDbContext.MppForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.NoMpp = items.NoMpp;
                roleData.NrpPemohon = items.NrpPemohon;
                roleData.NamaPemohon = items.NamaPemohon;
                roleData.KategoriLokasiId = items.KategoriLokasiId;
                roleData.DivisiId = items.DevisiId;
                roleData.JenisMppId = items.JenisMppId;
                roleData.StatusId = items.StatusId;
                roleData.TahunMpp = items.TahunMpp;
                roleData.IsApprovalADH = items.IsApprovalADH;
                roleData.IsApprovalHCBP = items.IsApprovalHCBP;
                roleData.IsApprovalBM = items.IsApprovalBM;
                roleData.IsApprovalDivHead = items.IsApprovalDivHead;
                roleData.IsApprovalPICA1B1 = items.IsApprovalPICA1B1;
                roleData.IsApprovalOPCC = items.IsApprovalOPCC;
                roleData.IsApprovalGMHC = items.IsApprovalGMHC;
                roleData.IsApprovalDirectorHC = items.IsApprovalDirectorHC;
                roleData.IsActive = items.IsActive;
                roleData.IsDraft = items.IsDraft;
                _AppDbContext.MppForm.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<MppForm> PutApproval(Guid id, Users items)
        {
            try
            {
                var roleData = await _AppDbContext.MppForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                if (items.Division == "HCBP")
                {
                    roleData.IsApprovalHCBP = true;
                }
                if (items.Division == "ADH")
                {
                    roleData.IsApprovalADH = true;
                }
                if (items.Division == "BM")
                {
                    roleData.IsApprovalBM = true;
                }
                if (items.Division == "HEAD")
                {
                    roleData.IsApprovalDivHead = true;
                }
                if (items.Division == "PIC")
                {
                    roleData.IsApprovalPICA1B1 = true;
                }
                if (items.Division == "OPCC")
                {
                    roleData.IsApprovalOPCC = true;
                }
                if (items.Division == "GMHC")
                {
                    roleData.IsApprovalGMHC = true;
                }
                if (items.Division == "DIRHC")
                {
                    roleData.IsApprovalDirectorHC = true;
                }
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