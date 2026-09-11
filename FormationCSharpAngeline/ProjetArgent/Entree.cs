using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public static class Entree
    {
        public static void Traitement()
        {
            Banque banque = new Banque();

            // Lecture du csv de carte
            lireCartes("../../cartes.csv", banque);
            lireComptes("../../comptes.csv", banque);
            lireTransaction("../../transactions.csv", banque);




        }

        public static void lireCartes(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {

                        string[] donneeCarte = l.Trim().Split(';');
                        if (donneeCarte[1] != "")
                        {
                            banque.AjoutCarte(donneeCarte[0], int.Parse(donneeCarte[1]));
                        }
                        else
                        {
                            banque.AjoutCarte(donneeCarte[0]);
                        }

                    }
                }
            }
        }

        public static void lireComptes(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {

                        string[] donneeCompte = l.Trim().Split(';');
                        if (donneeCompte[3] != "")
                        {
                            banque.AjoutCompte(int.Parse(donneeCompte[0]), long.Parse(donneeCompte[1]), 
                                                donneeCompte[2], int.Parse(donneeCompte[3]));
                        }
                        else
                        {
                            banque.AjoutCompte(int.Parse(donneeCompte[0]), long.Parse(donneeCompte[1]),
                                                donneeCompte[2]);
                        }

                    }
                }
            }
        }

        public static void lireTransaction(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {

                        string[] donneeTransaction = l.Trim().Split(';');
                        
                        banque.TraitementTransaction(int.Parse(donneeTransaction[0]), donneeTransaction[1],
                                                int.Parse(donneeTransaction[2]), int.Parse(donneeTransaction[3]), 
                                                int.Parse(donneeTransaction[4]));
                    }
                }
            }
        }
    }
}
