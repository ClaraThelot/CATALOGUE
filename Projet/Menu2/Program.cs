using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajout;
using RechercheLibre;
using _projet;
using

namespace Menu2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Bienvenue dans votre application ! Aujourd'hui, si vous souhaitez faire une recherche, tapez 1");
            Console.WriteLine("Si vous souhaitez rajouter un projet, tapez 2");
            int choixUt = int.Parse(Console.ReadLine());
            if (choixUt == 1) MenuRecherche();
            if (choixUt == 2) Ajout.Program.MenuAjout();
            RetourMenu();*/
        }
        /*static void RetourMenu()                                                //Permet de retourner au menu quand on veut
        {
            string[] arg = new string[0];
            Console.WriteLine("\r\n");
            Console.WriteLine("Vous voulez revenir au menu ? Tapez M !");
            if (Console.ReadLine() == "M")
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
            Console.WriteLine("Si vous voulez parcourir les projets, tapez 5");

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
                    switch (Console.ReadLine())
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
                            }
                            numero = int.Parse(Console.ReadLine()); // On convertit en un entier
                            _AffichageListes.Program.Choixnum(numero, Eleves.ToList<Personne>());
                            return true;
                        default: return false;
                    }
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
                                if (numerochoisi == Proj.IndexOf(element)) element.Affichage(element);
                            }
                            return true;
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
                            }
                            int numerochoisip = int.Parse(Console.ReadLine()); // On convertit en un entier
                            foreach (Projet element in Proj)
                            {
                                if (numerochoisip == Proj.IndexOf(element)) element.Affichage(element);
                            }
                            return true;
                        default: return false;
                    }
            }
        }*/
    }
}
