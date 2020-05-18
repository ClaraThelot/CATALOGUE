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
using Verification;

namespace Menu
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans votre application ! Aujourd'hui, si vous souhaitez faire une recherche, tapez 1");
            Console.WriteLine("Si vous souhaitez rajouter un projet, tapez 2");
            int choixUt = int.Parse(Console.ReadLine());
            if (choixUt==1) MenuRecherche();
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
            Console.WriteLine("Bienvenue sur votre application de recherche de projets de l'ENSC ! \n Quel filtre souhaitez-vous ajouter à votre recherche ?\n");
            Console.WriteLine("Si vous voulez faire une recherche libre, tapez d'abord 1 sur votre clavier numérique !");
            Console.WriteLine("Si vous voulez parcourir les projets selon les élèves, tapez 2");
            Console.WriteLine("Si vous voulez parcourir les projets selon les intervenants extérieurs, tapez 3");
            Console.WriteLine("Si vous voulez parcourir les projets selon les professeurs, tapez 4");
            Console.WriteLine("Si vous voulez parcourir les projets selon les matières, tapez 5");
            Console.WriteLine("Si vous voulez simplement parcourir les projets, tapez 6");
            List<string> possible = new List<string>();
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
                    possible.Add("1");
                    possible.Add("2");
                    string entree3 = Console.ReadLine();
                    bool verification3 = Verification.Program.Verification(entree3, possible);
                    if (verification3 == true)
                    {
                        List<string> choisir = new List<string>();
                        switch (entree3)
                        {
                            case "1":
                                _AffichageListes.Program.triAlpha(Eleves.ToList<Personne>());
                                int numero = int.Parse(Console.ReadLine()); // On convertit en un entier
                                _AffichageListes.Program.Choixnum(numero, Eleves.ToList<Personne>());
                                return true;
                            case "2":
                                _AffichageListes.Program.AfficheParAn("1A", Eleves);
                                _AffichageListes.Program.AfficheParAn("2A", Eleves);
                                _AffichageListes.Program.AfficheParAn("3A", Eleves);
                                Console.WriteLine("Eleves ayant un autre statut :");
                                foreach (Eleve element in Eleves)
                                {
                                    if (element._annee != "1A" && element._annee != "2A" && element._annee != "3A")
                                    {
                                        Console.Write(element._nom);
                                        Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + Eleves.IndexOf(element) + "\r\n");
                                    }
                                    string pos = Convert.ToString(Eleves.IndexOf(element));
                                    choisir.Add(pos);
                                }
                                string entree4 = Console.ReadLine();
                                bool verification4 = Verification.Program.Verification(entree4, choisir);
                                    if (verification4 == true)
                                { numero = int.Parse(entree4); // On convertit en un entier
                                    _AffichageListes.Program.Choixnum(numero, Eleves.ToList<Personne>());
                                    return true; }
                                    else
                                { return false; }
                            default: return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    
                
                case "3":
                    Console.WriteLine("Voilà la liste des intervenants extérieurs répertoriés !");
                    List<Projet> Projet = new List<Projet>();
                    Projet = _InstanceProjet.Program.instancieProjet();
                    List<Exterieur> Exte = new List<Exterieur>();
                    Exte = Rattachement.Program.ConnexionExte();
                    _AffichageListes.Program.triAlpha(Exte.ToList<Personne>());
                    int numerochoisi = int.Parse(Console.ReadLine()); // On convertit en un entier
                    _AffichageListes.Program.Choixnum(numerochoisi, Exte.ToList<Personne>());
                    return true;

                
               case "4":
                    List<Professeur> prof = new List<Professeur>();
                    prof= Rattachement.Program.ConnexionProf();
                    Console.WriteLine("Si vous voulez voir tous les professeurs s'afficher, tapez 1 !");
                    Console.WriteLine("Si vous voulez voir les professeurs s'afficher par matière, tapez 2 !");
                    int choixE = int.Parse(Console.ReadLine());
                    if (choixE == 1)
                    {
                        Console.WriteLine("Voici la liste des professeurs de l'école");
                        _AffichageListes.Program.triAlpha(prof.ToList<Personne>());
                        int numerochoisiP = int.Parse(Console.ReadLine()); // On convertit en un entier
                        _AffichageListes.Program.Choixnum(numerochoisiP, prof.ToList<Personne>());
                    }
                    else 
                    {
                        List<Matiere> ToutesMat = new List<Matiere>();
                        ToutesMat = _InstanceMatiere.Program.instancieMatiere();
                        foreach (Matiere toutesM in ToutesMat)
                        {
                            Console.WriteLine(toutesM._nom+" :");
                            foreach (Professeur p in prof)
                            {
                                foreach (Matiere m in p._matieres)
                                {
                                    if (m._nom == toutesM._nom) Console.WriteLine("     "+p._nom+ "     Si vous voulez sélectionner ce professeur en particulier, tapez " + prof.IndexOf(p));
                                    string choix = Convert.ToString(prof.IndexOf(p));
                                    possible.Add(choix);
                                }
                            }
                        }
                        string entree7 = Console.ReadLine();
                        bool verification7 = Verification.Program.Verification(entree7, possible);
                        if (verification7 == true)
                        {
                            int numerochoisiP = int.Parse(entree7); // On convertit en un entier
                            _AffichageListes.Program.Choixnum(numerochoisiP, prof.ToList<Personne>());
                        }
                        else
                        { }
                    }
                    return true;

                case "5":
                    List<Matiere> Matieres = new List<Matiere>();
                    Matieres = _InstanceMatiere.Program.instancieMatiere();
                    List<Projet> Projets = new List<Projet>();
                    Projets = _InstanceProjet.Program.instancieProjet();
                    Console.Clear();
                    foreach (Matiere element in Matieres)
                    {
                        Console.WriteLine(element._nom + " si vous voulez afficher les projets de cette matière, tapez " + Matieres.IndexOf(element));
                        Console.WriteLine("\n");
                        string pos = Convert.ToString(Matieres.IndexOf(element));
                        possible.Add(pos);
                    }
                    string entree5 = Console.ReadLine();
                    bool verification5 = Verification.Program.Verification(entree5, possible);
                    if (verification5 == true)
                    {

                        List<string> choisir = new List<string>();
                        int matchoix = int.Parse(entree5);
                        string choix = "";
                        foreach (Matiere m in Matieres)
                        {
                            if (matchoix == Matieres.IndexOf(m))
                            {
                                choix = m._nom;
                            }
                        }
                        Console.Clear();
                        foreach (Projet p in Projets)
                        {
                            foreach (Matiere ma in p._matieres)
                            {
                                if (choix == ma._nom)
                                {
                                    Console.Write(p._nomProjet + " (Chef de projet :" + p._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Projets.IndexOf(p));
                                    string pos = Convert.ToString(Projets.IndexOf(p));
                                    choisir.Add(pos);
                                }
                            }
                        }
                        string entree6 = Console.ReadLine();
                        bool verification6 = Verification.Program.Verification(entree6, choisir);
                        if (verification6 == true)
                        {
                            int choixpro = int.Parse(entree6); // On convertit en un entier
                            foreach (Projet element in Projets)
                            {
                                if (choixpro == Projets.IndexOf(element)) { Console.Clear(); element.Affichage(element); }
                            }
                            return true;
                        }

                        else { return false; }
                    }
                    else { return false; }



                case "6":
                    List<Projet> Proj = new List<Projet>();
                    Proj = _InstanceProjet.Program.instancieProjet();
                    Console.WriteLine("Vous avez choisi d'afficher les projets ! Si vous voulez les voir s'afficher tous, tapez 1");
                    Console.WriteLine("Si vous voulez les voir s'afficher par promo, tapez 2");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Voici les projets achevés : ");
                            Console.WriteLine("\r\n");
                            foreach (Projet element in Proj)
                            {
                                if (element._sujetAcheve)
                                {
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                    string pos = Convert.ToString(Proj.IndexOf(element));
                                    possible.Add(pos);
                                }
                            }
                            Console.WriteLine("\r\n");
                            Console.WriteLine("Voici les projets qui ne sont pas encore achevés : ");
                            Console.WriteLine("\r\n");
                            foreach (Projet element in Proj)
                            {
                                if (element._sujetAcheve==false)
                                {
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                    string pos = Convert.ToString(Proj.IndexOf(element));
                                    possible.Add(pos);
                                }
                            }
                            string entree = Console.ReadLine();
                            bool verification = Verification.Program.Verification(entree, possible);
                            if (verification==true)
                            {
                                numerochoisi = int.Parse(entree); // On convertit en un entier
                                foreach (Projet element in Proj)
                                {
                                    if (numerochoisi == Proj.IndexOf(element)) element.Affichage(element);
                                }
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case "2":
                            Console.WriteLine("Promo 2022 :");
                            _AffichageListes.Program.ProjetparPromo(2022, Proj);
                            Console.WriteLine("Promo 2021 :");
                            _AffichageListes.Program.ProjetparPromo(2021, Proj);
                            Console.WriteLine("Promo 2020 :");
                            _AffichageListes.Program.ProjetparPromo(2020, Proj);
                            Console.WriteLine("Autres");
                            foreach (Projet element in Proj)
                            {
                                if (element._chefprojet._promo != 2021 && element._chefprojet._promo != 2022 && element._chefprojet._promo != 2020)
                                {
                                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + Proj.IndexOf(element));
                                }
                                string pos = Convert.ToString(Proj.IndexOf(element));
                                possible.Add(pos);
                            }
                            string entree2 = Console.ReadLine();
                            bool verification2 = Verification.Program.Verification(entree2, possible);
                            if (verification2 == true)
                            {
                                int numerochoisip = int.Parse(entree2); // On convertit en un entier
                                foreach (Projet element in Proj)
                                {
                                    if (numerochoisip == Proj.IndexOf(element)) element.Affichage(element);
                                }
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        default: return false;
                    }
                default: return false;
            }
        }
    }
}
    

