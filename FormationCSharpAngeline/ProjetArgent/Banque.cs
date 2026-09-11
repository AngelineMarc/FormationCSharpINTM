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
        }

        public void AjoutCompte(int id, long numCarte, string type, int solde = 0 )
        {
            if(id > 0 && solde >= 0 && (type.Equals("Livret") || type.Equals("Courant")))
            {
                Compte compte = new Compte(id, numCarte, type, solde);
                if (!compteList.Contains(compte))
                {
                    compteList.Add(compte);
                }
            }
        }

        public void AjoutCarte(string numero, int plafond = 500 )
        {
            if(numero.Length == 16 && long.TryParse(numero, out long num) && (plafond >= 500 && plafond <= 3000))
            {
                Carte carte = new Carte(num, plafond);
                if (!carteList.Contains(carte))
                {
                    carteList.Add(carte);
                }
            }
        }

        public bool VerificationTransaction(int id, string horodatage)
        {
            Regex reg = new Regex(@"(\d{2})/(\d{2})/(\d{4}) (\d{2}):(\d{2}):(\d{2})");
            if (reg.IsMatch(horodatage) && !transactionList.Contains(id))
            {
                transactionList.Add(id);
                return true;
            }
            return false;
        }

        public void TraitementTransaction(int id, string horodatage, int montant, int expediteur, int destinataire)
        {
            bool transactionOk = VerificationTransaction(id, horodatage);
            if (transactionOk)
            {
                DateTime horodatageDT = DateTime.ParseExact(horodatage, "dd/MM/yyyy HH:mm:ss", null);
                Transaction transaction = new Transaction(id, horodatageDT, montant, expediteur, destinataire);



            }
            
            Console.ReadKey();
        }
    }
}
