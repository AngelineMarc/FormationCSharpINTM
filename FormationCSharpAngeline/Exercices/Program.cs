using Exercices.Serie2;
using Serie_I;
using Serie2;
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

            /*  ElementaryOperations.BasicOperation(3, 4, '+');
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

              */

            /*int[] tab = new int[] { -1, 4, 7, 12, -6, 5 };
            int[] tab2 = new int[] { -2, 8 };
            int[] tabVide = new int[0];

            Console.WriteLine("Somme des éléments d'un tableau :");
            afficheTab(tab);
            int res = TasksTables.SumTab(tab);
            Console.WriteLine($"somme : {res} ");

            Console.WriteLine("Opération sur un tableau :");
            afficheTab(tab);
            int[] resTab = TasksTables.OpeTab(tab, '*', 2);
            afficheTab(resTab, true);

            Console.WriteLine("Concaténation de deux tableaux :");
            afficheTab(tab);
            afficheTab(tab2);
            int[] resTabConcat = TasksTables.ConcatTab(tab, tab2);
            afficheTab(resTabConcat, true);

            char[,] grilleMorpion = new char[3, 3] { { 'X', 'O', 'X' }, { '_', 'X', 'X' }, { 'O', 'O', 'O' } };
            Morpion.DisplayMorpion(grilleMorpion);
            int resMorpion = Morpion.CheckMorpion(grilleMorpion);
            Console.WriteLine($"res : {resMorpion}");

            Console.WriteLine("Recherche linéaire :");
            afficheTab(tab);
            int indiceSearch = Search.LinearSearch(tab, -6);
            Console.WriteLine($"Valeur -6 à l'indice {indiceSearch}");
            indiceSearch = Search.LinearSearch(tab, 13);
            Console.WriteLine($"Valeur 13 à l'indice {indiceSearch}");

            Console.WriteLine("Recherche dichotomique :");
            int[] tabTrie = new int[] { -2, 0, 5, 7, 9, 10, 23, 30, 100 };
            afficheTab(tabTrie);
            indiceSearch = Search.BinarySearch(tabTrie, 23);
            Console.WriteLine($"Valeur 23 à l'indice {indiceSearch}");
            */

            /*Prime.DisplayPrimes();

            int res = Euclide.Ged(60, 18);
            Console.WriteLine($"Le plus grand diviseur commun entre 60 et 18 est : {res}");
            */

            int[] tab1 = new int[] { 1, 2, 3 };
            int[] tab2 = new int[] { -1, -4, 0 };

            Console.WriteLine("Construction de matrice : ");
            int[][] matrice = Matrice.BuildingMatrix(tab1, tab2);
            afficheMatrice(matrice);

            int[][] mat1 = new int[3][] {
                new int [] { 1, 2 },
                new int [] { 4, 6 },
                new int [] { -1, 8 }
                };

            int[][] mat2 = new int[3][] {
                new int [] { -1, 5 },
                new int [] { -4, 0 },
                new int [] { 0, 2 },
                };

            int[][] mat3 = new int[2][] {
                new int [] { -1, 5, 0 },
                new int [] { -4, 0,1 }
                };

            Console.WriteLine("Addition de matrice : ");
            matrice = Matrice.Addition(mat1, mat2);
            afficheMatrice(matrice);

            Console.WriteLine("Soustraction de matrice : ");
            matrice = Matrice.Soustraction(mat1, mat2);
            afficheMatrice(matrice);

            Console.WriteLine("Multiplication de matrice : ");
            matrice = Matrice.Multiplication(mat1, mat3);
            afficheMatrice(matrice);

            Console.WriteLine("Crible d'Era");
            int[] tabCribe = Crible.EratosthenesSieve(100);
            afficheTab(tabCribe);

            QCM qcm = new QCM("Quelle est la réponse à la grande question sur la vie, l'univers et le reste ?",
                               new string[] { "1. 42", "2. 60", "3. La réponse 3", "4. L'univers" },
                               1,
                               5
                               );

            //int res = QCM.AskQuestion(qcm);
            //Console.WriteLine(res);

            QCM qcm2 = new QCM("Quelle est la meilleur maison de Poudlard ?",
                               new string[] { "1. Gryffondor", "2. Serpentard", "3. Poufsouffle", "4. Serdaigle" },
                               3,
                               5
                               );

            QCM qcm3 = new QCM("En quelle année est sortie Animal Crossing New Horizon",
                               new string[] { "1. 1999", "2. 2014", "3. 2019", "4. 2020" },
                               4,
                               5
                               );

            QCM[] tabQcm = new QCM[] { qcm, qcm2, qcm3 };
            QCM.AskQuestions(tabQcm);

            Console.ReadKey();
        }

        public static void afficheTab(int[] tab, bool res = false)
        {
            if (res)
            {
                Console.Write("res : [");
            }
            else
            {
                Console.Write("tab : [");
            }
            
            for(int i = 0; i < tab.Length; i++)
            {
                Console.Write($"{tab[i]} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public static void afficheMatrice(int[][] matrice)
        {
            for(int i = 0; i < matrice.Length; i++)
            {
                for( int j = 0; j < matrice[i].Length; j++)
                {
                    Console.Write($"{matrice[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
