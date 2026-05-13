using InformatikaiEszkozok_LIB.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformatikaiEszkozok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesController : ControllerBase
    {
        private readonly InfotermekDbContext context;

        public RendelesController(InfotermekDbContext context)
        {
            this.context = context;
        }

        // api/Rendeles/RendelesLista
        [HttpGet("RendelesLista")]
        public async Task<IActionResult> RendelesLista()
        {
            var rendelesek = await context.ViewRendelesOsszesites.ToListAsync();

            return Ok(rendelesek);
        }

        // api/Rendeles/RendelesTetelek/5
        [HttpGet("RendelesTetelek/{rendelesId}")]
        public async Task<IActionResult> RendelesTetelek(int rendelesId)
        {
            var tetelek = await context.ViewRendelesTetel
                .Where(t => t.RendelesId == rendelesId)
                .ToListAsync();

            return Ok(tetelek);
        }
    }
}