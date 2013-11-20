using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS
{
    class Defi
    {
        public Defi(int id, String nom, String texte, String image)
        {
            this.id = id;
            this.nom = nom;
            this.texte = texte;
            this.image = image;
        }

        private int id;
        private String nom;
        private String texte;
        private String image;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public String Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
