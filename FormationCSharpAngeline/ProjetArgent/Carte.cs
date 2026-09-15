using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    internal class Carte
    {
        public long Numero { get; set; }
        public int Plafond { get; set; }
        public List<Transaction> Historique { get; set; }

        public List<int> numComptes;

        public Carte(long numero, int plafond)
        {
            Numero = numero;
            Plafond = plafond;
            Historique = new List<Transaction>();
            numComptes= new List<int>();
        }

        /// <summary>
        /// Méthode permettant de vérifier si le plafond a été atteint pour la transaction actuelle
        /// </summary>
        /// <param name="transaction">transaction en cours de traitement</param>
        /// <returns></returns>
        public bool verificationPlafond(Transaction transaction)
        {
            int cumulTransation = 0;

            //Parcours de toutes les transactions de l'historique
            foreach(Transaction tr in Historique)
            {
                // Si la transaction de l'historique est datée de moins de 10 jours par rapport à l'actuelle
                if((transaction.Horodatage - tr.Horodatage).TotalDays <= 10)
                {
                    // S'il s'agissait d'un retrait d'argent ou d'un virement
                    if(tr.Destinataire == 0 || numComptes.Contains(tr.Expediteur))
                    {
                        //On ajoute le montant au cumul
                        cumulTransation += tr.Montant;
                    }
                }
            }

            //Si le montant de la transaction actuelle ajoutée au cumul est inférieur ou égale au plafond, l'opération peut avoir lieu
            if (cumulTransation + transaction.Montant <= Plafond)
            {
                return true;
            }

            return false;
        }
    }
}
