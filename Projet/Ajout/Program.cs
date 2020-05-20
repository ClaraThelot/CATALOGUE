using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _InstanceProjet;
using _AffichageListes;
using _InstancePersonne;
using _projet;
using System.IO;
using Creation;

namespace Ajout
{
    public class Program
    {
        public static object StringUtils { get; private set; }

        static void Main(string[] args)
        { }

        public static bool MenuAjout()                                                                                  //Permet de créer un nouveau projet et l'ajouter dans la 'base de données'
        {
            int codeProj = _InstanceProjet.Program.CompteProjet() + 1;
            Console.WriteLine("Bienvenue sur le menu des ajouts !");
            Console.WriteLine("Vous allez pouvoir créer un projet. D'abord, saisissez-en le nom.");
            string nom = Console.ReadLine();
            string ligne = nom + "*";
            string  entree= "";
            int duree;
            while (!int.TryParse(entree, out duree))                                                                                            //S'assure que la donnée rentrée est bien un int
            {
                Console.WriteLine("Saisissez la durée du projet (Tapez un nombre, en mois)");
                entree = Console.ReadLine();
            }
                ligne = ligne + entree + "*";
            List<string> possible = new List<string>();                                                                                         //S'assurer que la donnée rentrée correspond
            possible.Add("non");
            possible.Add("oui");
            string choix="";
            do
            {
                Console.WriteLine("Si vous laissez de la liberté à vos élèves et que votre sujet est libre, tapez 'oui', sinon, tapez 'non'");
                choix = Console.ReadLine();
            }
            while (!Verification.Program.Verification(choix, possible)) ;                                                                   //Permet de s'assurer que la donnée correspond bien à une des données à attendues
                if (choix == "oui") { ligne = ligne + "true*"; }
             else { ligne = ligne + "false*"; }

            possible.Remove("oui");
            possible.Add("si");
            string fini = "";
            do
            {
                Console.WriteLine("Mais dîtes moi, vous ne parlez pas d'un sujet déjà achevé ? (tapez 'si' ou 'non')");                 // Perrmet de statuer si le projet est achevé
                fini = Console.ReadLine();
            }
            while (!Verification.Program.Verification(fini, possible));
                if (fini == "si")
            {
                string note = "";
                int note2;
                while (!int.TryParse(note, out note2))
                {
                    Console.WriteLine("Quelle note avez-vous attribué à ces élèves acharnés ?");                                    // Permet d'attribuer la note, le  cas échéant
                    note = Console.ReadLine();
                }
                ligne = ligne + note + "*true*";
            }
            else
            {
                ligne = ligne + "0*false*";                                                                                     // Cas où le projet n'est pas achevé
            }
            //Sélection des matières :
            List<Matiere> TousMatieres = new List<Matiere>();
            TousMatieres = _InstanceMatiere.Program.instancieMatiere();
            List<string> possible1 = new List<string>();
            foreach(Matiere element in TousMatieres)                                                                         //Construction du champ des possibles
            {
                possible1.Add(Convert.ToString(TousMatieres.IndexOf(element)));
            }
            possible1.Add("000");
            string nombre = "";
            int NbM;
            while (!int.TryParse(nombre, out NbM)||nombre=="0")
            {
                Console.WriteLine("Combien de matières concernent ce projet ?");            
                nombre = Console.ReadLine();
            }
            NbM = int.Parse(nombre);
            for (int i = 1; i < NbM + 1; i++)
            {
                Console.WriteLine("Occupons-nous de la matière n°" + i);
                Console.WriteLine("Voulez vous sélectionner la matière parmi une liste ou créer une nouvelle matière ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom de la matière, faîtes le !");
                string choixM = Console.ReadLine();
                if (choixM == "oui")                                                                                        //Permet de choisir la matière parmi la liste
                {
                    int numerochoisi;
                    string saisie = "";
                    do
                    {
                        Console.WriteLine("Tapez le code associé à la matière n°" + i + "du projet.");
                        Console.WriteLine("Voilà la liste des matières !");
                        _AffichageListes.Program.EnSavoirPlusMat(TousMatieres);
                        Console.WriteLine("Si la matière que vous voulez sélectionner n'apparaît pas à l'écran, il va falloir la créer ! Dans ce cas, tapez 000");
                        saisie = Console.ReadLine();
                    }
                    while (!Verification.Program.Verification(saisie, possible1));
                    numerochoisi = int.Parse(saisie);
                    if (saisie=="000")
                    {
                        ligne = ligne + Creation.Program.AjoutMatiere(TousMatieres);                                        // Permet d'ajouter une nouvelle matière
                    }

                    else
                    { 
                        foreach (Matiere element in TousMatieres)
                        {
                            if (numerochoisi == TousMatieres.IndexOf(element))
                            {
                                ligne = ligne + "A" + TousMatieres[numerochoisi]._nom + "*";
                            }
                        }
                    }
                }
                else
                {
                    int occur = 0;
                    List<Object> objet = TousMatieres.ConvertAll(
                    new Converter<Matiere, Object>(_projet.Matiere.conversion));
                    foreach (Matiere element in TousMatieres)
                    {

                        if (element.Appartenir(objet, choixM) == true)
                        {
                            occur++;
                            if (choixM.ToLower() == element._nom.ToLower())
                            {
                                ligne = ligne + "A" + choixM + "*";                                 
                            }
                        }
                    }
                    if(occur==0)
                    {
                        Console.WriteLine("Désolé, il ne semble pas que cette matière existe ! Créons la !");
                        ligne=ligne + Creation.Program.AjoutMatiere(TousMatieres);
                    }
                }
            }

            //Sélection des élèves
            List<Eleve> participant = new List<Eleve>();
            List<Eleve> TousEleves2 = new List<Eleve>();
            TousEleves2 = _InstancePersonne.Program.instancieEleve();
            List<string> possible2 = new List<string>();
            foreach (Eleve element in TousEleves2)                                        //Construction du champ des possibles
            {
                possible2.Add(Convert.ToString(TousEleves2.IndexOf(element)));
            }
            possible2.Add("999");
            int NbE ;
            nombre = "";
            while (!int.TryParse(nombre, out NbE)|| nombre=="0")
            {
                Console.WriteLine("Combien d'élèves travaillent sur ce projet ?");          // Permet de déterminer le nombre d'élève afin de pouvoir faire tourner la boucle
                nombre = Console.ReadLine();    
            }
            NbE = int.Parse(nombre);
            for (int i = 1; i < NbE + 1; i++)
            {
                Console.WriteLine("Occupons-nous de l'élève n°" + i);
                Console.WriteLine("Voulez vous sélectionner l'élève parmi une liste ou créer un nouvel élève? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) de l'élève, faîtes le !");
                string choixE = Console.ReadLine();
                if (choixE == "oui")
                {
                     int numerochoisiE;
                    string saisie = "";
                    do
                    {
                        Console.WriteLine("Tapez le code associé à l'élève du projet.");                                            //Permet de choisir l'élément à l'aide du code
                        Console.WriteLine("Voilà la liste des élèves répertoriés !");
                        _AffichageListes.Program.triAlpha(TousEleves2.ToList<Personne>());
                        Console.WriteLine("Si l'élève que vous voulez sélectionner n'apparaît pas à l'écran, il va falloir le créer ! Dans ce cas, tapez 999");
                        saisie = Console.ReadLine();
                    }
                    while (!Verification.Program.Verification(saisie, possible2));
                        numerochoisiE = int.Parse(saisie);
                    if (numerochoisiE==999)
                    {
                        ligne = ligne + Creation.Program.AjoutEleve(TousEleves2, participant);                                  // Permet de créer un élève
                    }
                    else
                    {
                        foreach (Eleve element in TousEleves2)
                        {
                            if (numerochoisiE == TousEleves2.IndexOf(element))
                            {
                                participant.Add(TousEleves2[numerochoisiE]);
                                ligne = ligne + "E" + TousEleves2[numerochoisiE]._nom + "*";
                            }
                        }
                    }
                }
                else
                {
                    int occur = 0;
                    List<Object> objet = TousEleves2.ConvertAll(
                    new Converter<Eleve, Object>(_projet.Eleve.conversion));
                    foreach (Eleve element in TousEleves2)
                    {
                        if (element.Appartenir(objet, choixE) == true)
                        {
                            occur++;
                            if (choixE.ToLower() == element._nom.ToLower())
                            {
                                participant.Add(element);
                                ligne = ligne + "E" + choixE + "*";
                            }
                        }
                    }
                        if(occur==0)
                        {
                            ligne = ligne + Creation.Program.AjoutEleve(TousEleves2, participant);
                        }
                    
                }
            }

            // Sélection des intervenants
            string saisie2 = "";
            int NbI;
            while (!int.TryParse(saisie2, out NbI))
            {
                Console.WriteLine("Combien d'extérieurs interviennent sur ce projet ?");
                saisie2 = Console.ReadLine();
            }
            NbI = int.Parse(saisie2);
            List<Exterieur> TousExte = new List<Exterieur>();
            TousExte = _InstancePersonne.Program.instancieIntervenantE();
            List<string> possible3 = new List<string>();
            foreach (Exterieur element in TousExte)                                        //Construction du champ des possibles
            {
                possible3.Add(Convert.ToString(TousExte.IndexOf(element)));
            }
            possible3.Add("000");
            for (int i = 1; i < NbI + 1; i++)
            {
                Console.WriteLine("Occupons-nous de l'intervenant extérieur n°" + i);
                Console.WriteLine("Voulez vous sélectionner l'intervenant parmi une liste ou créer un nouvel intervenant ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) de l'intervenant, faîtes le !");
                string choixI = Console.ReadLine();
                if (choixI == "oui")
                {
                    int numerochoisi1;
                    string saisie3 = "";
                    do
                    {
                        Console.WriteLine("Tapez le code associé à l'extérieur du projet.");
                        Console.WriteLine("Voilà la liste des extérieurs répertoriés !");
                        _AffichageListes.Program.triAlpha(TousExte.ToList<Personne>());
                        Console.WriteLine("Si l'intervenant que vous voulez sélectionner n'apparaît pas à l'écran, il va falloir le créer ! Dans ce cas, tapez 000");
                        saisie3 = Console.ReadLine();
                    }
                    while (!Verification.Program.Verification(saisie3, possible3)) ;
                        numerochoisi1 = int.Parse(saisie3);
                    if (saisie3 == "000")
                    {
                        ligne = ligne + Creation.Program.AjoutIntervenant(TousExte);
                    }

                    else
                    {
                       ligne= _AffichageListes.Program.CreaLigne(numerochoisi1, TousExte.ToList<Personne>(), "P", ligne);
                    }


                    Console.WriteLine("Quel est le rôle de cette personne ?");                                      // Permet d'attribuer le rôle à l'intervenant
                    string role = Console.ReadLine();
                    role = role + "*" + codeProj + "*" + TousExte[numerochoisi1]._nom;
                    _AffichageListes.Program.CreaCode("Rôles.txt", role);                                           //Permet d'écrire le nouveau rôle
                }
                else
                {
                    int occur = 0;
                    List<Object> objet = TousExte.ConvertAll(
                    new Converter<Exterieur, Object>(_projet.Exterieur.conversion));
                    foreach (Exterieur element in TousExte)
                    {
                        if (element.Appartenir(objet, choixI) == true)
                        {
                            occur++;
                            if (choixI.ToLower() == element._nom.ToLower()) ligne = ligne + "P" + choixI + "*";
                        }
                    }
                        if (occur == 0)
                        {
                            ligne = ligne + Creation.Program.AjoutIntervenant(TousExte);
                        }

                    
                    string role = _AffichageListes.Program.RecupRole(codeProj, choixI);
                        _AffichageListes.Program.CreaCode("Rôles.txt", role);
                    

                }
            }
            //Séléction du chef de projet :
            List<string> possible4 = new List<string>();
            foreach(Eleve element in participant)
            {
                possible4.Add(Convert.ToString(participant.IndexOf(element)));
            }
            string chef = "";
            while (!Verification.Program.Verification(chef, possible4))
            {
                Console.WriteLine("Tapez le code associé au chef du projet.");                      //Permet de sélectionner lee chef de projet parmi les élèves participants au projet
                Console.WriteLine("Voilà la liste des élèves participant !");
                _AffichageListes.Program.EnSavoirplus(participant.ToList<Personne>());
                chef = Console.ReadLine();
            }
            int numerochoisi4 = int.Parse(chef);
            foreach (Matiere element in TousMatieres)
            {
                if (numerochoisi4 == TousMatieres.IndexOf(element))
                {
                    ligne = ligne + "C" + participant[numerochoisi4]._nom + "*";
                }
            }

            //Séléction des Livrables

            string liv = "";
            int NbL;
            while (!int.TryParse(liv, out NbL)||liv=="0")
            {
                Console.WriteLine("Combien de livrables sont attendus dans ce projet ?");                       //Permet de créer les livrables
                liv = Console.ReadLine();
            }
            NbL = int.Parse(liv);
            for (int i = 1; i < NbL + 1; i++)
            {
                Console.WriteLine("Quelle est la nature du livrable n° " + i + " ?");
                string _nom = Console.ReadLine();
                Console.WriteLine("Quelle est l'échéance de ce livrable ? (de la forme AAAA/MM/JJ)");
                string _date = Console.ReadLine();
                string nv = _nom + "*" + _date + "*" + codeProj + "*";
                _AffichageListes.Program.CreaCode("Livrables.txt", nv);                                 // Permet d'ajouter le livrable dans le fichier Livrables 
            }

            //Sélection des profs (même processus que pour les intervenants)
            int NbProf;
            string pr = "";
            while (!int.TryParse(pr, out NbProf))
            {
                Console.WriteLine("Combien de professeurs gèrent ce projet ?");                             
                pr = Console.ReadLine();
            }
            NbProf = int.Parse(pr);
            List<Professeur> TousProfs = new List<Professeur>();
            TousProfs = _InstancePersonne.Program.instancieProfesseur();
            List<string> possible5 = new List<string>();
            foreach (Professeur element in TousProfs)
            {
                possible5.Add(Convert.ToString(TousProfs.IndexOf(element)));
            }
            for (int i = 1; i < NbProf + 1; i++)
            {
                Console.WriteLine("Occupons-nous du professeur n°" + i);
                Console.WriteLine("Voulez vous sélectionner le professeur parmi une liste ? Si c'est le cas, tapez oui. Si vous pouvez écrire directement le nom (de famille) du professeur, faîtes le !");
                string choixP = Console.ReadLine();
                if (choixP == "oui")
                {
                    string proff = "";
                    do
                    {
                        Console.WriteLine("Tapez le code associé au professeur n°" + i + " du projet.");
                        Console.WriteLine("Voilà la liste des professeurs répertoriés !");
                        _AffichageListes.Program.triAlpha(TousProfs.ToList<Personne>());
                        proff = Console.ReadLine();
                    }
                    while (!Verification.Program.Verification(proff, possible5));
                    int numerochoisi2 = int.Parse(proff);
                    ligne=_AffichageListes.Program.CreaLigne(numerochoisi2, TousProfs.ToList<Personne>(), "M", ligne);
                    Console.WriteLine("Quel est le rôle de cette personne ?");
                    string role = Console.ReadLine();
                    role = role + "*" + codeProj + "*" + TousProfs[numerochoisi2]._nom;
                    _AffichageListes.Program.CreaCode("Rôles.txt", role);
                }
                else
                {
                    int occur = 0;
                    List<Object> objet = TousProfs.ConvertAll(
                    new Converter<Professeur, Object>(_projet.Professeur.conversion));

                    foreach (Professeur element in TousProfs)
                    {
                        if (element.Appartenir(objet, choixP) == true)
                        {
                            occur++;
                            if (choixP.ToLower() == element._nom.ToLower())
                            {
                                ligne = ligne + "M" + element._nom;
                            }
                        }
                    }
                            if (occur == 0)
                            {
                                Console.WriteLine("Désolé, nous ne trouvons pas ce professeur dans notre liste.");
                                Console.WriteLine("Voilà la liste des professeurs répertoriés !");
                                _AffichageListes.Program.triAlpha(TousProfs.ToList<Personne>());
                                int numerochoisi2 = int.Parse(Console.ReadLine());
                                ligne= _AffichageListes.Program.CreaLigne(numerochoisi2, TousProfs.ToList<Personne>(), "M", ligne);
                            }

                        
                    
                        string role = _AffichageListes.Program.RecupRole(codeProj, choixP);
                        _AffichageListes.Program.CreaCode("Rôles.txt", role);
                    }
                }
            

            //Ecriture dans le fichier Projets.txt
            string ecrire = codeProj + "*" + ligne;
            string inserer = ecrire.Substring(0, ecrire.Length - 1);
            _AffichageListes.Program.CreaCode("Projets.txt", inserer);
            //Affichage de la création 
            Console.Clear();
            Console.WriteLine("Vous avez créé le projet suivant !");
            List<Projet> bdd = new List<Projet>();
            bdd = _InstanceProjet.Program.instancieProjet();
            Projet ajout = bdd.Last();
            ajout.Affichage(ajout);
            return true;
        }
    }

}
