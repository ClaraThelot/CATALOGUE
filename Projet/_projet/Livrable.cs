using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public class Livrable
    {
        public string _type { get; set; }
        public string _echeance { get; set; }
        public string  _refprojet { get; set; }

        public Livrable( string type, string echeance, string projet)
        {
            _type = type;
            _echeance = echeance;
            _refprojet = projet;
        }
        public override string ToString()
        {
            string res = "";
            res = res + "Le livrable du sujet " + _refprojet; // pour l'instant
            res = res + " est à rendre pour le : " + _echeance + "\n";
            res = res + "Sa nature est : " + _type;
            return res;
        }

    }
}
