using lunchBlazor.Server.Data;
using lunchBlazor.Shared.Helper;
using lunchBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace test_blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GolonganController : ControllerBase
    {
        private readonly SieveProcessor _SieveProcessor;
        private readonly AppDbContext _AppDbContext;
        public GolonganController(SieveProcessor sieveProcessor, AppDbContext AppDbContext)
        {
            _SieveProcessor = sieveProcessor;
            _AppDbContext = AppDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Golongan>>> GetDevisis([FromQuery] SieveModel model)
        {

            var Devisi = _AppDbContext.Golongan.Where(d => (bool)d.IsActive).AsQueryable();
            var result = _SieveProcessor.Apply(model, Devisi);
            var devisi = await PageList<Golongan>.ShowDataAsync(
                Devisi,
                result,
                model.Page,
                model.PageSize
            );

            return Ok(devisi);
        }

        [HttpPost]
        public async Task<IActionResult> PostDevisi([FromBody] CreateDevisiInput items)
        {
            try
            {
                var roleData = new Golongan()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = items.IsActive,
                    CreatedAt = DateTime.Now
                };
                await _AppDbContext.Golongan.AddAsync(roleData);
                await _AppDbContext.SaveChangesAsync();

                return Ok("Data Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevisi([FromRoute] Guid id, [FromBody] UpdateDevisiInput items)
        {
            try
            {
                var roleData = await _AppDbContext.Golongan.FindAsync(id);
                if (roleData == null)
                {
                    return NotFound("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.IsActive = items.IsActive;

                _AppDbContext.Golongan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return Ok("Data Berhasil Diperbarui");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteDevisi([FromRoute] Guid id)
        {
            try
            {
                var roleData = await _AppDbContext.Golongan.FindAsync(id);
                if (roleData == null)
                {
                    return NotFound("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.Golongan.Update(roleData);
                await _AppDbContext.SaveChangesAsync();
                return Ok("Data Berhasil Dihapus");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}