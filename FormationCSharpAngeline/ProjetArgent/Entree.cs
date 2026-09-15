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

            // Lecture des csv
            lireCartes("../../cartes.csv", banque);
            lireComptes("../../comptes.csv", banque);

            //Set de Test minimal, résultat attendu : 1;KO, 2;OK, 3;KO, 4;KO, 5;OK, 6;KO, 7;OK
            lireTransaction("../../transactions.csv", banque);

            //Test du plafond selon les dates, résultat attendu : 1;OK, 2;OK , 3;KO, 4;OK, 5;OK, 6;KO, 7;OK, 8;OK
            //lireTransaction("../../transactionsPlafond.csv", banque);

            //Test avec différents montants, à la fois négatifs ou supérieurs au solde, résultat attendu : tout KO
            //lireTransaction("../../transactionsMontant.csv", banque);

            //Test sur les différents types de compte, résultat attendu : 1;OK, 2;KO, 3;OK
            //lireTransaction("../../transactionsType.csv", banque);

            Console.WriteLine("Traitement terminé");
            Console.ReadKey();

        }

        /// <summary>
        /// Méthode de lecture du fichier de cartes
        /// </summary>
        /// <param name="path"> chemin d'accès au fichier</param>
        /// <param name="banque"> banque associée </param>
        public static void lireCartes(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    //Séparation des lignes
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {
                        //séparation des données sur le ;
                        string[] donneeCarte = l.Trim().Split(';');

                        //Le plafond peut ne pas etre indiqué 
                        if (donneeCarte[1] != "" )
                        {
                            //Essaie de parser le plafond en int, sinon on ignore
                            if(int.TryParse(donneeCarte[1], out int plafond))
                            {
                                banque.AjoutCarte(donneeCarte[0], plafond);
                            }
                            
                        }
                        else
                        {
                            banque.AjoutCarte(donneeCarte[0]);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Méthode de lecture du fichier de comptes
        /// </summary>
        /// <param name="path"> chemin d'accès au fichier</param>
        /// <param name="banque"> banque associée </param>
        public static void lireComptes(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {

                        string[] donneeCompte = l.Trim().Split(';');
                        //Le solde peut ne pas être indiqué
                        if (donneeCompte[3] != "" )
                        {
                            //Parse de l'id, du numéro de carte et du solde
                            if(int.TryParse(donneeCompte[0], out int id) && long.TryParse(donneeCompte[1], out long numCarte)
                                    && int.TryParse(donneeCompte[3], out int solde))
                            {
                                banque.AjoutCompte(id, numCarte, donneeCompte[2], solde);
                            }
                            
                        }
                        else
                        {
                            if(int.TryParse(donneeCompte[0], out int id) && long.TryParse(donneeCompte[1], out long numCarte))
                            {
                                banque.AjoutCompte(id, numCarte, donneeCompte[2]);
                            }
                            
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Méthode de lecture du fichier de transaction et traitement de celle-ci ligne par ligne
        /// </summary>
        /// <param name="path"> chemin d'accès au fichier</param>
        /// <param name="banque"> banque associée </param>
        public static void lireTransaction(string path, Banque banque)
        {
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    //Parcours et traitement des transactions une par une
                    foreach (string l in sr.ReadToEnd().Split('\n'))
                    {

                        string[] donneeTransaction = l.Trim().Split(';');

                        //Parse de l'id, du montant, de l'expéditeur et du destinataire
                        if (int.TryParse(donneeTransaction[0], out int id) && int.TryParse(donneeTransaction[2], out int montant)
                                && int.TryParse(donneeTransaction[3], out int expediteur) 
                                && int.TryParse(donneeTransaction[4], out int destinataire))
                            banque.TraitementTransaction(id, donneeTransaction[1], montant, expediteur, destinataire);
                    }
                }
            }
        }
    }
}
