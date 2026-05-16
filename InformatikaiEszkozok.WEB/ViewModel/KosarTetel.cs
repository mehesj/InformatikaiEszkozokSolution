namespace InformatikaiEszkozok.WEB.ViewModel
{
    public class KosarTetel
    {
        public int TermekId { get; set; }
        public string? Nev { get; set; }
        public int Egysegar { get; set; }
        public int Mennyiseg { get; set; } = 0;
        public string? KepFajlnev { get; set; }
    }
}
