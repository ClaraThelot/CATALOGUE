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
using RechercheLibre;
using Rattachement;
using Ajout;

namespace Menu
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans votre application ! Aujourd'hui, si vous souhaitez faire une recherche, tapez 1");
            Console.WriteLine("Si vous souhaitez rajouter un projet, tapez 2");
            int choixUt = int.Parse(Console.ReadLine());
            if (choixUt==1)
            MenuRecherche();
            if (choixUt == 2) Ajout.Program.MenuAjout();
            RetourMenu();
        }
       
        static void RetourMenu()                                                //Permet de retourner au menu quand on veut
        {
            string[] arg= new string[0];
            Console.WriteLine("\r\n");
            Console.WriteLine("Vous voulez revenir au menu ? Tapez M !");
            if(Console.ReadLine()=="M")
            {
                Console.Clear();
                Main(arg);
            }
        }
 
        static bool MenuRecherche()
        {
            Console.WriteLine("Bienvenue sur votre application de recherche de projets de l'ENSC ! \nComment souhaitez-vous effectuer votre recherche ?\n");
            Console.WriteLine("Si vous voulez faire une recherche libre, tapez d'abord 1 sur votre clavier numérique !");
            Console.WriteLine("Si vous voulez parcourir les élèves, tapez 2");
            Console.WriteLine("Si vous voulez parcourir les intervenants extérieurs, tapez 3");
            Console.WriteLine("Si vous voulez parcourir les professeurs, tapez 4");
            Console.WriteLine("Si vous voulez parcourir les projets, tapez 5");// On va se limiter à ça pour l'instant
          
            switch (Console.ReadLine())
            {
                case "1":
                    RechercheLibre.Program.Recherche();
                    RetourMenu();
                    return false;
                
                case "2":
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                   List<Eleve> Eleves = new List<Eleve>();
                    Eleves = Rattachement.Program.RattacheEleve();
                    Console.WriteLine("Souhaitez-vous voir apparaître tous les élèves par ordre alphabétique ? Tapez 1 !"); // Il faut vraiment que je trouve comment on fait
                    Console.WriteLine("Ou par année ? (1A, 2A, 3A) Dans ce cas, tapez 2");
                    switch(Console.ReadLine())
                    {
                        case "1":
                            foreach(Eleve element in Eleves)
                            {
                                Console.Write(element._nom);
                                Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                            }
                           
                            int numero = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Eleve element in Eleves)
                            { if (numero == Eleves.IndexOf(element)) Console.WriteLine(element.ToString()); }
                            return true;
                        case "2":
                            Console.WriteLine("1A :");
                            foreach (Eleve element in Eleves)
                            {
                                if (element._annee == "1A")
                                {
                                    Console.Write(element._nom);
                                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                                }
                            }
                            Console.WriteLine("2A :");
                            foreach (Eleve element in Eleves)
                            {
                                if (element._annee == "2A")
                                {
                                    Console.Write(element._nom);
                                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                                }
                            }
                            Console.WriteLine("3A :");
                            foreach (Eleve element in Eleves)
                            {
                                if (element._annee == "3A")
                                {
                                    Console.Write(element._nom);
                                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element));
                                }
                            }
                            Console.WriteLine("Eleves ayant un autre statut :");
                            foreach (Eleve element in Eleves)
                            {
                                if (element._annee != "1A" && element._annee != "2A" && element._annee != "3A")
                                {
                                    Console.Write(element._nom);
                                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element) + "\r\n");
                                }
                            }
                            RetourMenu();
                            numero = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Eleve element in Eleves)
                            { if (numero == Eleves.IndexOf(element)) Console.WriteLine(element.ToString()); }
                            return true;
                        default: return false;
                    }
                    
                
                case "3":
                    Console.WriteLine("Voilà la liste des intervenants extérieurs répertoriés !");
                    List<Projet> Projet = new List<Projet>();
                    Projet = _InstanceProjet.Program.instancieProjet();
                    List<Exterieur> Exte = new List<Exterieur>();
                    Exte = Rattachement.Program.ConnexionExte();
                    foreach (Exterieur element in Exte)
                    {
                        Console.Write(element._nom);
                        Console.WriteLine("     Si vous voulez en savoir plus sur cet intervenant, tapez " + Exte.IndexOf(element));
                    }
                    string ligne = Console.ReadLine();
                    int numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                    foreach (Exterieur element in Exte)
                    {
   
                            if (numerochoisi == Exte.IndexOf(element)) Console.WriteLine(element.ToString());
                        
                    }
                    return true;

                
               case "4":
                    Console.WriteLine("Voici la liste des professeurs de l'école");
                    List<Professeur> prof = new List<Professeur>();
                    prof= Rattachement.Program.ConnexionProf();
                    foreach(Professeur element in prof)
                    {
                        Console.WriteLine(element.ToString());
                    }
                    RetourMenu();
                    return true;

  
                    
                   
                case "5":
                    List<Projet> Proj = new List<Projet>();
                    Proj = _InstanceProjet.Program.instancieProjet();
                    Console.WriteLine("Vous avez choisi d'afficher les projets ! Si vous voulez les voir s'afficher tous, tapez 1");
                    Console.WriteLine("Si vous voulez les voir s'afficher par promo, tapez 2");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            foreach (Projet element in Proj)
                            {
                                Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                            }
                      
                            numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Projet element in Proj)
                            {
                                if (numerochoisi == Proj.IndexOf(element)) { element.Affichage(element);

                                    
                                
                            }
                    }
                            return true;
                        case "2":
                            foreach (Projet element in Proj)
                            {
                                Console.WriteLine("Promo 2022 :");
                                if (element._chefprojet._promo == 2022)
                                {
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                }

                                else if (element._chefprojet._promo == 2021)
                                {
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                }


                                else if (element._chefprojet._promo == 2020)
                                {
                                    Console.WriteLine("Promo 2020 :");
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                }
                                else
                                {
                                    Console.WriteLine("Autres");
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                }
                            }
                            return true;
                        default: return false;
                    }
                default: return false;
            }
        }
    }
}
    

