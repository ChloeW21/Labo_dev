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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Connexion(this));
        }

        public static MySqlConnection Connection()
        {
            return new MySqlConnection("Data Source=localhost;Initial Catalog=tfs;User Id=root ;Password=;");
        }

        public MySqlCommand getCommand()
        {
            MySqlConnection maConnection = Connection();
            maConnection.Open();
            MySqlCommand maCommande = new MySqlCommand();
            maCommande.Connection = maConnection;
            return maCommande;
        }

        public string getMailUtilisateur(string pseudo)
        {
            MySqlCommand maCommande = getCommand();
            string req = "Select `email` from `utilisateur` WHERE `pseudo`= ?pseudo;";
            maCommande.Parameters.AddWithValue("?pseudo", pseudo);
            maCommande.CommandText = req;
            MySqlDataReader reader = maCommande.ExecuteReader();
            string email = null;
            while (reader.Read())
            {
                email = reader["email"].ToString();
            }
            return email;
        }
    }
}
