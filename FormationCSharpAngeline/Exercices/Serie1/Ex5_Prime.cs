using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Prime
    {
        public static bool IsPrime(int value)
        {
            if (value <= 1)
            {
                return false;
            }
            for(int i = 2; i <= Math.Sqrt(value); i++)
            {
                if (value % i == 0)
                {
                    return false;
                        
                }
            }
            
            return true;
        }

        public static void DisplayPrimes()
        {
            bool prime;
            Console.WriteLine("Liste des nombres premiers : ");
            for(int i = 1; i <= 100; i++)
            {
                prime = IsPrime(i);
                if (prime)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

    }
}
