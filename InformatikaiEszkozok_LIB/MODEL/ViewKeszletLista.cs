using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.MODEL
{
    /// <summary>
    /// A termékek nevét és mennyiségét tartalmazó nézet osztálya,
    /// amely a készlet listáját reprezentálja.
    /// </summary>
    public class ViewKeszletLista
    {
        [Key]
        public int Id { get; set; }
        public string? Nev { get; set; }
        public int Ertek { get; set; }
    }
}
