using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBajgrowicz
{
    public enum Kategorie
    {
        pieczywo,
        slodycze,
        napoje,
        alkohol,
        cena
    }
    class Program
    {
        static void Main(string[] args)
        {
            var klient = new Klient("Magda", "Bajgrowicz", "magdabaj@gmail.com", 20);

            Console.WriteLine(klient);

            var bulka = new Produkt("bulka", Kategorie.pieczywo, 12.7);
            var piwo = new Produkt("piwo", Kategorie.alkohol, 3.8);

            Console.WriteLine(bulka);
            Console.WriteLine(piwo);

            var czekolada = new ProduktPromocyjny("czekolada", Kategorie.slodycze, 10, 2);

            Console.WriteLine(czekolada);

            var koszyk = new Koszyk(klient);
            koszyk.DodajProdukt(bulka);
            koszyk.DodajProdukt(piwo);
            koszyk.DodajProdukt(czekolada);

            Console.WriteLine(koszyk);

            var klient2 = new Klient("Pawel", "Kowalski", "paw@onet.pl", 12);
            var koszyk2 = new Koszyk(klient2);
            koszyk2.DodajProdukt(bulka);

            Koszyk koszykKlon;
            koszykKlon = koszyk.DeepClone<Koszyk>();

            koszykKlon.Klient = klient2;

            Console.WriteLine(koszykKlon);
            Console.WriteLine(koszyk);

            Console.ReadKey();
        }
    }
}
