using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChevBook
{
    public class Controlleur
    {
        private static Modele vmodele;

        internal static Modele Vmodele
        {
            get
            {
                return vmodele;
            }

            set
            {
                vmodele = value;
            }
        }

        public static void init()
        {
            Vmodele = new Modele();
        }
    }
}
