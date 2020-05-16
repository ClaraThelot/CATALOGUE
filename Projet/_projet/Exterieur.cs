using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Exterieur : Personne
    {
        public string _metier { get; set; }
        public string _entreprise { get; set; }

        public Exterieur (string Nom, string Prenom, string Metier, string Entreprise) : base (Nom, Prenom) 
        {
            _metier = Metier;
            _entreprise = Entreprise;
        }

        public Exterieur(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

        public Exterieur(string Nom, string Prenom, List<Projet> Proj, string Metier, string Entreprise) : base(Nom, Prenom, Proj)
        {
            _metier = Metier;
            _entreprise = Entreprise;
        }
        
        public override string ToString()
        {
            string res = "";
            res = res + "Nom : " + _nom + "\n";
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Métier : " + _metier + "\n";
            res = res + "Lieu d'emploi en dehors de l'ENSC : " + _entreprise + "\n";
            res = res + "Liste des projets en cours : \n";
            int i = 0;
            foreach (Projet element in _projet)
            {
                res = res + "Projet n°" + (i+1) + " : " + element._nomProjet + "\n";
                i++;
            }

            return res;
        }
    }
}
