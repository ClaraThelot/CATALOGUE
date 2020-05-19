using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _InstanceMatiere
{
    public class Program
    {
        static void Main(string[] args)
        { }
        public static List<Matiere> instancieMatiere()                                              //Cette fonction permet de lire le fichier de matières et de créer les objets associés
        {
                char separateur = '*';                                                             // Définition du caractère séparateur (utile lors de l'analyse de fichier)
                                                                                                   // Création de la liste des matières à partir du fichier Matieres.txt
                List<Matiere> Matieres = new List<Matiere>();                                       //Initialisation de la liste
                string ligne;
                string nommatiere; string code; string ue;
                System.IO.StreamReader fichier = new System.IO.StreamReader("Matieres.txt");       //Lecture du fichier
                while ((ligne = fichier.ReadLine()) != null)                                       //Analyse ligne par ligne
                {
                    String[] information = ligne.Split(separateur);                              // Création d'un tableau contenant chaque élément de la ligne ( un élément est délimité par deux slashs)
                    nommatiere = information[0];                                                  // Affectation des différents éléments définissant une matière                                    
                    code = information[1];
                    ue = information[2];
                    Matiere matiere = new Matiere(nommatiere, code, ue);                          // Construction de la matière 
                    Matieres.Add(matiere);                                                        // Ajout de la matière créée à la liste des matières
                }
                fichier.Close();
                return Matieres;
            
            }
        }
    }

