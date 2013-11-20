using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS
{
    class Utilisateur
    {
        public Utilisateur(int id, String pseudo, String mdp, int score)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.mdp = mdp;
            this.score = score;
        }

        private int id;
        private String pseudo;
        private String mdp;
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
    }
}
