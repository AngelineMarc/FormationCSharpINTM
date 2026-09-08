using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            int res = 0;
            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{a} {operation} {b} = {a + b}");

                    break;
                case '-':
                    Console.WriteLine($"{a} {operation} {b} = {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"{a} {operation} {b} = {a * b}");
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine($"{a} {operation} {b} = Opération invalide.");
                    }
                    else
                    {
                        Console.WriteLine($"{a} {operation} {b} = {a / b}");
                    }
                    break;
                default:
                    Console.WriteLine($"{a} {operation} {b} = Opération invalide.");
                    break;
            }
        }

        public static void IntegerDivision(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine($"{a} : {b} = Opération invalide.");
            }
            else
            {
                int quotient = a / b;
                int reste = a % b;
                if(reste == 0)
                {
                    Console.WriteLine($"{a} = {quotient} * {b}");
                }
                else
                {
                    Console.WriteLine($"{a} = {quotient} * {b} + {reste}");
                }

            }
        }

        public static void Pow(int a, int b)
        {
            if (b < 0)
            {
                Console.WriteLine($"{a} ^ {b} = Opération invalide.");
            }
            else
            {
                int res = a;
                
                for(int i = 1; i < b; i++)
                {
                    res *= a;
                }
                Console.WriteLine($"{a} ^ {b} = {res}");
            }
        }
    }
}
