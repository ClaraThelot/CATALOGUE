using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using System.IO;

namespace _AffichageListes
{ 
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static void triAlpha(List<Personne> eDesordre) //On prend en parametre toute liste de personne
        {
            IEnumerable<Personne> Alpha = from student in eDesordre //requete permettant de trier par nom de famille
                                          orderby student._nom ascending
                                          select student;
            foreach (Personne p in Alpha) //Affichage et proposition d'afficher les détails
            {
                Console.Write(p._nom);
                Console.WriteLine("     Si vous voulez sélectionner cet intervenant en particulier, tapez " + eDesordre.IndexOf(p)); // L'index sert d'ID pour la personne considérée
            }
        }

        public static string RecupRole(int codeProj, string choixP) // Permet de factoriser le code de création d'un projet, dont on prend le code en entrée
        {
            Console.WriteLine("Quel est le rôle de cette personne ?");
            string role = Console.ReadLine();
            role = role + "*" + codeProj + "*" + choixP; // Cette ligne sera ensuite ajoutée au fichier texte
            return role;
        }
        public static void AfficheParAn(string annee, List<Eleve> ListeE) //Prend en paramètre l'année (1A, 2A, 3A) et la liste d'Eleves voulue
        {
            Console.WriteLine(annee + " :");
            foreach (Eleve element in ListeE)
            {
                if (element._annee == annee) //Ne prend en compte que les élèves dont l'année correspond à l'année voulue
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + ListeE.IndexOf(element));
                }
            }
        }
        public static void ProjetparPromo(int prom, List<Projet> ListeP) // Prend en considération la promo voulue, et la liste de projets
        {
            foreach (Projet element in ListeP)
            {
                if (element._chefprojet._promo == prom) //On vérifie que la promo du chef de projet est celle qui nous intéresse
                {
                    Console.Write(element._nomProjet + " (Chef de projet :" + element._chefprojet._nom + ")");
                    Console.WriteLine("     Si vous voulez en savoir plus sur ce projet, tapez " + ListeP.IndexOf(element));
                }
            }
        }

        public static void Choixnum(int numchois, List<Personne> pers) 
            {
            List<String> possible = new List<string>();
            foreach(Personne element2 in pers)
            {
                string pos = Convert.ToString(pers.IndexOf(element2));
                possible.Add(pos);
            }
            string choix = Convert.ToString(numchois);
            bool verification = Verification.Program.Verification(choix, possible);
            if (verification == true)
            {
                foreach (Personne element in pers)
                {
                    if (numchois == pers.IndexOf(element))  element.Affiche(); 
                }
            }
        }
        public static void EnSavoirplus(List<Personne> pers) //Cette liste permet de prendre une liste de personne, d'en afficher le nom et de proposer d'en savoir plus
        {
            foreach (Personne element in pers)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez sélectionner cet intervenant en particulier, tapez " + pers.IndexOf(element));
            }
        }

        public static string CreaLigne(int num, List<Personne> pers, string identification, string ligne) //Permet de factoriser le code de création de ligne
        {
            return ligne = ligne + identification + pers[num]._nom + "*";
        }
        public static void EnSavoirPlusMat(List<Matiere> ListeM) // Permet d'afficher le nom des matières et de proposer d'en savoir plus
        {
            foreach (Matiere element in ListeM)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez sélectionner cette matière en particulier, tapez " + ListeM.IndexOf(element));
            }
        }
        
        public static void CreaCode(string file, string ligne) // On prend le fichier texte surlequel on veut ajouter une ligne ainsi que la ligne voulue
        {
            try
           {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file, append: true))//Ouverture du fichier
                {
                    writer.Write("\n" + ligne);
                }
            }
            catch (Exception exp)
            {
               Console.Write("Erreur");
            }
        }
    }
}
