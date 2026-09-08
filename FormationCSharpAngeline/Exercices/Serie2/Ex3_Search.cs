using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            int indice = -1;
            
            for(int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    indice = i; 
                    break;
                }
            }
            return indice;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            int debut = 0;
            int fin = tableau.Length;
            int indiceRes = -1;

            while(debut <= fin )
            {
                int milieu = debut + (fin - debut) / 2;
                
                if (tableau[milieu] == valeur)
                {
                    indiceRes= milieu;
                    break;
                }
                else if (tableau[milieu] < valeur)
                {
                    debut = milieu + 1;
                }
                else
                {
                    fin = milieu - 1;
                }
            }
            return indiceRes;
        }
    }
}
