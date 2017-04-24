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
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;


namespace ChevBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string query;
        private Modele Modele = new Modele();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Logements L = new Logements();
            L.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Etudiants E = new Etudiants();
            E.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Connexion C = new Connexion(this);
            C.Show();
        }

        private void MenuExporter_Click(object sender, RoutedEventArgs e)
        {
            /*string fileName = @"W:\PPE\PPE 2eme année\PPE4\Exemple_de_Listes_modif.xlsx";
            string sheetname = "Exemple_de_Listes";
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(@"W:\PPE\PPE 2eme année\PPE4\Exemple_de_Listes_modif.xlsx");
            wb.SaveAs(@"W:\testcsv.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);
            wb.Close();
            app.Quit();*/

            query = "LOAD DATA LOCAL INFILE 'W:/PPE/PPE 2eme année/PPE4/Liste_Formalise.csv' INTO TABLE chevloc_bdd.etudiant FIELDS TERMINATED BY ';'ENCLOSED BY ''LINES TERMINATED BY '\r\n';";

            Modele.Requete(query);

            MessageBox.Show("export réussi");
        }
    }
}
