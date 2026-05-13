using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.MODEL
{
    /// <summary>
    /// A Termékek nevét és készletét tartalmazó nézet osztálya, 
    /// amely a termékek listáját reprezentálja.
    /// </summary>
    public class ViewTermekLista
    {
        [Key]
        public int Id { get; set; }
        public string? Nev { get; set; }
        public int Keszlet { get; set; }
    }
}
