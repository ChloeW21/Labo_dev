using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliLabo
{
    class UtilisateurSingleton
    {
        // L’instance du singleton. Cette instance doit être privée et statique.
        private static UtilisateurSingleton instance = null;
        // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.
        private static readonly object myLock = new object();

        // La ressource ? partager.  
        private int id;
        private String pseudo;
        private String mdp;
        private String email;
        private int score;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public String Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Le constructeur d’un singleton est TOUJOURS privée. 
        private UtilisateurSingleton() { }

        // La méthode qui va nous permettre de récupérer l’unique instance de notre singleton.
        // La méthode doit être statique pour être appelé depuis le nom de la classe maClasse.getInstance();
        public static UtilisateurSingleton getInstance()
        {
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve.  
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock)
            {
                // Si on demande une instance qui n’existe pas, alors on crée notre RessourceManager.
                if (instance == null) instance = new UtilisateurSingleton();
                // Dans tous les cas on retourne l’unique instance de notre RessourceManager.
                return instance;
            }
        }

        public void killUtilisateur()
        {
            instance = null;
        }

        public void setValues(String pseudo, String email,String mdp)
        {
            Pseudo = pseudo;
            Email = email;
            Mdp = mdp;
            Score = score;
        }
    }
}
