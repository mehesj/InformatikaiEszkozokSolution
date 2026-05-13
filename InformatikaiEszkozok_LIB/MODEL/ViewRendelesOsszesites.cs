using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.MODEL
{
    /// Renedelések és értéke.
    /// A legnagyobb és legkisebb értékű rendelések 
    /// kikeresésére használjuk.
    public class ViewRendelesOsszesites
    {
        [Key]
        public int Id { get; set; }
        public string? KedvezmenyAzonosito { get; set; }
        public string? Nev { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public int? Kedvezmeny { get; set; }
        public int? RendelesErtek { get; set; }
    }
}
