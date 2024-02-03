using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosCrecerAPI.Models;

namespace SegurosCrecerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimaController : Controller
    {
        private readonly SegurosCrecerContext _context;

        public PrimaController(
            SegurosCrecerContext context)
        {
            _context = context;
        }

        [HttpGet("calculate")]
        public async Task<IActionResult> Calculate(double sumaAsegurada, int tasaId) 
        {
            var tasa = await _context.Tasas.FirstOrDefaultAsync(t => t.Id == tasaId);

            if (tasa == null) return NotFound();

            var result = sumaAsegurada * (double)tasa.Tasa1;

            return Ok(result);
        }
    }
}
