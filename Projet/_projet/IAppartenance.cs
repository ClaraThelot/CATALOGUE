using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _projet
{
    public interface IAppartenance
    {
       
            string _nom { get; }

            bool Appartenir(List<object> liste, string entree);
        
    }
}
