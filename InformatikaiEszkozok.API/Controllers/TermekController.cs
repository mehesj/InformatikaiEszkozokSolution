using InformatikaiEszkozok_LIB.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformatikaiEszkozok.Controllers
{
    [Route("api/[controller]")] // Innen ereda végpont neve, például: "api/Termek" (Controller neve)
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly InfotermekDbContext context;

        public TermekController(InfotermekDbContext context)
        {
            this.context = context;
        }

        // api/Termek/TermekLista
        [HttpGet("TermekLista")] // Itt határozzuk meg a végpontot, például: api/Termek/TermekLista
        public async Task<IActionResult> TermekLista()
        {
            var termekek = await context.ViewTermekLista.ToListAsync();

            return Ok(termekek);
        }

        // api/Termek/KeszletLista
        [HttpGet("KeszletLista")]
        public async Task<IActionResult> KeszletLista()
        {
            var keszlet = await context.ViewKeszletLista.ToListAsync();

            return Ok(keszlet);
        }
    }
}