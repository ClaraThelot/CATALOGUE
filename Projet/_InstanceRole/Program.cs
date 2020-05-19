using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;
using _InstanceProjet;
using _InstancePersonne;

namespace _InstanceRole
{
    public  class Program
    {
        static void Main(string[] args)
        { }
        public static int CompteProjet()                                    //Cette fonction permet de compter le nombre de projet qu'il y a ( cela permet de créer le code d'identification du projet)                                            
        {
            int max = 0;
            List<Projet> Proj = _InstanceProjet.Program.instancieProjet();
            foreach (Projet element in Proj)
            {
                if (int.Parse(element._code) > max) max = int.Parse(element._code);
            }
            return max;
        }

      
    }
    
}
