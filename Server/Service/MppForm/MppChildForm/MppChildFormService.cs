using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace RepositoryPattern.Services.MppChildFormService
{
    public class MppChildFormService : IMppChildFormService
    {
        private readonly AppDbContext _AppDbContext;
        private readonly SieveProcessor _SieveProcessor;

        public MppChildFormService(AppDbContext dbContext, SieveProcessor sieveProcessor)
        {
            _AppDbContext = dbContext;
            _SieveProcessor = sieveProcessor;
        }

        public async Task<PageList<MppChildForm>> Get(SieveModel model)
        {
            try
            {
                var departemen = _AppDbContext.MppChildForm.Where(d => (bool)d.IsActive).AsQueryable();
                var result = _SieveProcessor.Apply(model, departemen);
                var departemenList = await PageList<MppChildForm>.ShowDataAsync(
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

        public async Task<MppChildForm> Post(CreateMppChild items)
        {
            try
            {
                var checkMpp = await _AppDbContext.MppForm.FirstOrDefaultAsync(x => x.Id == items.MppFormId) ?? throw new("Mpp form Id tidak ditemukan");
                var checkPosisi = await _AppDbContext.Posisi.FirstOrDefaultAsync(x => x.Id == items.PosisiId) ?? throw new("Posisi Id tidak ditemukan");
                var checkGolongan = await _AppDbContext.Golongan.FirstOrDefaultAsync(x => x.Id == items.GolonganId) ?? throw new("Golongan Id tidak ditemukan");
                var checkDivisi = await _AppDbContext.Divisi.FirstOrDefaultAsync(x => x.Id == items.DevisiTujuanId) ?? throw new("Divisi Id tidak ditemukan");
                var checkDepartemen = await _AppDbContext.Departemen.FirstOrDefaultAsync(x => x.Id == items.DepartemenId) ?? throw new("Departemen Id tidak ditemukan");
                var checkLokasi = await _AppDbContext.Lokasi.FirstOrDefaultAsync(x => x.Id == items.LokasiId) ?? throw new("Lokasi Id tidak ditemukan");
                var checkJenisPermintaan = await _AppDbContext.JenisPermintaan.FirstOrDefaultAsync(x => x.Id == items.JenisPermintaanId) ?? throw new("JenisPermintaan Id tidak ditemukan");
                var checkSumberPemenuhan = await _AppDbContext.SumberPemenuhan.FirstOrDefaultAsync(x => x.Id == items.SumberPemenuhanId) ?? throw new("SumberPemenuhan Id tidak ditemukan");
                var checkPendidikan = await _AppDbContext.Pendidikan.FirstOrDefaultAsync(x => x.Id == items.PendidikanId) ?? throw new("Pendidikan Id tidak ditemukan");
                var checkJurusanPendidikan = await _AppDbContext.JurusanPendidikan.FirstOrDefaultAsync(x => x.Id == items.JurusanPendidikanId) ?? throw new("JurusanPendidikan Id tidak ditemukan");

                var roleData = new MppChildForm()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _AppDbContext.MppChildForm.Add(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<MppChildForm> Put(Guid id, CreateMppChild items)
        {
            try
            {
                var roleData = await _AppDbContext.MppChildForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.IsActive = items.IsActive;

                _AppDbContext.MppChildForm.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return roleData;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<MppChildForm> Delete(Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.MppChildForm.FindAsync(id);
                if (roleData == null)
                {
                    throw new("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.MppChildForm.Update(roleData);
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