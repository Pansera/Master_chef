using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public class Evier : IElement
    {
        private bool occuper;
        private bool aLaver;

        public Evier()
        {
        }

        public bool ALaver { get => aLaver; set => aLaver = value; }
        public bool Occuper { get => occuper; set => occuper = value; }

        public void Utiliser()
        {
            
        }
    }
}
