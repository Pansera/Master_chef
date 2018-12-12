using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle
{
    public class Table
    {
        public int nbPlace { get; set; }

        public int Id { get; set; }

        public bool Pain { get; set; }

        public bool Eau { get; set; }

        public bool Tabledispo { get; set; }

        public ListTable LTB = new ListTable();

        public List<Table> Quatre;

        public List<Table> Huit;

        public override string ToString()
        {
            return "ID: " + Id + "   Nombre de place: " + nbPlace + "    Pain = " + Pain + "    Eau = " + Eau + "    Table dispo = " + Tabledispo;
        }


        public Table()
        {
          

        }

        public List<Table> GetTable4()
        {
            Quatre = LTB.Table4p();
            return Quatre;
        }
        public List<Table> GetTable8()
        {
            Huit = LTB.Table8p();
            return Huit;
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
