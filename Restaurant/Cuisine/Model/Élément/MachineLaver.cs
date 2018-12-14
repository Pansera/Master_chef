using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public class MachineLaver : IElement
    {
        private bool occuper;
        private bool aLaver;

        public MachineLaver()
        {
        }

        public bool Occuper { get => occuper; set => occuper = value; }
        public bool ALaver { get => aLaver; set => aLaver = value; }

        public void Utiliser()
        {
            Console.WriteLine("La machine à laver est en cours d'utilisation");
        }
    }
}
