using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB.DATA
{
    public static class ApiClient
    {
        private static readonly HttpClient client = new HttpClient
        {                          // Az API alap URL-je, amelyre a kéréseket küldjük.
            BaseAddress = new Uri("https://localhost:44324/api/")
        };

        /// <summary>
        /// Generikus metódus egy adott típusú lista lekérésére egy megadott végpontról.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vegpont"></param>
        /// <returns>A lista a megadott típusú elemekkel.</returns>
        /// <példa>var termekek = await ApiClient.GetListaAsync<ViewTermekLista>("Termek/TermekLista");</példa>
        public static async Task<List<T>> GetListaAsync<T>(string vegpont)
        {
            var lista = await client.GetFromJsonAsync<List<T>>(vegpont);

            return lista ?? new List<T>();
        }
    }
}