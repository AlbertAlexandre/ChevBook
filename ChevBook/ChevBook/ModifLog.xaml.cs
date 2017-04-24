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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ChevBook
{
    /// <summary>
    /// Logique d'interaction pour ModifLog.xaml
    /// </summary>
    public partial class ModifLog : Window
    {
        private Modele Modele = new Modele();
        private string Adresse;
        private string CodeP;
        private string Ville;
        private string Numapp;
        private string query;
        public ModifLog(string adresse, string ville, string codeP,  string numapp)
        {
            Adresse = adresse;
            CodeP = codeP;
            Ville = ville;
            Numapp = numapp;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            query = "Select ADR_LOG, NoAPPARTEMENT, CODEPOSTAL_LOG, VILLE_LOG, SURFACE_LOG, PRIX_LOG, CHARGE_LOG, CHAUFFAGE_LOG, DESCRIPTION_LOG, NOMPROPRIO_LOG, TELPROPRIO_LOG, EMAILPROPRIO_LOG From logement WHERE ADR_LOG = '" + Adresse + "' AND CODEPOSTAL_LOG = '" + CodeP + "' AND VILLE_LOG = '" + Ville + "'AND NoAPPARTEMENT = '" + Numapp + "'";
            MySqlDataReader reader = Modele.Requete2(query);
            reader.Read();
            textBoxADR.Text = reader["ADR_LOG"].ToString();
            textBoxNumAP.Text = reader["NoAPPARTEMENT"].ToString();
            textBoxCP.Text = reader["CODEPOSTAL_LOG"].ToString();
            textBoxVille.Text = reader["VILLE_LOG"].ToString();
            textBoxSurface.Text = reader["SURFACE_LOG"].ToString();
            textBoxPrix.Text = reader["PRIX_LOG"].ToString();
            textBoxCharge.Text = reader["CHARGE_LOG"].ToString();
            textBoxChauffage.Text = reader["CHAUFFAGE_LOG"].ToString();
            textBoxDescrip.Text = reader["DESCRIPTION_LOG"].ToString();
            textBoxNomP.Text = reader["NOMPROPRIO_LOG"].ToString();
            textBoxTelP.Text = reader["TELPROPRIO_LOG"].ToString();
            textBoxEmailP.Text = reader["EMAILPROPRIO_LOG"].ToString();
            this.Modele.myConnection.Close();
        }

        private void ModifLogOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxSurface.Text != "" && textBoxNumAP.Text != "" && textBoxCP.Text !="")
            {
                query = "UPDATE logement SET ADR_LOG = '" + textBoxADR.Text + "',NoAPPARTEMENT = '" + textBoxNumAP.Text + "',CODEPOSTAL_LOG = '" + textBoxCP.Text + "',VILLE_LOG = '" + textBoxVille.Text + "', SURFACE_LOG = '" + textBoxSurface.Text + "', PRIX_LOG = '" + textBoxPrix.Text + "', CHARGE_LOG = '" + textBoxCharge.Text + "', CHAUFFAGE_LOG = '" + textBoxChauffage.Text + "', DESCRIPTION_LOG= '" + textBoxDescrip.Text + "', NOMPROPRIO_LOG = '" + textBoxNomP.Text + "', TELPROPRIO_LOG = '" + textBoxTelP.Text + "',EMAILPROPRIO_LOG ='" + textBoxEmailP.Text + "'";
                MySqlDataReader reader = Modele.Requete2(query);
                this.Modele.myConnection.Close();
                MessageBox.Show("Le logement à bien été modifié", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ModifLogQuitter_Click(object sender, RoutedEventArgs e)
        {
          this.Close();
        }
    }
}
