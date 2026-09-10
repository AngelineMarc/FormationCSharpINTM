using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie3
{
    public class Morse
    {
        private const string Taah = "===";
        private const string Ti = "=";
        private const string Point = ".";
        private const string PointLetter = "...";
        private const string PointWord = ".....";

        private readonly Dictionary<string, char> _alphabet;

        public Morse()
        {
            _alphabet = new Dictionary<string, char>()
            {
                {$"{Ti}.{Taah}", 'A'},
                {$"{Taah}.{Ti}.{Ti}.{Ti}", 'B'},
                {$"{Taah}.{Ti}.{Taah}.{Ti}", 'C'},
                {$"{Taah}.{Ti}.{Ti}", 'D'},
                {$"{Ti}", 'E'},
                {$"{Ti}.{Ti}.{Taah}.{Ti}", 'F'},
                {$"{Taah}.{Taah}.{Ti}", 'G'},
                {$"{Ti}.{Ti}.{Ti}.{Ti}", 'H'},
                {$"{Ti}.{Ti}", 'I'},
                {$"{Ti}.{Taah}.{Taah}.{Taah}", 'J'},
                {$"{Taah}.{Ti}.{Taah}", 'K'},
                {$"{Ti}.{Taah}.{Ti}.{Ti}", 'L'},
                {$"{Taah}.{Taah}", 'M'},
                {$"{Taah}.{Ti}", 'N'},
                {$"{Taah}.{Taah}.{Taah}", 'O'},
                {$"{Ti}.{Taah}.{Taah}.{Ti}", 'P'},
                {$"{Taah}.{Taah}.{Ti}.{Taah}", 'Q'},
                {$"{Ti}.{Taah}.{Ti}", 'R'},
                {$"{Ti}.{Ti}.{Ti}", 'S'},
                {$"{Taah}", 'T'},
                {$"{Ti}.{Ti}.{Taah}", 'U'},
                {$"{Ti}.{Ti}.{Ti}.{Taah}", 'V'},
                {$"{Ti}.{Taah}.{Taah}", 'W'},
                {$"{Taah}.{Ti}.{Ti}.{Taah}", 'X'},
                {$"{Taah}.{Ti}.{Taah}.{Taah}", 'Y'},
                {$"{Taah}.{Taah}.{Ti}.{Ti}", 'Z'},
            };
        }

        public int LettersCount(string code)
        {
            //On sépare la chaine de caratère selon les patern "....." ou "..."
            string[] str = Regex.Split(code, @"(?:\.\.\.\.\.|\.\.\.)");

            return str.Length;
        }

        public int WordsCount(string code)
        {
            string[] str = Regex.Split(code, @"(?:\.\.\.\.\.)");
            return str.Length;
        }

        public string MorseTranslation(string code)
        {
            string codeTrad = "";

            //Parcours de tout le code pour etre sur de sa validité
            for(int i = 0; i< code.Length; i++)
            {
                if (code[i] != '=' && code[i] != '.')
                {
                    throw new ArgumentException("Le code contient des caractères non valide");
                }
            }


            //Parcours des mots du code morse
            foreach(string mot in Regex.Split(code, @"(?:\.\.\.\.\.)"))
            {
                //Parcours des lettres d'un mot
                foreach(string lettre in Regex.Split(mot, @"(?:\.\.\.)"))
                {
                    //Ajout à la string finale la traduction stockée dans le dictionnaire
                    if (_alphabet.ContainsKey(lettre))
                    {
                        codeTrad += _alphabet[lettre].ToString();
                    }
                    else
                    {
                        codeTrad += "+";
                    }
                    
                }
                codeTrad += " ";
            }

            return codeTrad;
        }

        public string EfficientMorseTranslation(string code)
        {
            string codeTrad = "";
            //Nettoyage de la chaine pour les séparations entre impulsion
            for(int i = 0; i < code.Length - 2; i++)
            {
                if (code[i] == '.' && code[i+1] == '.' && code[i+2] != '.' && code[i-1] != '.')
                {
                    code = code.Remove(i, 2);
                    code = code.Insert(i, ".");
                }
            }

            //Un mot est séparé par 5 point ou plus
            foreach (string mot in Regex.Split(code, @"(?:\.{5,})"))
            {
                //Parcours des lettres d'un mot, une lettre est séparée par 3 ou 4 points
                foreach (string lettre in Regex.Split(mot, @"(?:\.{3,4})"))
                {
                    //Ajout à la string finale la traduction stockée dans le dictionnaire
                    if (_alphabet.ContainsKey(lettre))
                    {
                        codeTrad += _alphabet[lettre].ToString();
                    } 
                    //Si la lettre n'est pas dans l'alphabet et est différente de vide, il s'agit d'une lettre inconnue
                    else if (lettre != "")
                    {
                        codeTrad += "+";
                    }

                }
                if (mot != "")
                {
                    codeTrad += " ";
                }
                
            }

            return codeTrad;
        }

        public string MorseEncryption(string sentence)
        {
            string codeMorse =  "";
            sentence = sentence.ToUpper();

            //Parcours des lettres de la phrase
            foreach(char lettre in sentence)
            {
                //Parcours du dictionnaire
                foreach(KeyValuePair<string, char> item in _alphabet)
                {
                    
                    //Si la lettre correspond à celle du dictionnaire, on ajoute le code morse correspondant au résultat
                    if (item.Value == lettre)
                    {
                        codeMorse += item.Key;
                        break;
                    }
                }

                //Si on traite un lettre, on ajoute le séparateur en 3 points
                if (lettre != ' ')
                {
                    codeMorse += "...";
                }
                //Sinon on rajoute un séparateur en 2 points qui se rajoute aux 3 points pour séparer 2 mots 
                else
                {
                    codeMorse += "..";
                }

            }
            return codeMorse;
        }
    }
}
