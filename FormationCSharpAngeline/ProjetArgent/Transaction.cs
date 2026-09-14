using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Transaction
    {
        public int NumTransaction { get; set; }
        public DateTime Horodatage { get; set; }
        public int Montant { get; set; }
        public int Expediteur { get; set; }
        public int Destinataire { get; set; }


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
