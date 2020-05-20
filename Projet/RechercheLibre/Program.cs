using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _AffichageListes;
using _InstancePersonne;
using _InstanceLivrable;
using _InstanceMatiere;
using _InstanceProjet;
using _InstanceRole;
using _projet;
using Rattachement;

namespace RechercheLibre
{
    public class Program
    {
        static void Main(string[] args)
        { }

      
        public static void Recherche()                                                              //Cette fonction permet de recherche un terme libre choisi par l'utilisateur
        {
            Console.WriteLine("Veuillez saisir ce que vous recherchez");
            string recherche = Console.ReadLine();
            List<Exterieur> Exte = new List<Exterieur>();           // On instancie chaque liste (ici, on commence par les intervenants extérieurs
            Exte = Rattachement.Program.ConnexionExte();                //On rattache les personnes extérieurs aux projets
            List<Professeur> Prof = new List<Professeur>();             //On procède de même pour chaque objet
            Prof = Rattachement.Program.ConnexionProf();
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Eleve> Eleves = new List<Eleve>();
            Eleves = Rattachement.Program.RattacheEleve();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet();                                    
            List<Livrable> Livrables = new List<Livrable>();
            Livrables = _InstanceMatiere.Program.instancieLivrable();
            
            if(recherche=="Eleves"||recherche=="Eleve")
            {
                _AffichageListes.Program.triAlpha(Eleves.ToList<Personne>());                       //Présente les élèves par ordre alphabétique
                int numero = int.Parse(Console.ReadLine());                                 // On convertit en un entier
                _AffichageListes.Program.Choixnum(numero, Eleves.ToList<Personne>());           
            }
            
            if(recherche=="Professeurs"||recherche=="Professeur")           //On effectue la même procédure pour les professeurs
            {
                Console.WriteLine("Voici la liste des professeurs de l'école");
                _AffichageListes.Program.triAlpha(Prof.ToList<Personne>());                                        
                int numerochoisiP = int.Parse(Console.ReadLine()); 
                _AffichageListes.Program.Choixnum(numerochoisiP, Prof.ToList<Personne>());
            }

            bool elevecherche = false; //Pour l'instant, nous permet de dire qu'aucun élément élève ne répond à la recherche
            List<Eleve> Echerché = new List<Eleve>(); // On crée une liste de tous les élèves concernés par la recherche
            
            foreach (Eleve element in Eleves)                                               //Recherche de l'élément dans la liste d'élèves
            {
                int nombre;
                if (int.TryParse(recherche, out nombre))                                            //Vérification pour voir si la conversion en int est possible
                {
                    if (int.Parse(recherche) == element._promo)
                    {
                        Echerché.Add(element);
                        elevecherche = true;
                    }
                }
                if (recherche.ToLower() == element._prenom.ToLower()|| recherche.ToLower() == element._nom.ToLower()||recherche.ToLower()== element._annee.ToLower())
                {
                    Echerché.Add(element);
                    elevecherche = true;
                }
            }
           

            foreach (Exterieur element in Exte)                                             // Recherche de l'élément de la liste d'extérieurs
            {
                if (recherche.ToLower() == element._nom.ToLower() || recherche.ToLower() ==element._prenom.ToLower() || recherche.ToLower() ==element._metier.ToLower() || recherche.ToLower() ==element._entreprise.ToLower()) element.Affiche();
            }

            foreach (Matiere element in Matieres)                                           // Recherche de l'élément dans les matières
            {   
                if (recherche.ToLower() == element._nom.ToLower() || recherche.ToLower() == element._code.ToLower()|| recherche.ToLower() == element._UE.ToLower())
                {
                    element.Affichage(element);
                    Console.WriteLine("Si vous voulez voir s'afficher les professeurs enseignant cette matière, tapez 1");
                    Console.WriteLine("Si vous voulez voir s'afficher les projets de cette matière, tapez 2");
                    int choix = int.Parse(Console.ReadLine());
                    if(choix==1)
                    {
                        List<Professeur> prof = _InstancePersonne.Program.instancieProfesseur();
                        foreach(Professeur p in prof)
                        {
                            foreach(Matiere m in p._matieres)
                            {
                                if (element._nom == m._nom) Console.WriteLine(p._nom);
                            }
                        }
                    }
                    if(choix==2)
                    {
                        List<Projet> Tousproj=_InstanceProjet.Program.instancieProjet();
                        foreach (Projet proj in Tousproj)
                        {
                            foreach(Matiere m in proj._matieres)
                            {
                                if (element._nom == m._nom) Console.WriteLine(proj._nomProjet + " (Chef de projet : " + proj._chefprojet._nom + ")");
                            }
                        }
                    }
                }
            }

            foreach (Professeur element in Prof) // Recherche de l'élément parmi les professeurs
            {
                if (recherche.ToLower() == element._nom.ToLower()|| recherche.ToLower() == element._prenom.ToLower()) element.Affiche();
            }

            foreach (Livrable element in Livrables)
            {
                if (recherche.ToLower() == element._type.ToLower() || recherche.ToLower() == element._echeance.ToLower())
                {
                    foreach(Projet proj in Projets)
                    {
                        if(proj._code==element._refprojet) Console.WriteLine("Le projet "+proj._nomProjet + " (Chef de projet : " + proj._chefprojet._nom + ")  doit rendre un(e) "+recherche+" pour le "+element._echeance);
                    }
                }
            }
            bool projcherche = false;
            List<Projet> Projcherche = new List<Projet>(); // Sur le même principe que pour les élèves, création d'une liste des projets concernés, que l'on affichera à la fin
            
            foreach (Projet element in Projets)
            {
                if (recherche.ToLower() == element._nomProjet.ToLower()) element.Affichage(element);
                
                double nombre;
                if (double.TryParse(recherche, out nombre))                        //Vérification pour voir si la conversion en int est possible
                {
                    if (double.Parse(recherche) == element._duree|| double.Parse(recherche) == element._note) element.Affichage(element);
                }

                if (recherche == "Sujet achevé" && element._sujetAcheve == true)
                {
                    Projcherche.Add(element);
                    projcherche = true;
                }

                if(recherche=="Sujet libre"&& element._sujetLibre==true)
                {
                    Projcherche.Add(element);
                    projcherche = true;
                }
            }

            if (elevecherche == true) // Si un ou plusieurs éléments d'Eleves appartiennent à la recherche
            {
                _AffichageListes.Program.triAlpha(Echerché.ToList<Personne>());  //On affiche les élèves concernés par la recherche                  
                int numerochoisi = int.Parse(Console.ReadLine());
                _AffichageListes.Program.Choixnum(numerochoisi, Echerché.ToList<Personne>());
            }
            
            if(projcherche==true) // Même principe pour les projets
            {
                foreach (Projet element in Projcherche)
                {
                    
                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Projcherche.IndexOf(element));
                    
                }
                int numerochoisip = int.Parse(Console.ReadLine());
                foreach (Projet element in Projcherche)
                {
                    if (numerochoisip == Projcherche.IndexOf(element)) element.Affichage(element);
                }
            }

        }
    }
}

