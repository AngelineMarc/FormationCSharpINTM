using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie3
{
    public static class AdministrativeTasks
    {
        public static string EliminateSeditiousThoughts(string text, string[] prohibitedTerms)
        {
            string textRes = text;
            Console.Write("Censure des mots suivants : ");
            foreach (string str in prohibitedTerms)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Texte d'entrée :");
            Console.WriteLine(text);

            foreach (string mot in prohibitedTerms)
            {
                if (textRes.Contains(mot))
                {
                    string xxx = string.Concat(Enumerable.Repeat("X", mot.Length));
                    textRes = textRes.Replace(mot, xxx);

                }
            }

            return textRes;
        }

        public static bool ControlFormat(string line)
        {
            // Vérification que la ligne fait exactement 33 caractères
            if (line.Length != 33)
            {
                return false;
            }

            string civilité = line.Substring(0, 4);
            string nom = line.Substring(5, 12).Trim(' ');
            string prenom = line.Substring(18, 12).Trim(' ');
            string age = line.Substring(31, 2);

            bool res = true;
            //Vérification de la civilité
            if (!civilité.Contains("M.") && !civilité.Contains("Mme") && !civilité.Contains("Mlle"))
            {
                res = false;
            }
            //Vérification que le nom et prénom ne contient que des caractères alphabétique
            else if (!nom.All(c => char.IsLetter(c)) || !prenom.All(c => char.IsLetter(c)))
            {
                
                res = false;
            }
            //Vérification que l'age ne contient que des caractères numérique
            else if(!age.All(c => char.IsDigit(c)))
            {
                res = false;
            }
            //Vérification qu'aucun caratère ne soit dans les séparateurs d'informations (et donc que la ligne soit décalé
            else if (line.Substring(4,1) != " " || line.Substring(17, 1) != " " || line.Substring(30, 1) != " ")
            {
                res = false;
            }
            return res;
        }

        public static string ChangeDate(string report)
        {
            string reportRes = report;
            Regex reg = new Regex(@"\d{4}-\d{2}-\d{2}");
            
            //Récupération de toutes les occurences du regex dans une collection
            MatchCollection mat = reg.Matches(reportRes);

            //Pour toute les occurences, on découpe les données selon le caractère '-' et on reforme la date dans le bon format
            foreach (Match m in mat)
            {
                string[] dateAme = m.ToString().Split('-');
                string dateOk = $"{dateAme[2]}.{dateAme[1]}.{dateAme[0].Substring(2, 2)}";
                reportRes = reportRes.Replace(m.ToString(), dateOk);
            }

            return reportRes;
        }
    }
}
