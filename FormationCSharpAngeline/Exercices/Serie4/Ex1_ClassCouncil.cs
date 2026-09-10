using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie4
{
    public static class ClassCouncil
    {
        public static void SchoolMeans(string input, string output)
        {
            List<string> csvOutput = new List<string>();

            using (Stream s = new FileStream(input, FileMode.Open, FileAccess.Read))
            {
                using(StreamReader sr = new StreamReader(s))
                {
                    //Stockage des lignes du csv
                    List<string> line = sr.ReadToEnd().Split('\n').ToList();
                    List<string> matiere = new List<string>();

                    //Récupération de toutes les matières
                    foreach(string l in line)
                    {
                        matiere.Add(l.Split(';')[1]);
                    }

                    //Stockage de toutes les matières de manière unique
                    List<string> matiereUnique = matiere.Distinct().ToList();
                    
                    //Parcours des matières pour calcul de la moyenne
                    for (int i = 0; i < matiereUnique.Count; i++)
                    {
                        int cptEleve = 0;
                        float moyenne = 0;

                        //Parcours des lignes du csv d'entrée
                        for(int j =0; j < line.Count; j++)
                        {
                            //Nettoyage de la ligne
                            line[j] = line[j].Trim();
                            //Si la matière indiquée dans la ligne correspond à la matière traité
                            if (line[j].Split(';')[1] == matiereUnique[i].Split(';')[0])
                            {
                                //On ajout un élève ayant une moyenne dans la matière et on ajoute sa note dans la variable de moyenne totale
                                cptEleve++;
                                moyenne += float.Parse(line[j].Split(';')[2], CultureInfo.InvariantCulture);
                            }
                        }
                        //On ajoute a notre liste de sortie la matière et on calcul la moyenne générale
                        csvOutput.Add( matiereUnique[i]+";" + moyenne/cptEleve);

                    }
                }
            }

            //Ecriture de chaque ligne dans le csv de sortie
            using (Stream fs = new FileStream(output, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    foreach(string line in csvOutput)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
