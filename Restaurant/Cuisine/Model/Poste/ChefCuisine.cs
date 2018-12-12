using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine.Model
{
    public sealed class ChefCuisine : APosteFixe
    {
        private int id;
        private static ChefCuisine instance = null;
        private static readonly object padlock = new object();
        public int Id1 { get => id; set => id = value; }
        ChefCuisine() { }

        public static ChefCuisine Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ChefCuisine();
                    }
                    return instance;
                }
            }
        }


        public void getID()
        {
            Id++;
            Id1 = Id;
        }

        public void recoitCommande()
        {

        }

        public void checkStock()
        {

        }
    }
}
