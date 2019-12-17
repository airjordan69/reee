using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBajgrowicz
{
    [Serializable]
    public class Klient: ICloneable
    {
        private string _email;
        private string _imie;
        private string _nazwisko;
        private int _wiek;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Imie
        {
            get => _imie;
            set => _imie = value;
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set => _nazwisko = value;
        }

        public int Wiek
        {
            get => _wiek;
            set
            {
                if (_wiek >= 13)
                {
                    _wiek = value;
                }
            }
        }

        public Klient()
        {
            
        }

        public Klient(string imie, string nazwisko, string email, int wiek)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _email = email;
            _wiek = wiek;
        }

        public override string ToString()
        {
            return $"Klient {Imie} {Nazwisko} ({Email})";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
