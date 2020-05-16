using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Matiere : IAffichable
    {
        public string _nom;
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
            Console.WriteLine("Si vous souhaitez afficher le détail, tapez 1");
            string s = (Console.ReadLine());
            if (s == "1") Console.WriteLine(obj.ToString());
        }

        public void AffichageDepuisListe(object obj, List<object> liste)
        {
            Console.WriteLine("Si vous souhaitez afficher le détail, tapez " + liste.IndexOf(obj));
            string s = (Console.ReadLine());
            if (s == "1") Console.WriteLine(obj.ToString());
        }

        public override string ToString()
        {
            string res = " ";
            res = res + "La matière " + _nom + " dont le code est " + _code + "fait partie de l'UE " + _UE;
            return res;
        }
    }
}
