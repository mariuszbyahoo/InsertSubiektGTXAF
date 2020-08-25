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
                var danaDoTabeli = KonwersjaDoAsortymentu(dana);

                rezultat.Add(danaDoTabeli);
            }
            return rezultat;
        }

        public bool ZmienOpis(string symbol, string nowyOpis)
        {
            var towar = _aplikacja.TowaryManager.WczytajTowar(symbol);
            towar.Opis = nowyOpis;
            towar.Zapisz();
            return true;
        }

        public BusinessObjects.Asortyment KonwersjaDoAsortymentu(dynamic comObject)
        {
            return new BusinessObjects.Asortyment(comObject.Nazwa, comObject.CenaKartotekowa, comObject.Symbol, comObject.Opis);
        }
    }
}
