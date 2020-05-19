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

      
        public static void Recherche()                                                              //Cette fonction permet de recherche un terme libre
        {
            Console.WriteLine("Veuillez saisir ce que vous recherchez");
            string recherche = Console.ReadLine();
            List<Exterieur> Exte = new List<Exterieur>();
            Exte = Rattachement.Program.ConnexionExte();                                            // Pareil avec les intervenants exté
            List<Professeur> Prof = new List<Professeur>();
            Prof = Rattachement.Program.ConnexionProf();
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Eleve> Eleves = new List<Eleve>();
            Eleves = Rattachement.Program.RattacheEleve();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet();                                    // On instancie la liste des projets.
            List<Livrable> Livrables = new List<Livrable>();
            Livrables = _InstanceLivrable.Program.instancieLivrable();

            
            foreach (Eleve element in Eleves)                                               //Rechercher l'élément dans la liste d'élèves
            {
                int nombre;
                if (int.TryParse(recherche, out nombre))                                            //Vérification pour voir si la conversion en int est possible
                {
                    if (int.Parse(recherche) == element._promo) element.Affiche();
                }
                if (recherche.ToLower() == element._prenom.ToLower()|| recherche.ToLower() == element._nom.ToLower()||recherche.ToLower()== element._annee.ToLower())
                {
                   element.Affiche();
                }
            }
            
            foreach (Exterieur element in Exte)                                             // Rechercher l'élément de la liste d'extérieurs
            {
                if (recherche.ToLower() == element._nom.ToLower() || recherche.ToLower() ==element._prenom.ToLower() || recherche.ToLower() ==element._metier.ToLower() || recherche.ToLower() ==element._entreprise.ToLower()) element.Affiche();
            }

            foreach (Matiere element in Matieres)                                           // Rechercher l'élément de matières
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

            foreach (Professeur element in Prof)
            {
                if (recherche.ToLower() == element._nom.ToLower()|| recherche.ToLower() == element._prenom.ToLower()) element.Affiche();
            }

            foreach (Livrable element in Livrables)
            {
                if (recherche.ToLower() == element._type.ToLower() || recherche.ToLower() == element._echeance.ToLower()) Console.WriteLine(element.ToString());
            }
            
            foreach (Projet element in Projets)
            {
                if (recherche.ToLower() == element._nomProjet.ToLower()) Console.WriteLine(element.ToString());
                
                double nombre;
                if (double.TryParse(recherche, out nombre))                        //Vérification pour voir si la conversion en int est possible
                {
                    if (double.Parse(recherche) == element._duree|| double.Parse(recherche) == element._note) Console.WriteLine(element.ToString());
                }
                
                // Pas sûre que ces deux paragraphes soient utiles
                if(recherche=="Sujet achevé"&& element._sujetAcheve==true) Console.WriteLine(element.ToString()); 
                if(recherche=="Sujet libre"&& element._sujetLibre==true) Console.WriteLine(element.ToString()); 
            }

        }
    }
}

