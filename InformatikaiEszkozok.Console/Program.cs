

using InformatikaiEszkozok_LIB;
using InformatikaiEszkozok_LIB.MODEL;
using Microsoft.IdentityModel.Tokens;

/// 3. feladat: Menü megjelenítése a konzolon és a választás kezelése
while (true)
{
    Console.Clear();
    Console.WriteLine("Válasszon egy menüpontot!\n");
    Console.WriteLine("1. Termékek listája és készlet mennyisége");
    Console.WriteLine("2. Készleten lévő termékek értéke terméknév alapján és összérték");
    Console.WriteLine("3. Rendelések listája, legnagyobb és legkisebb értékű rendelés tételei");
    Console.WriteLine("0. Kilépés");
    Console.Write("\nVálasztás: ");
    var valasztas = Console.ReadLine();

    // A választás alapján meghívjuk a megfelelő metódust
    switch (valasztas)
    {
        case "1":
            await TermekListaKiir();
            break;

        case "2":
            await KeszletListaKiir();
            break;

         case "3":
            await RendelesekLekerdezes();
            break;

        case "0":
            return;
    }
}

/// 4. feladat: Termékek listájának kiírása a konzolra
static async Task TermekListaKiir()
{
    var termekek = await Worker.TermekLista();

    Console.Clear();
    Console.WriteLine("Termékek listája\n");

    Console.WriteLine($"{"Id",-3} {"Nev",-25} {"Keszlet",5}");
    foreach (var t in termekek)
    {
        // - jobbra igazít, + balra igazít
        Console.WriteLine($"{t.Id,-3} {t.Nev,-25} {t.Keszlet,5} db");
    }

    Console.WriteLine("\nTovábblépéshez üssön Entert!");
    Console.ReadLine();
}

/// 5. feladat: Készletérték listájának kiírása a konzolra
static async Task KeszletListaKiir()
{
    var termekek = await Worker.KeszletLista();

    Console.Clear();

    Console.WriteLine("Készletérték\n");
    Console.WriteLine($"{"Id",-3} {"Nev",-28} {"Értéke",15}");

    foreach (var t in termekek)
    {
        Console.WriteLine($"{t.Id,-3} {t.Nev,-28} {t.Ertek,15:N0} Ft");
    }

    Console.WriteLine();
    Console.WriteLine($"{"",-4} {"Összérték:",-27} {termekek.Sum(t => t.Ertek),15:N0} Ft");

    Console.WriteLine("\nTovábblépéshez üssön Entert!");
    Console.ReadLine();
}

/// <summary>
///  6. feladat: Rendelések listájának kiírása a konzolra, 
///  majd a legnagyobb és legkisebb értékű rendelés tételeinek kiírása a konzolra
/// </summary>
static async Task RendelesekLekerdezes()
{
    var rendelesek = await Worker.RendelesLista();

    var legnagyobb = rendelesek.OrderByDescending(r => r.RendelesErtek).First();
    var legkisebb = rendelesek.OrderBy(r => r.RendelesErtek).First();

    var legnagyobbTetelek = await Worker.RendelesTetelek(legnagyobb.Id);
    var legkisebbTetelek = await Worker.RendelesTetelek(legkisebb.Id);

    Console.Clear();

    RendelesKiir("Legnagyobb összegű vásárlás:", legnagyobb, legnagyobbTetelek);
    Console.WriteLine();
    Console.WriteLine();
    RendelesKiir("Legkisebb összegű vásárlás:", legkisebb, legkisebbTetelek);

    Console.WriteLine();
    Console.WriteLine("Továbblépéshez üssön Entert!");
    Console.ReadLine();
}

/// <summary>
/// 6.1 A megrendeléshez tartozó tételek kiírása a konzolra
/// </summary>
/// <param name="cim">Fejléc szövege.</param>
/// <param name="rendeles">A megrendelés adatai.</param>
/// <param name="tetelek">A megrendelés tételei.</param>
static void RendelesKiir(string cim, ViewRendelesOsszesites rendeles, List<ViewRendelesTetel> tetelek)
{
    Console.WriteLine(cim);
    Console.WriteLine();

    Console.WriteLine($"{"rendelésszám",-25} {rendeles.Id}");
    Console.WriteLine($"{"kedvezmény azonosító",-25} {rendeles.KedvezmenyAzonosito}");
    Console.WriteLine($"{"Név",-25} {rendeles.Nev}");
    Console.WriteLine($"{"telefon",-25} {rendeles.Telefon}");
    Console.WriteLine($"{"email",-25} {rendeles.Email}");
    Console.WriteLine();

    Console.WriteLine($"{"terméknév",-20} {"mennyiség",10} {"egységár",14} {"kedvezmény",14} {"ár",14}");

    foreach (var tetel in tetelek)
    {
        string kedvezmeny = tetel.Kedvezmeny == 0
            ? "-"
            : $"-{tetel.Kedvezmeny:N0} Ft";

        Console.WriteLine(
            $"{tetel.Termeknev,-20} " +
            $"{tetel.Mennyiseg,8} db " +
            $"{tetel.Egysegar,12:N0} Ft " +
            $"{kedvezmeny,14} " +
            $"{tetel.Ar,12:N0} Ft"
        );
    }
    Console.WriteLine();

    // Kedvezmény ha van, akkor kiírjuk a kedvezmény összegét
    if (rendeles.Kedvezmeny > 0)
    {
        Console.WriteLine(
            $"{"20% kedvezmény",-33}" +
            $"{-rendeles.Kedvezmeny,27:N0} Ft"
        );
    }

    // Végösszeg
    Console.WriteLine(
        $"{"Végösszeg:",-50}" +
        $"{rendeles.RendelesErtek,26:N0} Ft"
    );
}