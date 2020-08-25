using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSubiektGTXAF.Module.Serwisy
{
    public class SerwisAsortymentow : BazowySerwis
    {
        private readonly InsERT.Subiekt _aplikacja;

        public SerwisAsortymentow()
        {
            _aplikacja = this.PolaczZSubiektem();
        }

        public BindingList<BusinessObjects.Asortyment> PodajWszystkieAsortymenty()
        {
            var dane = _aplikacja.TowaryManager.OtworzKolekcje();


            var rezultat = new BindingList<BusinessObjects.Asortyment>();
            foreach (dynamic dana in dane)
            {
                var danaDoTabeli = SkonwertujCOMObject(dana);

                rezultat.Add(danaDoTabeli);
            }
            return rezultat;
        }

        public BusinessObjects.Asortyment SkonwertujCOMObject(dynamic comObject)
        {
            return new BusinessObjects.Asortyment(comObject.Nazwa, comObject.CenaKartotekowa, comObject.Symbol, comObject.Opis);
        }

        ///// <summary>
        ///// Zwraca wynik metody IAsortymenty.Znajdz(string Symbol)
        ///// </summary>
        ///// <param name="symbol"></param>
        ///// <returns></returns>
        //public IAsortyment PodajKonkretnyAsortyment(string symbol)
        //{
        //    var mgr = _aplikacja.PodajObiektTypu<IAsortymenty>();

        //    return mgr.Znajdz(symbol);
        //}

        ///// <summary>
        ///// Najpierw pobiera wszystkie Asortymenty, i potem zwraca element znaleziony pod przekazanym indexem
        ///// </summary>
        ///// <param name="indexWiersza">Index wiersza poszukiwanego asortymentu</param>
        ///// <returns></returns>
        //public Asortyment PodajKonkretnyAsortyment(int indexWiersza)
        //{

        //    var mgr = _aplikacja.PodajObiektTypu<IAsortymenty>();

        //    var tablicaAsortymentow = mgr.Dane.Wszystkie().ToArray();
        //    return tablicaAsortymentow[indexWiersza];
        //}

        //public bool ZmienOpis(string symbol, string nowyOpis)
        //{
        //    var mgr = _aplikacja.TowaryManager.Wybierz();
        //    using (var e = )
        //    {
        //        e.Dane.Opis = nowyOpis;

        //        return e.Zapisz();
        //    }
        //}
    }
}
