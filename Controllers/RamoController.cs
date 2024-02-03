using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosCrecerAPI.Models;

namespace SegurosCrecerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamoController : Controller
    {
        private readonly SegurosCrecerContext _context;

        public RamoController(
            SegurosCrecerContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _context.Ramos.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetByTipoRamo(int tipoRamoId)
        {
            return Ok(await _context.Ramos.Where(r => r.TipoRamoId == tipoRamoId).ToListAsync());
        }

        [HttpGet("loadSelect")]
        public async Task<IActionResult> LoadSelect(int tipoRamoId)
        {
            var result = await _context.Ramos.Where(t => t.TipoRamoId == tipoRamoId).ToListAsync();

            if (result.Count == 0) return Ok(Array.Empty<object>());

            return Ok(result.Select(r => new
            {
                id = r.Id,
                name = r.Descripcion
            }));
        }
    }
}
