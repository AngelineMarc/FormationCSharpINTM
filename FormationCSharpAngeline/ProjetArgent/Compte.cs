using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Compte
    {
        public int Identifiant { get; set; }
        public long NumCarte { get; set; }
        public string Type { get; set; }
        public int Solde { get; set; }

        public Compte(int identifiant, long numCarte, string type, int solde)
        {
            Identifiant = identifiant;
            NumCarte = numCarte;
            Type = type;
            Solde = solde;
        }

        /// <summary>
        /// Méthode permettant de faire un dépot
        /// </summary>
        /// <param name="montant"> montant du dépot, doit être strictement positif</param>
        /// <returns>retourne si l'opération s'est bien passée</returns>
        public bool depot(int montant)
        {
            if(montant > 0)
            {
                Solde += montant;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Méthode permettant de faire un retrait
        /// </summary>
        /// <param name="montant">montant du retrait, doit être strictement positif et supérieur au solde</param>
        /// <returns>retourne si l'opération s'est bien passée</returns>
        public bool retrait(int montant)
        {
            if( Solde >= montant && montant > 0)
            {
                Solde -= montant;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Méthode permettant de faire un virement
        /// </summary>
        /// <param name="montant">montant du virement, doit être strictement positif et supérieur au solde</param>
        /// <returns>retourne si l'opération s'est bien passée</returns>
        public bool virement(int montant)
        {
            if(montant > 0 && Solde >= montant)
            {
                Solde -= montant;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Méthode permettant de faire un prélévement, avec vérification que l'expéditeur peut faire le virement associé
        /// </summary>
        /// <param name="montant">montant du prelevement, doit etre strictement positif</param>
        /// <param name="expediteur">expediteur associé au prélévement</param>
        /// <returns>retourne si l'opération s'est bien passée</returns>
        public bool prelevement(int montant, Compte expediteur)
        {
            if(montant > 0)
            {
                //L'expéditeur essaie de faire le virement
                bool virementOk = expediteur.virement(montant);

                //S'il s'est bien passé, le destinateur peut faire le prélévement
                if (virementOk)
                {
                    Solde += montant;
                    return true;
                }
            }
            

            return false;
        }
    }
}
