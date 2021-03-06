﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _projet
{
    public class Exterieur : Personne, IAppartenance
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
        
        public override void Affiche()
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
        public static Object conversion(Exterieur e)
        {
            Object o = e as Object;
            return o;
        }
        public bool Appartenir(List<object> liste, string entree)
        {
            int occur = 0;
            foreach (Exterieur element in liste)
            {
                if (element._nom == entree) occur++;
            }
            if (occur == 0) return false; 
            else
             return true; 
        }

    }
}
