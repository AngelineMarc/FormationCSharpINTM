using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Transaction
    {
        private int NumTransaction { get; set; }
        private DateTime Horodatage { get; set; }
        private int Montant { get; set; }
        private int Expediteur { get; set; }
        private int Destinataire { get; set; }


        public Transaction(int numTransaction, DateTime horodatage, int montant, int expediteur, int destinataire)
        {
            NumTransaction = numTransaction;
            Horodatage = horodatage;
            Montant = montant;
            Expediteur = expediteur;
            Destinataire = destinataire;

        }
    }
}
