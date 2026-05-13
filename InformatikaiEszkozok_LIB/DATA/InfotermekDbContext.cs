using InformatikaiEszkozok_LIB.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.DATA
{
    public class InfotermekDbContext : DbContext
    {
        // A DbSet-ek a táblák reprezentációi az adatbázisban. Minden DbSet egy adott típusú entitást képvisel, amely a táblában tárolt adatokat jelenti.
        //       <C# objektum> Adatbázis tábla
        public DbSet<Vasarlo> Vasarlo { get; set; }
        public DbSet<Termek> Termek { get; set; }
        public DbSet<Rendeles> Rendeles { get; set; }
        public DbSet<RendelesTetel> RendelesTetel { get; set; }

        // Kiegészítés az SQL nézetekkel
        public DbSet<ViewTermekLista> ViewTermekLista { get; set; }
        public DbSet<ViewKeszletLista> ViewKeszletLista { get; set; }
        public DbSet<ViewRendelesOsszesites> ViewRendelesOsszesites { get; set; }
        public DbSet<ViewRendelesTetel> ViewRendelesTetel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Átírtuk az OnConfiguring
                                                                                      // metódust, hogy megadjuk az adatbázis kapcsolat stringjét
        {
            optionsBuilder.UseSqlServer(
                //           Adatbázis szerver neve; Adatbázis neve; Windows Authentication használata; Tanúsítvány megbízhatóságának elfogadása
                "Server=CortanaServer; Database=InfotermekDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
