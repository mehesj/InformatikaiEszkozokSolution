using InformatikaiEszkozok_LIB.DATA;
using InformatikaiEszkozok_LIB.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.Console
{
    public class ReadVasarlo
    {
        public static void Read()
        {
            using var context = new InfotermekDbContext();
            var vasarlok = File.ReadLines("vasarlo.csv") // Soronként olvassuk be a fájlt (memóriabarát)
            .Skip(1) // fejléc kihagyása
            .Select(line =>
            {                                      // Megtartja a pontos helyet, még ha üres is (pl. azonosító hiánya esetén)
                var parts = line.Split(';', StringSplitOptions.None);

                return new Vasarlo
                {
                    Azonosito = string.IsNullOrWhiteSpace(parts[1]) ? " " : parts[1], // Ha az azonosító hiányzik, akkor egy szóközt adunk helyette
                    Nev = parts[2],
                    Telefon = parts[3],
                    Email = parts[4]
                };
            })
            .ToList();

            context.Vasarlo.AddRange(vasarlok);
            context.SaveChanges();
        }
    }
}
