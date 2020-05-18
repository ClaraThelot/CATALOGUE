using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _AffichageListes{ // Version Clara
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static void triAlpha(List<Personne> eDesordre)
        {
            IEnumerable<Personne> Alpha = from student in eDesordre
                                          orderby student._nom ascending
                                          select student;
            foreach (Personne p in Alpha)
            {
                Console.Write(p._nom);
                Console.WriteLine("     Si vous voulez sélectionner cet intervenant en particulier, tapez " + eDesordre.IndexOf(p));
            }
        }

        public static string RecupRole(int codeProj, string choixP)
        {
            Console.WriteLine("Quel est le rôle de cette personne ?");
            string role = Console.ReadLine();
            role = role + "*" + codeProj + "*" + choixP;
            return role;
        }
        public static void AfficheParAn(string annee, List<Eleve> ListeE)
        {
            Console.WriteLine(annee + " :");
            foreach (Eleve element in ListeE)
            {
                if (element._annee == annee)
                {
                    Console.Write(element._nom);
                    Console.WriteLine("     Si vous voulez en savoir plus sur cet élève, tapez " + ListeE.IndexOf(element));
                }
            }
        }
        public static void ProjetparPromo(int prom, List<Projet> ListeP)
        {
            foreach (Projet element in ListeP)
            {
                if (element._chefprojet._promo == prom)
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
                    if (numchois == pers.IndexOf(element)) { element.Affiche(); }
                }
            }
            else
            { }
        }
        public static void EnSavoirplus(List<Personne> pers) 
        {
            foreach (Personne element in pers)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez sélectionner cet intervenant en particulier, tapez " + pers.IndexOf(element));
            }
        }

        public static void CreaLigne(int num, List<Personne> pers, string identification, string ligne)
        {
            foreach (Personne element in pers)
            {
                if (num== pers.IndexOf(element))
                {
                    ligne = ligne + identification + pers[num]._nom + "*";
                }
            }
        }
        public static void EnSavoirPlusMat(List<Matiere> ListeM)
        {
            foreach (Matiere element in ListeM)
            {
                Console.Write(element._nom);
                Console.WriteLine("     Si vous voulez sélectionner cette matière en particulier, tapez " + ListeM.IndexOf(element));
            }
        }
        
        public static void CreaCode(string file, string ligne)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file, append: true))
                {

                    writer.Write("\r\n" + ligne);
                }
            }
            catch (Exception exp)
            {
                Console.Write("Erreur");
            }
        }
    }
}
