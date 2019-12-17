using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagdalenaBajgrowicz
{
    class ZakazSprzedazy: Exception
    {
//        public ZakazSprzedazy()
//        {
//        }

        public ZakazSprzedazy(string message):base(message)
        {
            Console.WriteLine(message);
        }
    }
}
