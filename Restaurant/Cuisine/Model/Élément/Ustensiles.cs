using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    static class Ustensiles 
    {
        private static int couverts = 50;
        private static int assiettes = 50;
        private static int verres = 50;
        private static int couvertsSales = 0;
        private static int assiettesSales = 0;
        private static int verresSales = 0;
        public static int CouvertsPropres { get => couverts; set => couverts = value; }
        public static int AssiettesPropres { get => assiettes; set => assiettes = value; }
        public static int VerresPropres { get => verres; set => verres = value; }
        public static int CouvertsSales { get => couvertsSales; set => couvertsSales = value; }
        public static int AssiettesSales { get => assiettesSales; set => assiettesSales = value; }
        public static int VerresSales { get => verresSales; set => verresSales = value; }
    }
}
