using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public class Frigo : IElement
    {
        private bool occuper;
        private bool aLaver;
        public bool ALaver { get => aLaver; set => aLaver = value; }
        public bool Occuper { get => occuper; set => occuper = value; }

        public Frigo()
        {

        }

        public void Utiliser()
        {
            throw new NotImplementedException();
        }
    }
}
