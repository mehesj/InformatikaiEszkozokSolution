using InformatikaiEszkozok.WEB.ViewModel;

namespace InformatikaiEszkozok.WEB.SERVICE
{
    public class KosarService
    {
        public List<KosarTetel> Tetelek { get; set; } = new();

        public int Darabszam => Tetelek.Sum(t => t.Mennyiseg);

        public void Urit()
        {
            Tetelek.Clear();
        }
    }
}
