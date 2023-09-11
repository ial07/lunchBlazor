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
    public class SumberPemenuhanController : ControllerBase
    {
        private readonly SieveProcessor _SieveProcessor;
        private readonly AppDbContext _AppDbContext;
        public SumberPemenuhanController(SieveProcessor sieveProcessor, AppDbContext AppDbContext)
        {
            _SieveProcessor = sieveProcessor;
            _AppDbContext = AppDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SumberPemenuhan>>> GetDevisis([FromQuery] SieveModel model)
        {

            var Devisi = _AppDbContext.SumberPemenuhan.Where(d => (bool)d.IsActive).AsQueryable();
            var result = _SieveProcessor.Apply(model, Devisi);
            var devisi = await PageList<SumberPemenuhan>.ShowDataAsync(
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
                var roleData = new SumberPemenuhan()
                {
                    Id = Guid.NewGuid(),
                    Name = items.Name,
                    IsActive = items.IsActive,
                    CreatedAt = DateTime.Now
                };
                await _AppDbContext.SumberPemenuhan.AddAsync(roleData);
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
                var roleData = await _AppDbContext.SumberPemenuhan.FindAsync(id);
                if (roleData == null)
                {
                    return NotFound("Opss Id not found");
                }

                roleData.Name = items.Name;
                roleData.IsActive = items.IsActive;

                _AppDbContext.SumberPemenuhan.Update(roleData);
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
                var roleData = await _AppDbContext.SumberPemenuhan.FindAsync(id);
                if (roleData == null)
                {
                    return NotFound("Opss Id not found");
                }
                roleData.IsActive = false;
                _AppDbContext.SumberPemenuhan.Update(roleData);
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