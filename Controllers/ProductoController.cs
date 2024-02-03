using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosCrecerAPI.Models;

namespace SegurosCrecerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly SegurosCrecerContext _context;

        public ProductoController(
            SegurosCrecerContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _context.Productos.ToListAsync());
        }

        [HttpGet("loadSelect")]
        public async Task<IActionResult> LoadSelect()
        {
            var result = await _context.Productos.ToListAsync();

            if (result.Count == 0) return Ok(Array.Empty<object>());

            return Ok(result.Select(r => new
            {
                id = r.Id,
                name = r.Descripcion
            }));
        }
    }
}
