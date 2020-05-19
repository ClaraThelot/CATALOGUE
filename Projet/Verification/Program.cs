using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verification
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static bool Verification(string entree, List<string> possible)
        {
            bool valide = true;
            int occur = 0;
            foreach (string element in possible)
            {
                int compare = String.Compare(element, entree);
                if (compare == 0)
                {
                    occur++;
                }

            }
            if (occur == 0) { valide = false; }
            if (valide == false)
            {
                Console.WriteLine("Désolée votre entrée n'est pas valide");
            }
            return valide;
        }

    
        
    }
}
