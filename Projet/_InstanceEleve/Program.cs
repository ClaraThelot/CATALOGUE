using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _AffichageListes // Pour factoriser les codes d'affichage des différentes listes
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public void AfficheEleves()
        {
            Console.WriteLine("Voilà la liste des élèves répertoriés !");
            List<Eleve> TousEleves2 = new List<Eleve>();
            TousEleves2 = _InstancePersonne.Program.instancieEleve();
            foreach (Eleve element in TousEleves2)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous sélectionnez cet elève, tapez " + TousEleves2.IndexOf(element));
            }
        }
        /*public static List<Eleve> instancieEleve()
        {
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
            return Eleves;
        }*/
    }
}
