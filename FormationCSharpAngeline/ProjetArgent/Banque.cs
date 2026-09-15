using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Banque
    {
        private List<Compte> compteList;
        private List<Carte> carteList;
        private List<int> transactionList;

        public Banque()
        {
            compteList = new List<Compte>();
            carteList = new List<Carte>();
            transactionList = new List<int>();
            Sortie.initSorite();
        }

        /// <summary>
        /// Méthode de création d'un compte et ajout à la liste
        /// </summary>
        /// <param name="id"> identification unique d'un compte</param>
        /// <param name="numCarte">numéro de la carte associée au compte, la carte doit déjà exister</param>
        /// <param name="type">type du compte créé, peut etre soit "Livret", soit "Courant"</param>
        /// <param name="solde"> solde du compte, paramètre optionnel, doit etre positif</param>
        public void AjoutCompte(int id, long numCarte, string type, int solde = 0 )
        {
            if(id > 0 && solde >= 0 && (type.Equals("Livret") || type.Equals("Courant")))
            {
                Compte compte = new Compte(id, numCarte, type, solde);

                //Vérification si le compte est déjà existant, si ce n'est pas le cas on peut le créer
                Compte compteExistant = (from item in compteList where item.Identifiant == id select item).FirstOrDefault();
                if (compteExistant == null)
                {
                    //Vérification de l'existence de la carte et création du compte associé, sinon création impossible
                    Carte carte = (from item in carteList where item.Numero == compte.NumCarte select item).FirstOrDefault();
                    if(carte != null)
                    {
                        compteList.Add(compte);
                        carte.numComptes.Add(compte.Identifiant);
                    }
                }
            }
        }

        /// <summary>
        /// Méthode de création d'une carte et ajout de celle-ci à la liste
        /// </summary>
        /// <param name="numero"> Numéro unique de la carte, doit être de longueur 16 et composée de chiffre uniquement</param>
        /// <param name="plafond">plafond de la carte, doit etre compris entre 500 et 3000, paramètre optionnel</param>
        public void AjoutCarte(string numero, int plafond = 500 )
        {
            if(numero.Length == 16 && long.TryParse(numero, out long num) && (plafond >= 500 && plafond <= 3000))
            {
                Carte carte = new Carte(num, plafond);
                Carte carteExistant = (from item in carteList where item.Numero == num select item).FirstOrDefault();
                if (carteExistant == null)
                {
                    carteList.Add(carte);
                }
            }
        }

        /// <summary>
        /// Méthode de vérification du formatage d'une transaction et ajout de l'id à la liste des transactions
        /// </summary>
        /// <param name="id"> identifiant unique de la transaction</param>
        /// <param name="horodatage"> horodatage de la transaction</param>
        /// <returns></returns>
        public bool VerificationTransaction(int id, string horodatage)
        {
            //Vérification que la date est bien formatée en dd/dd/dddd dd:dd:dd
            Regex reg = new Regex(@"(\d{2})/(\d{2})/(\d{4}) (\d{2}):(\d{2}):(\d{2})");
            if (reg.IsMatch(horodatage) && !transactionList.Contains(id))
            {
                transactionList.Add(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Traitement des différentes transactions, envoie les opérations de compte associées et ecriture en sortie du statut de la transaction
        /// </summary>
        /// <param name="id">identifiant de la transaction</param>
        /// <param name="horodatage">horodatage de la transaction</param>
        /// <param name="montant">montant de la transaction</param>
        /// <param name="expediteur">expediteur de la transaction</param>
        /// <param name="destinataire">destinataire de la transaction</param>
        public void TraitementTransaction(int id, string horodatage, int montant, int expediteur, int destinataire)
        {
            bool transactionOk = VerificationTransaction(id, horodatage);


            if (transactionOk)
            {
                bool operationOk = false;
                //Mise en forme de la date et création de la transaction
                DateTime horodatageDT = DateTime.ParseExact(horodatage, "dd/MM/yyyy HH:mm:ss", null);
                Transaction transaction = new Transaction(id, horodatageDT, montant, expediteur, destinataire);

                //Récupération des entités compte destinataire et expéditeur
                Compte cptdes = (from item in compteList where item.Identifiant == transaction.Destinataire select item).FirstOrDefault();
                Compte cptexp = (from item in compteList where item.Identifiant == transaction.Expediteur select item).FirstOrDefault();

                //Si l'expéditeur est 0 et que le compte destination existe, il s'agit d'un dépôt d'argent sur le compte destinataire
                if (transaction.Expediteur == 0 && cptdes != null)
                {
                    operationOk = cptdes.depot(transaction.Montant);

                    //Si l'opération se passe bien, on ajoute la transaction à l'historique de la carte
                    if (operationOk)
                    {
                        Carte carte = (from item in carteList where item.Numero == cptdes.NumCarte select item).FirstOrDefault();
                        carte.Historique.Add(transaction);
                    }

                }
                //Si le destinataire est 0 et que le compte expéditeur existe, il s'agit d'un retrait d'argent sur le compte expediteur
                else if(transaction.Destinataire == 0 && cptexp != null)
                {
                    Carte carte = (from item in carteList where item.Numero == cptexp.NumCarte select item).FirstOrDefault();

                    //Vérification que le plafond ne sera pas dépassé
                    if (carte.verificationPlafond(transaction))
                    {
                        operationOk = cptexp.retrait(transaction.Montant);
                        if (operationOk)
                        {
                            carte.Historique.Add(transaction);
                        }
                    }
                    
                }
                //Sinon il s'agit d'une demande de prelevement/virement
                else
                {
                    //Les deux comptes doivent être existants, si les numéros de carte correspondent ou que les 2 comptes sont des comptes courants
                    if(cptdes != null && cptexp != null && 
                        (cptdes.NumCarte == cptexp.NumCarte || (cptdes.Type == "Courant" && cptexp.Type == "Courant")))
                    {
                        //Récupération des cartes associées
                        Carte cartedest = (from item in carteList where item.Numero == cptdes.NumCarte select item).FirstOrDefault();
                        Carte carteexp = (from item in carteList where item.Numero == cptdes.NumCarte select item).FirstOrDefault();

                        if (carteexp.verificationPlafond(transaction))
                        {
                            operationOk = cptdes.prelevement(transaction.Montant, cptexp);
                            if (operationOk)
                            {
                                //Ajout de la transaction sur la carte du compte expéditeur
                                carteexp.Historique.Add(transaction);

                                //S'il ne s'agissait pas d'une opération  entre compte d'une meme carte
                                if (cptdes.NumCarte != cptexp.NumCarte)
                                {
                                    //ajout de la transaction sur la carte du compte destination
                                    cartedest.Historique.Add(transaction);
                                }
                            }
                        }
                    }
                }

                //Ecriture en sortie du statut de la transaction
                if (operationOk)
                {
                    Sortie.ecrireSortie(id, "OK");
                }
                else
                {
                    Sortie.ecrireSortie(id, "KO");
                }
            }   
        }
    }
}
