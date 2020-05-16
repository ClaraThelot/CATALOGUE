using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _InstanceMatiere;

namespace _InstancieProf
{
    public class Program
    {
        static void Main(string[] args)
        {
            instancieProfesseur();
        }
    public static List<Professeur> instancieProfesseur()
        {
            char separateur = '*';
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Professeur> Prof = new List<Professeur>();
            string ligne2;
            string nomprof;
            string prénomprof;
            string mat;
            System.IO.StreamReader fichier2 = new System.IO.StreamReader("Professeurs.txt");
            while ((ligne2 = fichier2.ReadLine()) != null)
            {
                List<Projet> projetprof = new List<Projet>();
                List<Matiere> mate = new List<Matiere>();
                String[] information = ligne2.Split(separateur);
                int elementi = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                int choix = 0;                                                          // Cet entier permettra de retenir le numéro de l'élément correspondant à la matière recherchée
                nomprof = information[0];
                prénomprof = information[1];
                mat = information[2];
                foreach (Matiere element in Matieres)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                {
                    
                    if (element._nom == mat)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                    {
                        choix = elementi;
                    }

                    elementi += 1;
                }
                mate.Add(Matieres[choix]);
                Professeur profe = new Professeur(nomprof, prénomprof, projetprof, mate);
                Prof.Add(profe);

            }
  
            return Prof;
        }
    }
}
