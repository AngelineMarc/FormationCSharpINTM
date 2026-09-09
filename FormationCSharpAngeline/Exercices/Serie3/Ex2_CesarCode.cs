using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie3
{
    public class Cesar
    {
        private readonly char[,] _cesarTable;

        public Cesar()
        {
            _cesarTable = new char[,]
            {
                { 'A', 'D' },
                { 'B', 'E' },
                { 'C', 'F' },
                { 'D', 'G' },
                { 'E', 'H' },
                { 'F', 'I' },
                { 'G', 'J' },
                { 'H', 'K' },
                { 'I', 'L' },
                { 'J', 'M' },
                { 'K', 'N' },
                { 'L', 'O' },
                { 'M', 'P' },
                { 'N', 'Q' },
                { 'O', 'R' },
                { 'P', 'S' },
                { 'Q', 'T' },
                { 'R', 'U' },
                { 'S', 'V' },
                { 'T', 'W' },
                { 'U', 'X' },
                { 'V', 'Y' },
                { 'W', 'Z' },
                { 'X', 'A' },
                { 'Y', 'B' },
                { 'Z', 'C' }
            };
        }

        public string CesarCode(string line)
        {
            char[] lineCode = line.ToUpper().ToCharArray();
            char[] res = new char[lineCode.Length];
            
            //Parcours du message à coder
            for(int i = 0; i < res.Length; i++)
            {
                int j = 0;
                //Parcours du tableau de codage
                for (; j < _cesarTable.GetLength(0); j++)
                {
                    //Si le caractère a coder correspond au caractère en indice 0 du tableau d'encodage, on arrete notre boucle
                    if (_cesarTable[j, 0] == lineCode[i])
                    {
                        break;
                    }
                }
                //Vérification que l'indice soit correct, si ce n'est pas le cas on recopie le caractère de base
                //(notamment pour les espaces, caractères spéciaux ou lettres avec accent)
                if( j < _cesarTable.GetLength(0))
                {
                    //On ajoute à notre tableau de résultat la lettre encodée
                    res[i] = _cesarTable[j, 1];
                }
                else
                {
                    res[i] = lineCode[i];
                }
                
            }
            
            //Convertion du tableau résultat en string avant retour
            return new string(res); 
        }

        public string DecryptCesarCode(string line)
        {
            char[] lineCode = line.ToUpper().ToCharArray();
            char[] res = new char[lineCode.Length];
            for (int i = 0; i < res.Length; i++)
            {
                int j = 0;
                for (; j < _cesarTable.GetLength(0); j++)
                {
                    if (_cesarTable[j, 1] == lineCode[i])
                    {
                        break;
                    }
                }
                if (j < _cesarTable.GetLength(0))
                {
                    res[i] = _cesarTable[j, 0];
                }
                else
                {
                    res[i] = lineCode[i];
                }

            }

            return new string(res);
        }

        public string GeneralCesarCode(string line, int x)
        {

            char[] lineCode = line.ToUpper().ToCharArray();
            char[] res = new char[lineCode.Length];

            for(int i = 0; i < res.Length; i++)
            {
                //Vérification que le code ascii du caractères est compris dans les codes ascii des lettres majuscules
                if(lineCode[i] >= 65 && lineCode[i] <= 90)
                {
                    res[i] = (char)(((lineCode[i] + x - 'A') % 26) + 'A');
                }
                else
                {
                    res[i] = lineCode[i];
                }
            }

            return new string(res);
        }

        public string GeneralDecryptCesarCode(string line, int x)
        {
            char[] lineCode = line.ToUpper().ToCharArray();
            char[] res = new char[lineCode.Length];

            for (int i = 0; i < res.Length; i++)
            {
                if (lineCode[i] >= 65 && lineCode[i] <= 90)
                {
                    res[i] = (char)((( lineCode[i] - x - 'A') % 26) + 'A');
                }
                else
                {
                    res[i] = lineCode[i];
                }
            }

            return new string(res);
        }
    }
}
