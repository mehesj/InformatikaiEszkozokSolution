using InformatikaiEszkozok_LIB.DATA;
using InformatikaiEszkozok_LIB.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaiEszkozok_LIB
{
    public static class Worker
    {
        /// <summary>
        /// Termék lista lekérése az API-ról, majd visszaadása a hívó félnek.
        /// </summary>
        /// <returns>A termékek listája.</returns>
        public static async Task<List<ViewTermekLista>> TermekLista()
        {
            return await ApiClient.GetListaAsync<ViewTermekLista>("Termek/TermekLista");
        }

        /// <summary>
        /// Termék készlet és érték lekérése az API-ról, majd visszaadása a hívó félnek.
        /// </summary>
        /// <returns>A termékek készletének listája.</returns>
        public static async Task<List<ViewKeszletLista>> KeszletLista()
        {
            return await ApiClient.GetListaAsync<ViewKeszletLista>("Termek/KeszletLista");
        }

        /// <summary>
        ///  Megrendelések listájának lekérése az API-ról, majd visszaadása a hívó félnek.
        /// </summary>
        /// <returns>A megrendelések listája az értékekkel</returns>
        public static async Task<List<ViewRendelesOsszesites>> RendelesLista()
        {
            return await ApiClient.GetListaAsync<ViewRendelesOsszesites>("Rendeles/RendelesLista");
        }

        /// <summary>
        /// A megrendeléshez tartozó tételek lekérése az API-ról, majd visszaadása a hívó félnek.
        /// </summary>
        /// <param name="rendelesId">A megrendelés azonosítója.</param>
        /// <returns>A megrendelés tételeinek listája.</returns>
        public static async Task<List<ViewRendelesTetel>> RendelesTetelek(int rendelesId)
        {
            return await ApiClient.GetListaAsync<ViewRendelesTetel>($"Rendeles/RendelesTetelek/{rendelesId}");
        }
    }
}
