using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.MODEL
{
    /// <summary>
    /// Rendelés sorok nézet osztálya, 
    /// amely a rendelés tételeit reprezentálja.
    /// </summary>
    public class ViewRendelesTetel
    {
        [Key]
        public int RendelesId { get; set; }
        public string? Termeknev { get; set; }
        public int Mennyiseg { get; set; }
        public int Egysegar { get; set; }
        public int? Kedvezmeny { get; set; }
        public int? Ar { get; set; }
    }
}
