using System;

namespace Création_des_classes
{
    class Program
    {
        static bool Menu()
        {
            Console.WriteLine("Bienvenue sur votre application de recherche de projets de l'ENSC ! \nComment souhaitez-vous effectuer votre recherche ?\n");
            Console.WriteLine("Si vous voulez faire une recherche libre, tapez d'abord 1 sur votre clavier numérique !");
            Console.WriteLine("Si vous voulez parcourir les Eleves, tapez 2");
            Console.WriteLine("Si vous voulez parcourir les Projets, tapez 3"); // On va se limiter à ça pour l'instant

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("A présent, tapez le mot-clef unique que vous souhaitez rechercher dans la base");
                    return false;
                case "2":
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                    char separateur = '*';
                    List<Eleve> Eleves = new List<Eleve>();
                    string line;
                    string nomeleve;
                    string prenomeleve;
                    string annee;
                    int promo;
                    int TD;
                    System.IO.StreamReader file = new System.IO.StreamReader("Eleves.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        String[] information = line.Split(separateur);
                        nomeleve = information[0];
                        prenomeleve = information[1];
                        annee = information[2];
                        promo = int.Parse(information[3]);                                          //Pour ces deux lignes, un transtypage est nécessaire pour pouvoir construire l'objet à partir de la lecture du fichier
                        TD = int.Parse(information[4]);
                        Eleve eleve = new Eleve(nomeleve, prenomeleve, annee, promo, TD);
                        Eleves.Add(eleve);
                    }
                    Console.WriteLine("1A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "1A") Console.WriteLine(element._nom); }
                    Console.WriteLine("2A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "2A") Console.WriteLine(element._nom); }
                    Console.WriteLine("3A :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee == "3A") Console.WriteLine(element._nom); }
                    Console.WriteLine("Eleves ayant un autre statut :");
                    foreach (Eleve element in Eleves)
                    { if (element._annee != "1A" && element._annee != "2A" && element._annee != "3A") Console.WriteLine(element._nom); }
                    return true;
                case "3":
                    Console.WriteLine("Voilà la liste des élèves répertoriés !");
                    return true;
                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
