using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    class Table
    {
        private int id;
        private int nbPlace;
        private bool pain;
        private bool eau;

        public int Id { get => id; set => id = value; }
        public int NbPlace { get => nbPlace; set => nbPlace = value; }
        public bool Pain { get => pain; set => pain = value; }
        public bool Eau { get => eau; set => eau = value; }
        
        public object TB4P { get; set; }
        public object TB8P { get; set; }

        public Table()
        {
            Id = id;
            NbPlace = nbPlace;
            Pain = pain;
            Eau = eau;

        }

        

    public object Table4place()
        {
            for (int i = 0; i < 10; i++)
            {
                 TB4P = new Table() { Id = i, Eau = false, Pain = false, NbPlace = 4 };
            }
            
             return TB4P;
        }

        public object Table8place()
        {
            for (int z = 0; z < 2; z++)
            {
                TB8P = new Table() { Id = z, Eau = false, Pain = false, NbPlace = 4 };
            }
            
            return TB8P;
        }
        
        


        /*
         This code produces the following output:

         0
        */

        /*public Table()
{


}*/

        /*
        
        private Point position()
        {

        }



        public getPosition()
        {

        }
*/

    }
}
