using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    class Table
    {
        private int id;
        private int nbPlace;
        //private int nbPlaceOccupe;
        private bool pain;
        private bool eau;

        public int Id { get => id; set => id = value; }
        public int NbPlace { get => nbPlace; set => nbPlace = value; }
        public bool Pain { get => pain; set => pain = value; }
        public bool Eau { get => eau; set => eau = value; }

        public Table()
        {
            List<Table> tables = new List<Table>
            {
                new Table {  Id = 0, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 1, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 2, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 3, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 4, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 5, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 6, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 7, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 8, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 9, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 10, NbPlace = 4, Eau = false, Pain = false},
                new Table {  Id = 11, NbPlace = 8, Eau = false, Pain = false},
                new Table {  Id = 12, NbPlace = 8, Eau = false, Pain = false},
                new Table {  Id = 13, NbPlace = 8, Eau = false, Pain = false},
            }


        }

        /*private bool estOccupe()
        {

        }
        
        private bool eau()
        {

        }

        private Point position()
        {

        }



        public getPosition()
        {

        }

        public getEau()
        {

        }

        public getnbPlace()
        {

        }

        public getnbPlaceOc()
        {

        }

        public getOc()
        {

        }*/

    }
}