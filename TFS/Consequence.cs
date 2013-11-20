using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS
{
    class Consequence
    {
        public Consequence(int id, int idDefi, int idUser, String nom, String texte)
        {
            this.id = id;
            this.idDefi = idDefi;
            this.idUser = idUser;
            this.nom = nom;
            this.texte = texte;
        }

        private int id;
        private int idDefi;
        private int idUser;
        private String nom;
        private String texte;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdDefi
        {
            get { return idDefi; }
            set { idDefi = value; }
        }

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public String Texte
        {
            get { return texte; }
            set { texte = value; }
        }
    }
}
