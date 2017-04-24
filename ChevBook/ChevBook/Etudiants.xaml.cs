using ChevBook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace ChevBook
{
    /// <summary>
    /// Logique d'interaction pour Etudiants.xaml
    /// </summary>
    public partial class Etudiants : Window
    {
        private Modele Modele = new Modele();
        private String[] TabNomPrenom;
        private string query;
        public Etudiants()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            query = "Select ID_ETU, NOM_ETU, PRENOM_ETU, MAIL_ETU, TEL_ETU, LOGIN_ETU, PASSWORD_ETU From etudiant";
            MySqlDataReader reader = Modele.Requete2(query);
            while (reader.Read())
            {
                LBEtu.Items.Add(reader["NOM_ETU"].ToString() + " " + reader["PRENOM_ETU"].ToString());
            }
            this.Modele.myConnection.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (LBEtu.SelectedItem != null)
            {
                #region suppression
                MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer " + TabNomPrenom[0] + " " + TabNomPrenom[1] + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    query = "DELETE FROM etudiant WHERE NOM_ETU = '" + TabNomPrenom[0] + "' AND PRENOM_ETU = '" + TabNomPrenom[1] + "';";
                    Modele.Requete(query);
                    LBEtu.Items.Remove(LBEtu.SelectedItem);
                    MessageBox.Show("L'étudiant " + TabNomPrenom[0] + " " + TabNomPrenom[1] + " a été suprimmé(e)", "Supression réussi", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                #endregion             

            }
            else
                MessageBox.Show("veuillez selectionner un nom", "Erreur selection", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void LBEtu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string NomPrenom = LBEtu.SelectedItem.ToString();
            
                Char delemiter = ' ';
                TabNomPrenom = NomPrenom.Split(delemiter);
            }catch(Exception ex) { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modifier M = new Modifier(TabNomPrenom[0], TabNomPrenom[1]);
                M.Show();
            }catch(Exception ex) { MessageBox.Show("Veuillez selectionner un étudiant", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }
    }
}
