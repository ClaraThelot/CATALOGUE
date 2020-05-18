using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _projet;

namespace _InstanceLivrable
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<Livrable> instancieLivrable()
        {
            char separateur = '*';
            List<Livrable> Livrables = new List<Livrable>();
            string ligneL;
            string type;
            string echeance;
            string projet = "";
            System.IO.StreamReader file3 = new System.IO.StreamReader("Livrables.txt");
            while ((ligneL = file3.ReadLine()) != null)
            {
                String[] information = ligneL.Split(separateur);
                type = information[0];
                echeance = information[1];
                projet = information[2];
                Livrable liv = new Livrable(type, echeance, projet);
                Livrables.Add(liv);
            }
            file3.Close();
            return Livrables;
        }
    }
}
