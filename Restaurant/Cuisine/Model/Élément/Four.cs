using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public class Four : IElement
    {
        private bool occuper;
        private bool aLaver;

        public Four()
        {
        }

        public bool ALaver { get => aLaver; set => aLaver = value; }
        public bool Occuper { get => occuper; set => occuper = value; }

        public void Utiliser()
        {
            Console.WriteLine("Le four est en cours d'utilisation");
        }
    }
}
