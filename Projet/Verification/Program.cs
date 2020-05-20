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
        public static bool Verification(string entree, List<string> possible)               //Permet de vérifier qu'une chaîne de caractère rentrée fait bien partie d'une liste de possibilités
        {
            bool valide = true;
            int occur = 0;
            foreach (string element in possible)
            {
                int compare = String.Compare(element, entree);                              //Compare les chaînes de carctères
                if (compare == 0)occur++;
            }
            if (occur == 0)  valide = false; 
            if (valide == false)Console.WriteLine("Désolée votre entrée n'est pas valide");
            return valide;
        }
    }
}
