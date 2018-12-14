using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public abstract class APosteMobile
    {
        static int id = 0;
        public static int Id { get => id; set => id = value; }
    }
}
