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
    /// Logique d'interaction pour Logements.xaml
    /// </summary>
    public partial class Logements : Window
    {
        private Modele Modele = new Modele();
        private String[] TabLog;
        private string query;

        public Logements()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            query = "Select ADR_LOG, CODEPOSTAL_LOG, VILLE_LOG, SURFACE_LOG, NoAPPARTEMENT From logement";
            MySqlDataReader reader = Modele.Requete2(query);
            while (reader.Read())
            {
                listBoxLog.Items.Add(reader["ADR_LOG"].ToString() + "-" + reader["VILLE_LOG"].ToString() + "-" + reader["CODEPOSTAL_LOG"].ToString() + "-" + reader["NoAPPARTEMENT"].ToString());
            }
            this.Modele.myConnection.Close();


        }

        private void LogQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listBoxLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string LogADR = listBoxLog.SelectedItem.ToString();

                Char delemiter = '-';
                TabLog = LogADR.Split(delemiter);
            }
            catch (Exception ex) { }
        }

        private void Log_Modif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModifLog M = new ModifLog(TabLog[0], TabLog[1], TabLog[2], TabLog[3]);
                M.Show();
            }
            catch (Exception ex) { MessageBox.Show("Veuillez selectionner un logement", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }
    }
}
