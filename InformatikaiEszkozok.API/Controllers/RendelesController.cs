using InformatikaiEszkozok_LIB.DATA;
using InformatikaiEszkozok_LIB.MODEL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        // api/Rendeles/RendelesRogzites
        [HttpPost("RendelesRogzites")]
        public async Task<IActionResult> RendelesRogzites([FromBody] RendelesRogzitesAdat adat)
        {
           
            if (adat.Vasarlo.Id == 0)
            {
                context.Vasarlo.Add(adat.Vasarlo);
                await context.SaveChangesAsync();
            }

            var rendeles = new Rendeles
            {
                VasarloId = adat.Vasarlo.Id,
                Datum = DateOnly.FromDateTime(DateTime.Now)
            };

            context.Rendeles.Add(rendeles);
            await context.SaveChangesAsync();

            foreach (var tetel in adat.Tetelek)
            {
                tetel.Id = 0;
                tetel.RendelesId = rendeles.Id;
            }

            context.RendelesTetel.AddRange(adat.Tetelek);
            await context.SaveChangesAsync();

            return Ok(adat.Vasarlo);
        }
    }
}