﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
     public class Projet : IAffichable
    {
        public string _nomProjet { get; }
        public double _duree { get; set; }
        public bool _sujetLibre{ get; set; }
        public List<Eleve> _eleves { get; set; }
        public List<Exterieur> _intervenants { get; set; }
        public List<Matiere> _matieres { get; set; }
        public List <Livrable> _livrables { get; set; }
        public List<Professeur> _professeurs { get; set; }
        public Eleve _chefprojet { get; set; }
        public bool _sujetAcheve { get; set; }
        public double _note { get; set; }
        public string _code { get; set; }



        public Projet(){}
        public Projet(string nom)
        {
            _nomProjet = nom;
            _code = "";
            _duree = 0;
            _sujetLibre = false;
            _note = 0;
            _sujetAcheve = false;
            _livrables = new List<Livrable>();
            _eleves = new List<Eleve>();
            _intervenants = new List<Exterieur>();
            _professeurs = new List<Professeur>();
            _matieres = new List<Matiere>();
            _chefprojet = new Eleve();
        }
        public Projet(string code,string nom, double duree, bool sujetlibre, double note, bool sujetAcheve, List<Livrable> livrables, List<Eleve> eleves, List<Exterieur> intervenants,List<Professeur> profs, List<Matiere> matieres, Eleve chefprojet)
        {
            _code = code;
            _livrables = livrables;
            _nomProjet = nom;
            _duree = duree;
            _sujetLibre = sujetlibre;
            _eleves = eleves;
            _intervenants = intervenants;
            _professeurs = profs;
            _matieres = matieres;
            _chefprojet = chefprojet;
            _sujetAcheve = sujetAcheve;
            _note = note;
        }
        
        public override string ToString()
        {
            string res = "";
            res = res + "Nom du projet : " + _nomProjet + "\n";
            res = res + "Durée du projet :" + _duree + "mois\n";
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
            if (_sujetAcheve == true)
            {
                res = res + "Statut du projet : achevé \n";
                res = res + "Note : " + _note + "\n";
            }
            else { res = res + "Statut du sujet : en cours \n "; }
            res = res + "Sujet Achevé : " + _sujetAcheve + "\n";
            return res;
        }

        public void Affichage(object obj)
        {
            Console.WriteLine("Nom du projet: " + _nomProjet + "\n");
            Console.WriteLine("Durée du projet : " + _duree + " mois \n");
            if (_sujetLibre == true) Console.WriteLine("Sujet imposé" + "\r\n");
            Console.WriteLine("Eleves participant : ");
            foreach (Eleve element in _eleves)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez 0" + _eleves.IndexOf(element));
            }
            Console.WriteLine("\r\n");
            Console.WriteLine("Intervenants participant : ");
            foreach (Exterieur element in _intervenants)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez 1" + _intervenants.IndexOf(element));
            }
            Console.WriteLine("\r\n");
            Console.WriteLine("Professeurs intervenants : \n");
            foreach (Professeur element in _professeurs)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez 2" + _professeurs.IndexOf(element));
            }
            Console.WriteLine("\r\nDétail des rôles de chacun des intervenants");
            Role.RattacheRole(_code);

            Console.WriteLine(" \r\nMatières concernées :");
            foreach (Matiere element in _matieres)
            { Console.WriteLine(element._nom); }
            Console.WriteLine("\r\n");
            Console.WriteLine("Chef de projet : " + _chefprojet._nom + "     Si vous voulez en savoir plus sur cet élève, tapez 0" + _eleves.IndexOf(_chefprojet));
            Console.WriteLine("Les livrables sont les suivants : ");
            foreach (Livrable element in _livrables)
            {
                Console.WriteLine(element._type + " (" + element._echeance + ")");
            }
            Console.WriteLine("\n");
            if (_sujetAcheve == true)
            {
                Console.WriteLine("Statut du projet : achevé");
                Console.WriteLine("Note : " + _note);
            }
            else { Console.WriteLine("Statut du sujet : en cours"); }

            Console.WriteLine("Pour revenir au menu, appuyer sur M !");
            string saisienum = Console.ReadLine();
            if (saisienum == "M")
            { }
            else
            {
                string determiner = saisienum.Substring(0, 1);
                saisienum = saisienum.Substring(1);
                int numerochoisi = int.Parse(saisienum);

                if (determiner == "0")
                {
                    foreach (Eleve element in _eleves)
                    { if (numerochoisi == _eleves.IndexOf(element)) element.Affiche(); }
                }

                else
                {
                    if (determiner == "1")
                    {
                        foreach (Exterieur element in _intervenants)
                        { if (numerochoisi == _intervenants.IndexOf(element)) element.Affiche(); }
                    }
                    else
                    {
                        if (determiner == "2")
                        {
                            foreach (Professeur element in _professeurs)
                            {
                                if (numerochoisi == _professeurs.IndexOf(element)) element.Affiche();
                            }
                        }

                        else Console.WriteLine("Désolée, nous ne pouvons afficher cela, vous avez du faire une erreur !");
                    }
                }

            }
        }

        
    }
}
