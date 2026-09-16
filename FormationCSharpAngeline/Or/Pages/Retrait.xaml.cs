using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour Retrait.xaml
    /// </summary>
    public partial class Retrait : PageFunction<long>
    {
        Carte CartePorteur { get; set; }
        Compte ComptePorteur { get; set; }
        public Retrait(long numCarte)
        {
            InitializeComponent();
            Montant.Text = 0M.ToString("C2");

            CartePorteur = SqlRequests.InfosCarte(numCarte);
            ComptePorteur = SqlRequests.ListeComptesAssociesCarte(CartePorteur.Id).Find(x => x.TypeDuCompte == TypeCompte.Courant);
            List<Transaction> transac = SqlRequests.ListeTransactionsAssociesCarte(numCarte);
            List<int> cpts = SqlRequests.ListeComptesAssociesCarte(numCarte).Select(x => x.Id).ToList();
            CartePorteur.AlimenterHistoriqueEtListeComptes(transac, cpts);

            PlafondMaxRetrait.Text = CartePorteur.Plafond.ToString("C2");
            PlafondRetraitActualise.Text = SoldeCarteActuel(DateTime.Now).ToString("C2");
            Solde.Text = ComptePorteur.Solde.ToString("C2");
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void ValiderRetrait_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Montant.Text.Replace(".", ",").Trim(new char[] { '€', ' ' }), out decimal montant) && montant > 0)
            {
                //Compte fictif pour permettre la transaction
                Compte compteBanque = new Compte(0, 0, TypeCompte.Courant, 0);
                Transaction t = new Transaction(0, DateTime.Now, montant, ComptePorteur.Id, compteBanque.Id);

                if (CartePorteur.EstOperationAutoriseeContraintesComptes(compteBanque, ComptePorteur))
                {
                    if(CartePorteur.EstEligibleMaximumRetraitHebdomadaire(t.Montant, t.Horodatage))
                    {
                        if (ComptePorteur.EstRetraitValide(t))
                        {
                            SqlRequests.EffectuerModificationOperationSimple(t, CartePorteur.Id);

                            OnReturn(null);
                        }
                        else
                        {
                            MessageBox.Show(Tools.Label(CodeResultat.SoldeInsuffisant));
                        }
                    }
                    else
                    {
                        MessageBox.Show(Tools.Label(CodeResultat.ErreurPlafond));
                    }                    
                }
                else
                {
                    MessageBox.Show(Tools.Label(CodeResultat.ErreurVirementLivret));
                }
            }
            else
            {
                MessageBox.Show(Tools.Label(CodeResultat.MontantInvalide));
            }
        }

        private decimal SoldeCarteActuel(DateTime date)
        {
            decimal cumulTransation = 0;

            foreach (Transaction tr in CartePorteur.Historique)
            {
                if ((date - tr.Horodatage).TotalDays <= 10)
                {
                    //Vérification qu'il s'agit bien d'une opération de retrait ou virement vers un autre compte
                    if(tr.Destinataire == 0 || !CartePorteur.ListComptesId.Contains(tr.Destinataire))
                    {
                        cumulTransation += tr.Montant;
                    }
                        
                }
            }

            return CartePorteur.Plafond - cumulTransation;

        }
    }
}
