using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public interface IElement
    {
        bool ALaver { get; set; }
        //bool Occuper { get; set; }
        void Utiliser();
    }
}
