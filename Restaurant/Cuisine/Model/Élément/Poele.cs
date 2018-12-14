using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model.Élément
{
    class Poele : IElement
    {
        private bool occuper;
        private bool aLaver;
        public bool ALaver { get => aLaver; set => aLaver = value; }
        public bool Occuper { get => occuper; set => occuper = value; }

        public Poele()
        {

        }

        public void Utiliser()
        {
            Console.WriteLine("La poêle est en cours d'utilisation");
        }
    }
}
