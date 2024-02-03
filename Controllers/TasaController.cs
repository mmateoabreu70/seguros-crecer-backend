using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosCrecerAPI.Models;

namespace SegurosCrecerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasaController : Controller
    {
        private readonly SegurosCrecerContext _context;

        public TasaController(
            SegurosCrecerContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _context.Tasas.ToListAsync());
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByProducto(int productoId)
        {
            return Ok(await _context.Tasas.Where(r => r.ProductoId == productoId).ToListAsync());
        }

        [HttpGet("loadSelect")]
        public async Task<IActionResult> LoadSelect(int productoId)
        {
            var result = await _context.Tasas.Where(t => t.ProductoId == productoId).ToListAsync();

            if (result.Count == 0) return Ok(Array.Empty<object>());

            return Ok(result.Select(r => new
            {
                id = r.Id,
                name = r.Descripcion
            }));
        }
    }
}
