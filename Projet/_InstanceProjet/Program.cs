using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _projet;
using System.Threading.Tasks;
using _AffichageListes;
using _InstancePersonne;
using _InstanceMatiere;
using _InstanceLivrable;


namespace _InstanceProjet
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<Exterieur> RattacheExte(List<Exterieur> e, Projet p)                         // Cette fonction permet de rettacher les extérieurs à leurs projets
        {

            foreach (Exterieur element in e)
            {

                    foreach (Exterieur e1 in p._intervenants)
                    {
                        if (e1._nom == element._nom)
                        {
                            element.ajoutProjet(p);
                        }
                    }
                }
            
            return e;
        }
        public static List<Professeur> RattacheProf(List<Professeur> prof, Projet p)                   // Cette fonction permet de rattacher les professeurs à leurs projets
        {

            foreach (Professeur element in prof)
            {

                foreach (Professeur e1 in p._professeurs)
                {
                    if (e1._nom == element._nom)
                    {
                        element.ajoutProjet(p);
                    }
                }
            }

            return prof;
        }

        public static List<Projet> instancieProjet()                                            // Cette fonction permet de lire le fichier et de créer les objets Projets correspondants
        {
            char separateur = '*';
            string ligneP;
            List<Projet> Projets = new List<Projet>();
            List<Matiere> Matieres = new List<Matiere>();
            Matieres = _InstanceMatiere.Program.instancieMatiere();
            List<Eleve> Eleves = new List<Eleve>();
            Eleves = _InstancePersonne.Program.instancieEleve();
            List<Livrable> Livrables = new List<Livrable>();
            Livrables = _InstanceLivrable.Program.instancieLivrable();
            List<Exterieur> Exterieurs = new List<Exterieur>();
            Exterieurs = _InstancePersonne.Program.instancieIntervenantE();
            List<Professeur> Professeurs = new List<Professeur>();
            Professeurs = _InstancePersonne.Program.instancieProfesseur();
            System.IO.StreamReader file4 = new System.IO.StreamReader("Projets.txt");
            while ((ligneP = file4.ReadLine()) != null)
            {
                string nom;
                int duree;
                bool sujetlibre;
                double note;
                bool acheve;
                List<Livrable> llivrable = new List<Livrable>();
                List<Eleve> eparticipant = new List<Eleve>();
                List<Exterieur> pparticipant = new List<Exterieur>();
                List<Matiere> matconcernee = new List<Matiere>();
                List<Professeur> prof = new List<Professeur>();
                Eleve chef = new Eleve();
                String[] information = ligneP.Split(separateur);
                string code;
                code = information[0];
                nom = information[1];
                duree = int.Parse(information[2]);
                sujetlibre = bool.Parse(information[3]);
                note = double.Parse(information[4]);
                acheve = bool.Parse(information[5]);

                int i = 6;
                
                while(i<information.Length)
                {
                    if(information[i][0]=='A')
                    {
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        int start = 1;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Matiere element in Matieres)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        matconcernee.Add(Matieres[choix2]);
                    }
                    if (information[i][0] == 'E')
                    {
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        int start = 1;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Eleve element in Eleves)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        eparticipant.Add(Eleves[choix2]);
                    }
                    if (information[i][0] == 'P')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Exterieur element in Exterieurs)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        pparticipant.Add(Exterieurs[choix2]);
                    }
                  
                    if (information[i][0] == 'C')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string nomparticipant = information[i].Substring(start);
                        foreach (Eleve element in Eleves)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomparticipant)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2 += 1;
                        }
                        chef = Eleves[choix2];
                    }
                    if(information[i][0]=='M')
                    {
                        int start = 1;
                        int element2 = 0;                                                       //Cet entier contiendra la place de l'élément en cours de lecture dans la liste
                        int choix2 = 0;
                        string nomprof = information[i].Substring(start);
                        foreach (Professeur element in Professeurs)                                   // Cette boucle permet de repérer l'objet de type matière correspondant au nom de matière donné dans le fichier du prof
                        {
                            if (element._nom == nomprof)                                            // Si le nom dans le fichier correspond au nom de cette matière, on retient le numéro
                            {
                                choix2 = element2;
                            }
                            element2++;
                        }
                        prof.Add(Professeurs[choix2]);
                    }
                    i++;
                }
                int repere = 0;
                int parcours = 0; 
                foreach(Livrable element in Livrables)                                               // Permet d'associer les livrables au projet, grâce au code
                {
                    if(element._refprojet==code)
                    {
                       repere  = parcours; 
                    }
                    parcours++;
                }
                llivrable.Add(Livrables[repere]);
                Projet ajout = new Projet(code,nom, duree, sujetlibre, note, acheve, llivrable, eparticipant, pparticipant, prof, matconcernee, chef); //crée le projet avec les élèves non reliés
                foreach(Eleve element in eparticipant)                                              
                {
                    foreach (Eleve element2 in Eleves)                                          // Permet de relier les élèves au projet
                    {
                        if (element2._nom ==element._nom)
                        {
                            element2._projet.Add(ajout);
                        }
                }
                }
                pparticipant = RattacheExte(pparticipant,ajout);
                prof = RattacheProf(prof, ajout);
                Projet nouveau = new Projet(code,nom, duree, sujetlibre, note, acheve, llivrable, eparticipant, pparticipant, prof, matconcernee, chef); // Crée le projet avec les élèves reliés
                Projets.Add(nouveau);
                
            }
            file4.Close();
            return Projets;
        }
    }
}
