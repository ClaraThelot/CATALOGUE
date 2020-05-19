using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{

        public class Eleve : Personne, IAffichable, IAppartenance
        {
            public string _annee { get; set; }
            public int _promo { get; set; }
            public int _groupeTD { get; set; }
            public Eleve() { }

            public Eleve(string Nom, string Prenom, string annee, int promo, int groupeTD) : base(Nom, Prenom)
            {
                _annee = annee;
                _promo = promo;
                _groupeTD = groupeTD;
            }

            public Eleve(string Nom, string Prenom, List<Projet> Proj) : base(Nom, Prenom, Proj) { }

            public Eleve(string Nom, string Prenom, List<Projet> Proj, string Annee, int Promo, int Groupe) : base(Nom, Prenom, Proj)
            {
                _annee = Annee;
                _promo = Promo;
                _groupeTD = Groupe;
            }
        public bool Appartenir(List<object> liste, string entree)
        {
            int occur = 0;
            foreach (Eleve element in liste)
            {
                if (element._nom == entree)
                {
                    occur++;
                }
            }
            if (occur == 0)
            { return false; }
            else
            { return true; }
        }


        public void supprimeProjet(Projet P1)
            {
                int i = 0;
                int place = 0;
                foreach (Projet element in _projet)
                {
                    if (_projet[i] == P1) { place = i; }
                    i++;
                }
                _projet[place] = null;
            }

            public override void  Affiche()
            {
                string res = "";
                res = res + "Nom : " + _nom + "\n";
                res = res + "Prénom : " + _prenom + "\n";
                res = res + "Année : " + _annee + "\n";
                res = res + "Promo " + _promo + "\n";
                res = res + "Groupe de TD : " + _groupeTD + "\n";
                res = res + "Liste des projets en cours : \n";
                int i = 0;
                foreach (Projet element in _projet)
                {
                    res = res + "Projet n°" + (i+1) + " : " + element._nomProjet + "\n     Si vous voulez en savoir plus sur ce projet, tapez " + _projet.IndexOf(element) + "\n";
                    i++;
                }
            Console.WriteLine(res);

            int numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
            foreach (Projet element2 in _projet)
           {
                if (numerochoisi == _projet.IndexOf(element2)) element2.Affichage(element2);
            }


        }
        public static Object conversion(Eleve e)
        {
            Object o = e as Object;
            return o;
        }

        public bool Appartenir(List<Eleve> liste, string entree)
        {
            int occur = 0;
            foreach (Eleve element in liste)
            {
                if (element._nom == entree)
                {
                    occur++;
                }
            }
            if (occur == 0)
            { return false; }
            else
            { return true; }
        }

    }
    }

