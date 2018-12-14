using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    class Serveur
    {
        private Table TB;
        private ClientConcret CC = new ClientConcret);

        public void Dresser(int idTable)
        {
            List<Table> test = TB.GetTable4();
            test[idTable] = new Table() { Pain = true , Eau = true };
            Console.WriteLine("Le serveur à servie du pain et de l'eau à table n°" + idTable);

        }
        public void Debarasser()
        {

        }

        
        public void chercherCommande(int idTable)
        {
            List<Table> test = TB.GetTable4();
            test[idTable] = new Table() { Tableservie = true };
            ClientConcret abc = new ClientConcret(idTable);
         }
               

        

    }
}
