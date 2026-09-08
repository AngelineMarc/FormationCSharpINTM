using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    internal class Euclide
    {
        public static int Ged(int a, int b)
        {
            int quotient;
            int reste;

            do
            {
                quotient = a / b;
                reste = a % b;
                a = b;
                b = reste;
                
            } while (reste != 0);

            return a;
        }
    }
}
