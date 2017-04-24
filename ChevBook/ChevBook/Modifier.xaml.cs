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
using System.Text.RegularExpressions;
using System.Globalization;

namespace ChevBook
{
    /// <summary>
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Window
    {
        private Modele Modele = new Modele();
        private string query;
        private string Nom;
        private string Prenom;

        public Modifier(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            query = "Select DATENAISSANCE_ETU, NOM_ETU, PRENOM_ETU, MAIL_ETU, TEL_ETU, LOGIN_ETU, PASSWORD_ETU From etudiant WHERE NOM_ETU = '" + Nom + "' AND PRENOM_ETU = '" + Prenom + "'";
            MySqlDataReader reader = Modele.Requete2(query);
            reader.Read();
            tb_Nom.Text = reader["NOM_ETU"].ToString();
            tb_Prenom.Text = reader["PRENOM_ETU"].ToString();
            tb_Date.Text = reader["DATENAISSANCE_ETU"].ToString();
            tb_Mail.Text = reader["MAIL_ETU"].ToString();
            tb_Tel.Text = reader["TEL_ETU"].ToString();
            tb_Log.Text = reader["LOGIN_ETU"].ToString();
            tb_Pass.Text = reader["PASSWORD_ETU"].ToString();
            this.Modele.myConnection.Close();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            if (ValidEmail(tb_Mail.Text) == true || tb_Mail.Text == "")
            {
                if (DateTime.TryParseExact(tb_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || tb_Date.Text == "")
                {
                    if (tb_Tel.Text.Length == 10 || tb_Tel.Text == "")
                    {
                        query = "UPDATE etudiant SET DATENAISSANCE_ETU = '" + tb_Date.Text + "', NOM_ETU = '" + tb_Nom.Text + "', PRENOM_ETU = '" + tb_Prenom.Text + "', MAIL_ETU = '" + tb_Mail.Text + "', TEL_ETU = '" + tb_Tel.Text + "', LOGIN_ETU = '" + tb_Log.Text + "', PASSWORD_ETU = '" + tb_Pass.Text + "' WHERE NOM_ETU = '" + Nom + "' AND PRENOM_ETU = '" + Prenom + "'";
                        MySqlDataReader reader = Modele.Requete2(query);
                        this.Modele.myConnection.Close();
                        MessageBox.Show("L'élève à bien été modifié", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    MessageBox.Show("Numéro de téléphone incorrect", "Erreur Numéro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    

                }
                else
                 MessageBox.Show("Date incorrect (Veuillez respecter la format (dd/MM/yyyy)", "Erreur date", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                

            }
            else
            MessageBox.Show("Courriel incorrect", "Erreur courriel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            
        }


        private void tb_Tel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void tb_Nom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void tb_Prenom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
        public static bool ValidEmail(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }


    }
}
