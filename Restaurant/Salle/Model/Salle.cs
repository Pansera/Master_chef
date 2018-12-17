using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    class Salle : AbstractModel
    {
        public Salle()
        {
            List<Table> tables4p = new List<Table>();
            List<Table> tables8p = new List<Table>();
            for (int i = 0; i < 10; i++)
            {
                tables4p.Add(new Table() { Id = i, nbPlace = 4, Eau = false, Pain = false });
            }
            for (int i = 0; i < 3; i++)
            {
                tables8p.Add(new Table() { Id = i, nbPlace = 8, Eau = false, Pain = false });
            }
        }

        public override void getCommande(string result)
        {
            throw new NotImplementedException();
        }
    }
}
