using Serie_I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Exercices
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            ElementaryOperations.BasicOperation(3, 4, '+');
            ElementaryOperations.BasicOperation(6, 2, '/');
            ElementaryOperations.BasicOperation(3, 0, '/');
            ElementaryOperations.BasicOperation(6, 4, 'L');

            ElementaryOperations.IntegerDivision(12, -4);
            ElementaryOperations.IntegerDivision(13, -4);
            ElementaryOperations.IntegerDivision(12, 0);

            ElementaryOperations.Pow(5, 3);
            ElementaryOperations.Pow(5, -1);

            string res = SpeakingClock.GoodDay(24);
            Console.WriteLine(res);
            res = SpeakingClock.GoodDay(5);
            Console.WriteLine(res);
            res = SpeakingClock.GoodDay(15);
            Console.WriteLine(res);

            Pyramid.PyramidConstruction(10, false);

            int resfact = Factorial.Factorial_(0);
            Console.WriteLine($"Resultat factorielle 0 : {resfact}");

            resfact = Factorial.FactorialRecursive(5);
            Console.WriteLine($"Resultat factorielle recursive de 5 : {resfact}");

            Console.ReadKey();
        }
    }
}
