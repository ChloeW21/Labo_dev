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
        private static int casError = 0;

        public Connexion(MainWindow main)
        {
            this.main = main; 
            InitializeComponent();
        }

        public Boolean Authentification(string pseudo, string mdp)
        {
            MySqlCommand maCommande = main.getCommand();
            string req = "SELECT * FROM  `utilisateur` WHERE `pseudo` = ?pseudo and `mdp`=?mdp";
            maCommande.Parameters.AddWithValue("?pseudo", pseudo);
            maCommande.Parameters.AddWithValue("?mdp", mdp);
            maCommande.CommandText = req;
            return maCommande.ExecuteScalar() != null;
        }

        private void buttonConnexion_Click(object sender, RoutedEventArgs e)
        {
            if(Authentification(textBoxLogin.Text,passwordBoxMdp.Password)){
                String email=main.getMailUtilisateur(textBoxLogin.Text);
                UtilisateurSingleton.getInstance().setValues (textBoxLogin.Text,email,passwordBoxMdp.Password);
                main.frame.NavigationService.Navigate(new Accueil(main));
            }
            else
                textBoxLogin.Text="Authentification raté" ;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonInscription_Click(object sender, RoutedEventArgs e)
        {
            if (verifFormulaire())
            {
                MySqlCommand maCommande = main.getCommand();
                string req = "Insert into `utilisateur` (`pseudo`, `mdp`, `score`,`email`) values (?pseudo ,?mdp,0,?email);";
                maCommande.Parameters.AddWithValue("?pseudo", textBoxPseudo.Text);
                maCommande.Parameters.AddWithValue("?mdp", passwordBoxMdp.Password);
                maCommande.Parameters.AddWithValue("?email", textBoxEmail.Text);
                maCommande.CommandText = req;
                maCommande.ExecuteNonQuery();
                UtilisateurSingleton.getInstance().setValues(textBoxPseudo.Text, textBoxEmail.Text, passwordBoxMdp.Password);
                main.frame.NavigationService.Navigate(new Accueil(main));
            }

        }

        public Boolean VerifLogin(string pseudo)
        {
            if (pseudo != "")
            {
                MySqlCommand maCommande = main.getCommand();
                string req = "SELECT * FROM  `utilisateur` WHERE `pseudo` = ?pseudo";
                maCommande.Parameters.AddWithValue("?pseudo", pseudo);
                maCommande.CommandText = req;
                if (maCommande.ExecuteScalar() != null)
                {
                    casError = 4;
                    return false;
                }
                return true;
            }
            casError = 1;
            return false;
        }


        public Boolean VerifMdp(string mdp, string mdpValidate)
        {
            if (mdp != "" && mdpValidate != "")
            {
                if (mdp != mdpValidate)
                {
                    casError = 5;
                    return false;
                }
                return true;
            }
            casError = 2;
            return false;
        }


        public Boolean VerifEmail(string email)
        {
            if (email != "")
            {
                MySqlCommand maCommande = main.getCommand();
                string req = "SELECT * FROM  `utilisateur` WHERE `email` = ?email";
                maCommande.Parameters.AddWithValue("?email", email);
                maCommande.CommandText = req;
                if (maCommande.ExecuteScalar() != null)
                {
                    casError = 6;
                    return false;
                }
                return true;
            }
            casError = 3;
            return false;
        }

        public Boolean verifFormulaire()
        {
            if (VerifLogin(textBoxPseudo.Text))
                if (VerifEmail(textBoxEmail.Text))
                    if (VerifMdp(passwordBoxMdp.Password, passwordBoxMdpValide.Password))
                    {
                        casError = 0;
                        setErreur();
                        return true;
                    }
            setErreur();
            return false;
        }


        public void setErreur()
        {
            switch (casError)
            {
                case 0:
                    textBlockError.Text = "";
                    break;
                case 1:
                    textBlockError.Text = "Champ identifiant vide";
                    textBoxPseudo.Focus();
                    break;
                case 2:
                    textBlockError.Text = "Le ou les champs mot de passe sont vides";
                    passwordBoxMdp.Focus();
                    break;
                case 3:
                    textBlockError.Text = "Le champ email est vide";
                    textBoxEmail.Focus();
                    break;
                case 4:
                    textBlockError.Text = "Le login existe déjà dans la base de données";
                    textBoxPseudo.Focus();
                    break;
                case 5:
                    textBlockError.Text = "Les mots de passene correspondent pas";
                    passwordBoxMdp.Focus();
                    break;
                case 6:
                    textBlockError.Text = "L'email existe déjà dans la base de données";
                    textBoxEmail.Focus();
                    break;

            }
        }
    }
}
