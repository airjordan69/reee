using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagdalenaBajgrowicz
{
    [Serializable]
    public class Koszyk: ICloneable
    {
        private Klient _klient;
//        private Stack<Produkt> _produkty;
        public Stack<Produkt> Produkty { get; set; }

        public Klient Klient
        {
            get => _klient;
            set => _klient = value;
        }

//        public Stack<Produkt> Produkty
//        {
//            get => _produkty;
//            set => _produkty = value;
//        }

        public Koszyk()
        {
        }

        public Koszyk(Klient klient)
        {
            _klient = klient;
            Produkty = new Stack<Produkt>();
        }

        public void DodajProdukt(Produkt produkt)
        {
            if (_klient.Wiek < 18 && produkt.Kategoria == Kategorie.alkohol)
            {
                throw new ZakazSprzedazy("Nie posiadasz odpowiedniego wieku by kupic dany produkt");
            }
            else
            {
                Produkty.Push(produkt);
            }
        }

        public void UsunProdukt()
        {
            Produkty.Pop();
        }

        public double PrzeliczKoszyk()
        {
            double suma = 0;
            foreach (var produkt in Produkty)
            {
                suma += produkt.CenaProduktu();
            }

            return suma;
        }

        public override string ToString()
        {
            var koszyk = new StringBuilder();
            koszyk.Append(Klient);
            koszyk.AppendLine();
            foreach (var produkt in Produkty)
            {
                koszyk.Append(produkt);
                koszyk.AppendLine();
            }
            koszyk.AppendLine($"SUMA{PrzeliczKoszyk(), 10:C}");
            return koszyk.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Koszyk DeepClone<Koszyk>()
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (Koszyk)formatter.Deserialize(memoryStream);
            }
        }

        public Koszyk DeepCopy()
        {
            List<Produkt> produktyLista = new List<Produkt>(Produkty);
            var koszykKopia = new Koszyk();
            koszykKopia.Klient = (Klient) _klient.Clone();
            var nowyKoszyk = new List<Produkt>(produktyLista.Select(produkt => (Produkt)produkt.Clone()));
            Stack<Produkt> produktyStos = new Stack<Produkt>(nowyKoszyk);
            koszykKopia.Produkty = produktyStos;

            return koszykKopia;
        }

        public static void SaveXml(string fileName, Koszyk koszyk)
        {
//            List<Produkt> produktyLista = new List<Produkt>(Produkty);
            XmlSerializer serializer = new XmlSerializer(typeof(Koszyk));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, koszyk);
            }

        }
    }
}
