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
    /// Logique d'interaction pour Beneficiaires.xaml
    /// </summary>
    public partial class Beneficiaires : PageFunction<long>
    {
        public Beneficiaires(long numCarte)
        {
            InitializeComponent();

            Carte c = SqlRequests.InfosCarte(numCarte);

            Numero.Text = c.Id.ToString();
            Prenom.Text = c.PrenomClient;
            Nom.Text = c.NomClient;

            List<Compte> comptes = SqlRequests.ListeBenefciairesAssocieClient(numCarte);
            List<Tuple<Compte, Carte>> beneficiaires = new List<Tuple<Compte, Carte>>();
            foreach (Compte cpt in comptes)
            {
                beneficiaires.Add(new Tuple<Compte, Carte>(cpt, SqlRequests.InfosCarte(cpt.IdentifiantCarte)));
            }

            listView.ItemsSource = beneficiaires;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }

        private void Ajouter_Beneficiaire(object sender, RoutedEventArgs e)
        {
            PageFunctionNavigate(new AjoutBeneficiaire(long.Parse(Numero.Text)));
        }

        private void Supprimer_Beneficiare(object sender, RoutedEventArgs e)
        {
            SqlRequests.SuppressionBenefciaire(long.Parse(Numero.Text), (int)(sender as Button).CommandParameter);
            List<Compte> comptes = SqlRequests.ListeBenefciairesAssocieClient(long.Parse(Numero.Text));

            listView.ItemsSource = comptes;
        }

        void PageFunctionNavigate(PageFunction<long> page)
        {
            page.Return += new ReturnEventHandler<long>(PageFunction_Return);
            NavigationService.Navigate(page);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<long> e)
        {
            listView.ItemsSource = SqlRequests.ListeBenefciairesAssocieClient(long.Parse(Numero.Text));
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridView gridView = listView.View as GridView;
            if (gridView != null)
            {
                double totalWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
                gridView.Columns[0].Width = totalWidth * 0.10; // 10%
                gridView.Columns[1].Width = totalWidth * 0.30; // 40%
                gridView.Columns[2].Width = totalWidth * 0.30; // 20%
                gridView.Columns[3].Width = totalWidth * 0.30; // 20%
            }
        }
    }
}
