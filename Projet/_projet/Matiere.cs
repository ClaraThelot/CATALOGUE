using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Matiere : IAffichable, IAppartenance
    {
        public string _nom { get; }
        public string _code;
        public string _UE;
  
        public Matiere() { }
        public Matiere(string nom, string code, string UE)
        {
            _nom = nom;
            _code = code;
            _UE = UE;
        }

        public void Affichage(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public void AffichageDepuisListe(object obj, List<object> liste)
        {
            Console.WriteLine("Si vous souhaitez afficher le détail, tapez " + liste.IndexOf(obj));
            string s = (Console.ReadLine());
            if (s == "1") Console.WriteLine(obj.ToString());
        }

        public override string ToString()
        {
            string res = "";
            res = res + "La matière " + _nom + " dont le code est " + _code + " fait partie de l'UE " + _UE;
            return res;
        }
        public static Object conversion(Matiere m)
        {
             Object o = m as Object;
            return o;
        }
        
        public bool Appartenir(List<Object> liste, string entree)
        {
            int occur = 0;
            foreach(Matiere element in liste)
            {
                if(element._nom==entree) occur++;
            }
            if(occur==0)return false; 
            else
            { return true; }
        }
    }
}
