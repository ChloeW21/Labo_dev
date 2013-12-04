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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AppliLabo
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        private MainWindow main; 

        public Connexion(MainWindow main)
        {
            this.main = main; 
            InitializeComponent();
        }

        public Boolean Authentification(string Nom, string mdp)
        {
            MySqlCommand maCommande = main.getCommand();
            string req = "SELECT * FROM  `utilisateur` WHERE `pseudo` = ?login and `mdp`=?Mdp";
            maCommande.Parameters.AddWithValue("?login", Nom);
            maCommande.Parameters.AddWithValue("?Mdp", mdp);
            maCommande.CommandText = req;
            return maCommande.ExecuteScalar() != null;
        }

        private void buttonValidate_Click(object sender, RoutedEventArgs e)
        {
            if(Authentification(textBoxLogin.Text,passwordBoxMdp.Password)){
                textBoxLogin.Text="Coucou" ; 
            }
            else
                textBoxLogin.Text="Raté" ;
        }
    }
}
