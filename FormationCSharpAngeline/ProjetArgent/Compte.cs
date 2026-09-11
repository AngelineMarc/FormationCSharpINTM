using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    public class Compte
    {
        private int Identifiant { get; set; }
        private long NumCarte { get; set; }
        private string Type { get; set; }
        private int Solde { get; set; }

        public Compte(int identifiant, long numCarte, string type, int solde)
        {
            Identifiant = identifiant;
            NumCarte = numCarte;
            Type = type;
            Solde = solde;
        }

        public bool depot(int montant)
        {
            if(montant > 0)
            {
                Solde += montant;
                return true;
            }
            return false;
        }

        public bool retrait(int montant)
        {
            //TODO : vérifier le plafond max pas atteint
            if(montant > Solde)
            {
                Solde -= montant;
            }

            return false;
        }
    }
}
