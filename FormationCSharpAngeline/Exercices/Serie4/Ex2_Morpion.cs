using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie4
{
    public static class Morpion
    {
        //Liste des coups que le joueur peut faire
        private static List<string> coupValide = new List<string>{ "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
        public static void MorpionGame()
        {
            char[,] grille = new char[3,3] { { '_', '_', '_' }, { '_', '_', '_' }, { '_', '_', '_' } };

            Console.WriteLine("Début de partie de Morpion : ");

            int resultat = -1;
            bool joueur1 = true;
            do
            {
                //Définition du joueur à qui est le tour
                int joueur = joueur1 ? 1 : 2;
                Console.Write($"Coup du joueur {joueur} : ");
                string coup = Console.ReadLine();

                //Tant que le coup n'est pas valide on demande au joueur d'en refaire un
                while (!coupValide.Contains(coup))
                {
                    Console.WriteLine("Coup incorrect, veuillez réessayer.");
                    Console.Write($"Coup du joueur {joueur} : ");
                    coup = Console.ReadLine();
                }

                //Définition de la ligne et colonne correspondant au coup
                int l = -1;
                int c = int.Parse(coup[1].ToString()) - 1;
                if (coup[0] == 'A')
                {
                    l = 0;
                }else if (coup[0] == 'B')
                {
                    l = 1;
                }
                else
                {
                    l = 2;
                }

                //Vérification que la case est bien vide
                if (grille[l, c] == '_')
                {
                    //Définition du symbole du joueur et ajout à la grille
                    grille[l, c] = joueur1 ? 'X' : 'O';

                    //Définition du prochain joueur à jouer
                    joueur1 = joueur1 ? false : true;

                    DisplayMorpion(grille);

                    //Vérification du résultat de la partie
                    resultat = CheckMorpion(grille);
                }
                else
                {
                    Console.WriteLine("Coup incorrect, veuillez réessayer.");
                }

            } while (resultat == -1);
            

            if(resultat != 0)
            {
                Console.WriteLine($"Le joueur {resultat} a remporté la partie");
            }
            else
            {
                Console.WriteLine("Match nul");
            }

        }

        public static void DisplayMorpion(char[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    Console.Write($"{grille[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int CheckMorpion(char[,] grille)
        {
            for (int i = 0; i < 3; i++)
            {
                // Vérification des lignes
                if (grille[i, 0] == grille[i, 1] && grille[i, 1] == grille[i, 2])
                {
                    if (grille[i, 0] == 'X')
                    {
                        return 1;
                    }
                    else if (grille[i, 0] == 'O')
                    {
                        return 2;
                    }
                }

                //Vérification des colonnes
                if (grille[0, i] == grille[1, i] && grille[1, i] == grille[2, i])
                {
                    if (grille[0, i] == 'X')
                    {
                        return 1;
                    }
                    else if (grille[0, i] == 'O')
                    {
                        return 2;
                    }
                }
            }

            // Vérification des diagonales
            if (grille[0, 0] == grille[1, 1] && grille[1, 1] == grille[2, 2] ||
                grille[0, 2] == grille[1, 1] && grille[1, 1] == grille[2, 0])
            {
                if (grille[1, 1] == 'X')
                {
                    return 1;
                }
                else if (grille[1, 1] == 'O')
                {
                    return 2;
                }
            }

            //Si on atteint cette boucle, alors aucun joueur n'a encore gagné, on regarde donc si la partie est toujours en cours
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == '_')
                    {
                        return -1;
                    }
                }
            }

            // la partie est terminée sans gagnant
            return 0;
        }
    }
}
