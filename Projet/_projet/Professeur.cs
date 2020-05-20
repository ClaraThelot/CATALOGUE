using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Professeur : Personne, IAppartenance
    {
        public List<Matiere> _matieres { get; set; }                                                       // J'ai temporairement enlevé le fait que c'est un tableau

        public Professeur(string Nom, string Prenom, List<Matiere> Matieres) : base(Nom, Prenom) 
        {
            _matieres = Matieres;
        }
        
        public Professeur(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) 
        {
            _matieres = new List<Matiere>();
        }

        public Professeur(string Nom, string Prenom, List<Projet> Proj, List<Matiere> Matiere) : base(Nom, Prenom, Proj)
        {
            _matieres = Matiere;
        }

        public void ajoutMatiere(Matiere M1)
        {
            _matieres.Add(M1);
        }
        public override void Affiche()
        {
            string res = "";
            res = res + "Nom : " + _nom + "\n";
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Liste des matières enseignées : ";
            int comptemat = 0;
            foreach(Matiere element in _matieres)
            {
                res = res + "Matière n°" + (comptemat + 1) + " : " + element._nom + "\n";
                comptemat++;
            }
            res = res + "\nListe des projets en cours : \n";
            int i = 0;
            foreach (Projet element in _projet)
            {
                res = res + "Projet n°" + (i + 1) + " : " + element._nomProjet + "\n     Si vous voulez en savoir plus sur ce projet, tapez " + _projet.IndexOf(element) + "\n";
                i++;
            }
            Console.WriteLine(res);

            int numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
            foreach (Projet element2 in _projet)
            {
                if (numerochoisi == _projet.IndexOf(element2)) element2.Affichage(element2);
            }

            
        }
        public static Object conversion(Professeur e)
        {
            Object o = e as Object;
            return o;
        }
        public bool Appartenir(List<object> liste, string entree)
        {
            int occur = 0;
            foreach (Professeur element in liste)
            {
                if (element._nom == entree)occur++;
            }
            if (occur == 0)return false; 
            else return true; 
        }

    }
}
