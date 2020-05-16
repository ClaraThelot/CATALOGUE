using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{

    public class Role
    {
        public string _nom;
        public string _code;
        public string _personne;
        


        public Role(string nom, string code)
        {
            _nom = nom;
            _code = code;
            _personne = "";
        }
        public Role(string nom, string code, string personne)
        {
            _nom = nom;
            _code = code;
            _personne = personne;
            
        }
        public override string ToString()
        {
            string res = "";
            res = res + "La personne " + _personne + " assume comme rôle " + _nom + " dans ce projet.\n";
            return res;
        }
        public static void RattacheRole(string code)
        {
            string line;
            char separateur = '*';
            string nom;
            string _codeR;
            string personne;
            List<Role> Roles = new List<Role>();
            System.IO.StreamReader file = new System.IO.StreamReader("Rôles.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] information = line.Split(separateur);
                nom = information[0];
                _codeR = information[1];
                personne = information[2];
                Role R = new Role(nom, _codeR, personne);
                Roles.Add(R);
            }
            
                
                foreach (Role r in Roles)
            {
                
                int compare = String.Compare(r._code, code);
                if (compare==0)
                {
                    Console.WriteLine(r.ToString());
                  }
            }
        }


    }
}
