using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Morpion
    {
        public static void DisplayMorpion(char[,] grille)
        {
            for(int i= 0; i< grille.GetLength(0); i++)
            {
                for(int j=0; j < grille.GetLength(1); j++)
                {
                    Console.Write($"{grille[i, j]} ");
                }
                Console.WriteLine();
            }
            return;
        }

        public static int CheckMorpion(char[,] grille)
        {
                       
            for (int i = 0; i < 3; i++)
            {
                // Vérification des lignes
                if (grille[i, 0] == grille[i, 1]  && grille[i, 1] == grille[i, 2])
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
                if (grille[0, i] == grille[1, i]  && grille[1, i] == grille[2, i])
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
            if(grille[0, 0] ==  grille[1, 1]  && grille[1, 1] ==  grille[2, 2] ||
                grille[0, 2] == grille[1, 1] && grille[1, 1] == grille[2, 0] )
            {
                if(grille[1, 1] == 'X')
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
