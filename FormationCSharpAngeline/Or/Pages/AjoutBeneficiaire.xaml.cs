using Or.Business;
using Or.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
