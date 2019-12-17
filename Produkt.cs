using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBajgrowicz
{
    [Serializable]
    public class Produkt: ICloneable
    {

        private string _imie;

        private Kategorie _kategoria;

        private double _cena;
        public static int MinWiek { get; set; } = 18;

        public string Imie
        {
            get => _imie;
            set => _imie = value;
        }

        public double Cena
        {
            get => _cena;
            set
            {
                if (_cena > 0)
                {
                    _cena = value;
                }
            }
        }

        public Kategorie Kategoria
        {
            get => _kategoria;
            set => _kategoria = value;
        }

        public Produkt()
        {
            
        }

        public Produkt(string imie, Kategorie kategoria, double cena)
        {
            _imie = imie;
            _kategoria = kategoria;
            _cena = cena;
        }

        public virtual double CenaProduktu()
        {
            return this._cena;
        }

        public override string ToString()
        {
            if (this.Kategoria == Kategorie.alkohol)
            {
                return $"Nazwa produktu {Imie}, kategoria {Kategoria}, cena {Cena, 10:C} (minimalny wiek {MinWiek})";
            }
            else
            {
                return $"Nazwa produktu {Imie}, kategoria {Kategoria}, cena {Cena, 10:C}";
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
