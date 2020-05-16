using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _InstanceProjet;
using _InstancePersonne;
using _InstancieProf;

namespace _InstanceRole
{
    public  class Program
    {
        static void Main(string[] args)
        { }
       /* public static List<Role> instancieRole()
        {
            char separateur = '*';
            List<Role> Roles = new List<Role>();
            string nom;
            string code;
            string line;
            string nomprojet;
            string nompersonne;
            Projet projet = new Projet();
            Personne personne = new Personne();
            List<Projet> Projets = new List<Projet>();
            Projets = _InstanceProjet.Program.instancieProjet(); // On instancie la liste des projets. 
            List<Exterieur> Exte = new List<Exterieur>();
            Exte = _InstancePersonne.Program.instancieIntervenantE(); // Pareil avec les intervenants exté
            List<Professeur> Prof = new List<Professeur>();
            Prof = _InstancePersonne.Program.instancieProfesseur();

            System.IO.StreamReader file = new System.IO.StreamReader("Rôles.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] information = line.Split(separateur);
                nom = information[0];
                code = information[1];
                nomprojet = information[3];
                nompersonne = information[2];
                foreach (Projet element in Projets)
                {
                    if (nomprojet == element._nomProjet) projet = element;
                }
                foreach (Exterieur element in Exte)
                {
                    if (nompersonne == element._nom) personne = element;
                }
                foreach (Professeur element in Prof)
                {
                    if (nompersonne == element._nom) personne = element;
                }
                Role role = new Role(nom, code, personne, projet);
                Roles.Add(role);
            }
            return Roles;
        }*/
    }
    
}
