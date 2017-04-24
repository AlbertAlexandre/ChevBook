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

namespace ChevBook
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private MainWindow MainWindow;
        public Connexion(MainWindow MainWindow)
        {
            InitializeComponent();

            this.MainWindow = MainWindow;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            UserBox.Clear();
            passwordBox.Clear();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {

            if (UserBox.Text == "admin" && passwordBox.Password == "admin")
            {
                this.MainWindow.MenuEtu.IsEnabled = true;
                this.Close();
            }
            else
                MessageBox.Show("identifiant ou mot de passe incorrect", "Erreur connexion", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
