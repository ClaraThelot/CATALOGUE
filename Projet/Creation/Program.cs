using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _AffichageListes;
using System.IO;

namespace Creation
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static string AjoutMatiere(List<Matiere> liste)                                          // Fonction de créer une nouvelle matière en l'intégrant dans la 'base de données'
        {
            Console.WriteLine("C'est parti pour la création de matière !");
            int totalLignesM = File.ReadLines("Matieres.txt").Count();
            Console.WriteLine(totalLignesM);
            Console.WriteLine("Comment s'appelle cette nouvelle matière ?");
            string nvlLigneM = Console.ReadLine();
            string nomchoisiM = nvlLigneM;
            Console.WriteLine("Quel est son numéro associé ?");
            string num = Console.ReadLine();
            nvlLigneM = nvlLigneM + "*" + num;
            Console.WriteLine("A quelle UE appartient-elle ?");
            string UE = Console.ReadLine();
            nvlLigneM = nvlLigneM + "*" + UE + "*";
            Matiere nvlMatiere = new Matiere(nomchoisiM, num, UE);
            liste.Add(nvlMatiere);
            Console.WriteLine(nvlLigneM);
            _AffichageListes.Program.CreaCode("Matieres.txt", nvlLigneM);                            // Ecriture de la ligne dans le fichier Matieres.Tct
            String ajout ="A" + nomchoisiM + "*";
            return ajout;

        }

        public static string AjoutEleve(List<Eleve> eleves, List<Eleve> participe)                  // Permet d'ajouter un élève en l'ajoutant dans la 'base de données'
        {
            Console.WriteLine("C'est parti pour la création d'élève !");
            Console.WriteLine("Quel est le nom de famille de cet élève ?");
            string nvlLigneE = Console.ReadLine();
            string nomchoisiE = nvlLigneE;
            Console.WriteLine("Son prénom ?");
            string prenom = Console.ReadLine();
            nvlLigneE = nvlLigneE + "*" + prenom;
            Console.WriteLine("Son année actuelle ?");
            string annee = Console.ReadLine();
            nvlLigneE = nvlLigneE + "*" + annee + "*";
            Console.WriteLine("Sa promo ?");
            string promotion = Console.ReadLine();
            nvlLigneE = nvlLigneE + promotion + "*";
            int numpromo = int.Parse(promotion);
            Console.WriteLine("Son groupe de TD ?");
            string gp = Console.ReadLine();
            nvlLigneE = nvlLigneE + gp;
            int groupe = int.Parse(gp);
            Eleve nvlEleve = new Eleve(nomchoisiE, prenom, annee, numpromo, groupe);
            eleves.Add(nvlEleve);
            participe.Add(nvlEleve);
            _AffichageListes.Program.CreaCode("Eleves.txt", nvlLigneE);                         // Ecrire la ligne correspondante dans le fichier Eleves.txt
            string ajout = "E" + nomchoisiE + "*";
            return ajout;
        }

        public static string AjoutIntervenant(List<Exterieur> liste)                            // Permet d'ajouter un intervenant extérieur en l'intégrant dans la 'base de données'
        {
            Console.WriteLine("C'est parti pour la création d'intervenant extérieur !");
            Console.WriteLine("Quel est le nom de famille de cet intervenant ?");
            string nvlLigneEx = Console.ReadLine();
            string nomchoisiEx = nvlLigneEx;
            Console.WriteLine("Son prénom ?");
            string prenom = Console.ReadLine();
            nvlLigneEx = nvlLigneEx + "*" + prenom;
            Console.WriteLine("Son métier ? (en dehors de ses interventions à l'ENSC)");
            string emploi = Console.ReadLine();
            nvlLigneEx = nvlLigneEx + "*" + emploi + "*";
            Console.WriteLine("L'établissement dans lequel il exerce sa fonction ?");
            string etablissement = Console.ReadLine();
            nvlLigneEx = nvlLigneEx + etablissement;
            Exterieur nvlEx = new Exterieur(nomchoisiEx, prenom, emploi, etablissement);
            liste.Add(nvlEx);
            _AffichageListes.Program.CreaCode("Exterieurs.txt", nvlLigneEx);                    // Ecrire la ligne dans le fichier Exterieurs.txt
            string ajout ="P" + nomchoisiEx + "*";
            return ajout;
        }
    }
}
