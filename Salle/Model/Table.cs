using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    public class Table
    {
        public int nbPlace { get; set; }

        public int Id { get; set; }

        public bool Pain { get; set; }

        public bool Eau { get; set; }

        

        public object Table4p()
        {
            List<Table> tables4p = new List<Table>();
            for (int i = 0; i < 10; i++)
            {
                tables4p.Add(new Table() { Id = i, nbPlace = 4, Eau = false, Pain = false });
            }
            return tables4p;
        }
        public object Table8p()
        {
            List<Table> tables8p = new List<Table>();
            for (int i = 0; i < 3; i++)
            {
                tables8p.Add(new Table() { Id = i, nbPlace = 8, Eau = false, Pain = false });
            }
            return tables8p;
        }


        public Table()
        {
          

        }

     

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
