using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class Crible
    {

        public static int[] EratosthenesSieve(int n)
        {
            int[] crible = new int[n-1];
            int[] res;

            int i = 0;  //Plus petit élément du tableau
            int m = n;  //Plus grand élément du tableau

            int j = 2;
            int cpt = n - 1; //Compteur d'élément restant dans le crible 

            //Remplissage du tableau
            for(int k = 0; k < n-1 ; k++)
            {
                crible[k] = j;
                j++;
            }

            do
            {
                //Recupération du plus petit élément du crible
                for (int k = i; k < m; k++)
                {
                    if (crible[k] != 0)
                    {
                        i = crible[k];
                        break;
                    }
                }

                //Récupération du plus grand élément du crible en le parcourant en sens inverse
                for (int k = m -2 ; k > i; k--)
                {
                    if (crible[k] != 0)
                    {
                        m = crible[k];
                        break;
                    }
                }

                //Suppression des multiples du plus petit élément
                for (int k = i; k < m-2; k++)
                {
                    if (crible[k] % i == 0 && crible[k] != 0)
                    {
                        crible[k] = 0;
                        cpt--;
                    }
                }

            } while (i < Math.Sqrt(m));


            //Definition du tableau de résultat et remplissage
            res = new int[cpt];
            j = 0;
            for(int k = 0; k < crible.Length; k++)
            {
                if(crible[k] != 0)
                {
                    res[j] = crible[k];
                    j++;
                }
            }

            return res;
        }
    }
}
