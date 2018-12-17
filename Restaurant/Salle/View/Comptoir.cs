using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle
{
    class Comptoir
    {
        public static bool finJournee = true;
        public static Server Commande = new Server();

        public Comptoir()
        {          
            Task.Run(() => Receive());
            Thread.Sleep(8000);
            Commande.Send("testfinal.");
            Thread.Sleep(8000);
            Commande.Send("final.");
            
        }

        public static void Receive()
        {

            while (true)
            {
                if (finJournee)
                    Commande.Receive();
                

            }
        }
    }
}
