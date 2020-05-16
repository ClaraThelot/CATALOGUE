using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _projet
{
    public class Personne : IAffichable
    {

        public string _nom { get; }
        public string _prenom { get; }
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
            _projet = new List<Projet>();
        }

        public Personne(string Nom, string Prenom, List<Projet> Proj)
        {
            _nom = Nom;
            _prenom = Prenom;
            _projet = Proj;
        }
        public override string ToString()
        {
            string res = " ";
            res = res + "Nom : " + _nom + "\n";
            res = res + "Prénom : " + _prenom + "\n";
            res = res + "Liste des projets en cours : \n";
            int i = 0;
            foreach (Projet element in _projet)
            {
                res = res + "Projet n°" + i + " : " + element._nomProjet + "/n";
                i++;
            }

            return res;
        }

        public void Affichage(object obj)
        {
            Console.WriteLine("Si vous souhaitez afficher le détail, tapez 1");
            string s = (Console.ReadLine());
            if (s == "1") Console.WriteLine(obj.ToString());
        }
        public void ajoutProjet(Projet P1)
        {
            _projet.Add(P1);
        }

        public void AffichageDepuisListe(object obj, List<object> List)
        {
            int numero = int.Parse(Console.ReadLine());
           if (numero == 1) Console.WriteLine(obj.ToString());
        }
    }

}

    
    

