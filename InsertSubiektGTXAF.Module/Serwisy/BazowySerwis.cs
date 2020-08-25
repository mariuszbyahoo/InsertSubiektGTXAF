using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSubiektGTXAF.Module
{
    public class BazowySerwis
    {
        public InsERT.Subiekt PolaczZSubiektem()
        {
            var gt = new InsERT.GT();
            InsERT.Subiekt sgt;

            gt.Produkt = InsERT.ProduktEnum.gtaProduktSubiekt;
            gt.Serwer = "(local)\\InsertGT";
            gt.Baza = "NoweDemo";
            gt.Autentykacja = InsERT.AutentykacjaEnum.gtaAutentykacjaMieszana;
            gt.Uzytkownik = "";
            gt.UzytkownikHaslo = "";
            gt.Operator = "Szef";
            gt.OperatorHaslo = "";

            sgt = (InsERT.Subiekt)gt.Uruchom((int)InsERT.UruchomDopasujEnum.gtaUruchomDopasuj, (int)InsERT.UruchomEnum.gtaUruchomWTle);
            sgt.Okno.Widoczne = false;
            return sgt;
        }
    }
}
