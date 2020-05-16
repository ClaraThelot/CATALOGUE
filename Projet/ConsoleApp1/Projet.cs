using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Projet
    {
        private string _nomProjet { get; }
        private double _duree { get; set; }
        private bool _sujetLibre{ get; set; }
        private List<Eleve> _eleves { get; set; }
      /*  private List<Exterieur> _intervenants { get; set; }
        private List<Matiere> _matieres { get; set; }
        private List <Livrable> _livrables { get; set; }*/
        private Eleve _chefprojet { get; set; }
        private bool _sujetAcheve { get; set; }
        private double _note { get; set; }


        public Projet(string nom, double duree, bool sujetlibre, double note, bool sujetAcheve,  List<Eleve> eleves, Eleve chefprojet)
        {
            _nomProjet = nom;
            _duree = duree;
            _sujetLibre = sujetlibre;
            _eleves = eleves;
            _chefprojet = chefprojet;
            _sujetAcheve = sujetAcheve;
            _note = note;
        }
        /*public Projet(string nom, double duree, bool sujetlibre, double note, bool sujetAcheve, List<Livrable> livrables, List<Eleve> eleves, List<Exterieur> intervenants, List<Matiere> matieres, Eleve chefprojet)
        {
            _livrables = livrables;
            _nomProjet = nom;
            _duree = duree;
            _sujetLibre = sujetlibre;
            _eleves = eleves;
            _intervenants = intervenants;
            _matieres = matieres;
            _chefprojet = chefprojet;
            _sujetAcheve = sujetAcheve;
            _note = note;
        }*/
        public void ajoutEleve (Eleve E1)
        {
            int counter = 0;
            foreach(Eleve element in _eleves)
            {
                if(element!=null)
                {_eleves[counter] = E1; } //Si le tableau n'est pas vide, on ajoute un l'élève considéré 
                counter++;
            }
        }
        public void supprimeEleve(Eleve E1)
        {
            int counter = 0;
            foreach (Eleve element in _eleves)
            { if (element == E1) { _eleves[counter] = null; }
                counter++;
            } // Supprime un élève, par contre laisse un trou dans le tableau à l'endroit considéré
        }

        /*public void ajoutMatiere(Matiere M1)
        {
            int counter = 0;
            foreach(Matiere element in _matieres)
            {
                if (element != null) { _matieres[counter] = M1; }
                counter++;
            }

        }
      
       public void supprimeMatiere(Matiere M1)
        {
            int counter = 0;
            foreach(Matiere element in _matieres)
            { if (element == M1) _matieres[counter] = null;
                counter++;
            } 
        }

   
        public void ajoutIntervenant(Exterieur Ex1)
        {
            int counter = 0;
            foreach(Exterieur element in _intervenants)
            {
                if (element != null) { _intervenants[counter] = Ex1;
                    counter++;
                }
            }
        }

        public void supprimeIntervenant(Exterieur Ex1)
        {
            int counter = 0;
            foreach(Personne element in _intervenants)
            { if (element == Ex1) _intervenants[counter] = null;
                counter++;
            }
        }

        public void ajoutLivrable(Livrable L1)
        {
            int counter = 0;
            foreach (Livrable element in _livrables)
            {
                if (element != null)
                {
                    _livrables[counter] = L1;
                    counter++;
                }
            }
        }

        public void supprimeLivrable(Livrable L1)
        {
            int counter = 0;
            foreach (Livrable element in _livrables)
            {
                if (element == L1) _livrables[counter] = null;
                counter++;
            }
        }

        public override string ToString()
        {
            string res = "";
            res = res + "Nom du projet : " + _nomProjet + "\n";
            res = res + "Durée du projet :" + _duree + "\n";
            if (_sujetLibre == true) res = res + "Sujet libre \n";
            else { res = res + "Sujet imposé \n"; }
            res = res + "Elèves participants : \n";
            foreach (Eleve element in _eleves)
            { res = res + element.ToString() + "\n"; }
            res = res + "Intervenants : \n ";
            foreach (Exterieur element in _intervenants)
            { res=res+ element.ToString() + "\n"; }
            res = res + "Matières concernées : \n";
            foreach (Matiere element in _matieres)
            { res = res + element.ToString() + "\n"; }
            res = res + "Chef de Projet :" + _chefprojet + "\n";
            if (_sujetAcheve == true) res = res + "Statut du projet : achevé \n";
            else { res = res + "Statut du sujet : en cours \n "; }
            res = res + "Sujet Achevé : " + _sujetAcheve + "\n";
            if (_sujetAcheve == true) res = res + "Note : " + _note + "\n";
            return res;
        }*/

    }
}
