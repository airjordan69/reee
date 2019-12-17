using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBajgrowicz
{
    [Serializable]
    public class ProduktPromocyjny: Produkt
    {
        private double _rabat;

        public double Rabat
        {
            get => _rabat;
            set => _rabat = value;
        }

        public ProduktPromocyjny()
        {
        }

        public ProduktPromocyjny(string imie, Kategorie kategoria, double cena, double rabat):base(imie, kategoria, cena)
        {
            _rabat = rabat;
        }

        public override double CenaProduktu()
        {
            return base.CenaProduktu() - Rabat;
        }

        public override string ToString()
        {
            return $"{base.ToString()} cena z rabatem {CenaProduktu(), 10:C}";
        }
    }
}
