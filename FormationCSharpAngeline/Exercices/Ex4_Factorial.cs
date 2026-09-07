using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int res = 1;
            for(int i = 1; i <= n; i++)
            {
                res *= i;

            }

            return res;
        }

        public static int FactorialRecursive(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return  n * FactorialRecursive(n-1);
        }
    }
}
