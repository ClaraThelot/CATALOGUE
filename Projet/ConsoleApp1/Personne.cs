using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Personne
    {
        public string _nom { get ;  }
        public string _prenom { get;  }
        public List<Projet> _projet { get; set; }

        public Personne()
        {
            _nom = "didier";
            _prenom = "didier";
        }
        public Personne(string Nom, string Prenom)
        {
            _nom = Nom;
            _prenom = Prenom;
        }

        public Personne(string Nom, string Prenom, List<Projet>Proj)
        {
            _nom = Nom;
            _prenom = Prenom;
            _projet = Proj;
        }
        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + _nom + "\n" ;
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Liste des projets en cours : \n";
            /*for (int i = 1; i < _projet.Length + 1; i++)
            {
                res = res + "Projet n°" + i + " : " + _projet[i - 1] + "/n";
            }*/

            return res;
        }
    }
}
