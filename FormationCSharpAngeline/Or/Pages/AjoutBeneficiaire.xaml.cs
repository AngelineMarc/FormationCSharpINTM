using Or.Business;
using Or.Models;
using System.Windows;
using System.Windows.Navigation;

namespace Or.Pages
{
    /// <summary>
    /// Logique d'interaction pour AjoutBeneficiaire.xaml
    /// </summary>
    public partial class AjoutBeneficiaire : PageFunction<long>
    {
        private Carte c;
        public AjoutBeneficiaire(long numCarte)
        {
            InitializeComponent();

            c = SqlRequests.InfosCarte(numCarte);
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void Ajout_Beneficiaire(object sender, RoutedEventArgs e)
        {
            
            if (SqlRequests.EstBeneficiairePotentiel(int.Parse(CptBeneficiaire.Text), c.Id))
            {
                SqlRequests.AjoutBenefciaire(long.Parse(c.Id.ToString()), int.Parse(CptBeneficiaire.Text));
                OnReturn(null);
            }
            else
            {
                MessageBox.Show(Tools.Label(CodeResultat.ErreurBeneficiaire));
            }
            
            
        }
    }
}
