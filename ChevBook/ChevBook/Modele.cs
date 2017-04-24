using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
namespace ChevBook
{
    public class Modele
    {
        public MySqlConnection myConnection;   
        private bool connopen = false;
        private bool errgrave = false;
        private bool chargement = false;

        public void seconnecter()
        {
            
            string myConnectionString = "Database=chevloc_bdd;Data Source=193.70.13.58;User Id=chevloc;Password=Azerty123;";
            myConnection = new MySqlConnection(myConnectionString);
        
            try // tentative 
            {
                myConnection.Open();
                connopen = true;
                //MessageBox.Show("La connexion s'est correctement effectuée", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception err)// gestion des erreurs
            {
                MessageBox.Show("Erreur ouverture BD ChevBook : " + err, "PBS connection", MessageBoxButton.OK, MessageBoxImage.Error);
                connopen = false; errgrave = true;
            }
        }
        public void Requete(string query)
        {
            this.seconnecter();
            MySqlCommand cmd = new MySqlCommand(query, this.myConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            this.myConnection.Close();
        }

        public MySqlDataReader Requete2(string query)
        {
            this.seconnecter();
            MySqlCommand cmd = new MySqlCommand(query, this.myConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

    }
}
