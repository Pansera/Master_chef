using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{

    public class ListTable
    {
        public static List<Table> tables4p = new List<Table>();
        public static List<Table> tables8p = new List<Table>();

        public List<Table> Table4p()
        {
            for (int i = 0; i < 10; i++)
            {
                tables4p.Add(new Table() { Id = i, nbPlace = 4, Eau = false, Pain = false, Tabledispo = true });
            }
            return tables4p;

        }
        public List<Table> Table8p()
        {

            for (int i = 0; i < 3; i++)
            {
                tables8p.Add(new Table() { Id = i, nbPlace = 8, Eau = false, Pain = false, Tabledispo = true });
            }
            return tables8p;
        }
        

    }
}
