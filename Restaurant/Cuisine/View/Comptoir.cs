using Restaurant.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{

    class Comptoir : IObservateur
    {
        
        public static bool finJournee = true;
        protected static AbstractControler controler;

        //Instancie le serveur socket qui permettra d'envoyer et de recevoire les commandes
        public static Client Commande = new Client();


        public Comptoir(AbstractControler controler) 
        {
            Comptoir.controler = controler;

            //Lance en asychrone dans un thread de pool la methode "ReceptionThread"
            Task.Run(() => ReceptionThread());

            //Thread newThread = new Thread(new ThreadStart(ComptoirThread));
            // newThread.Start();

        }

        

        /*public void ComptoirThread()
        {
            Observer.WaitConnect();
            Task.Run(() => ReceptionThread());
   
        }*/

        //Ecoute en continue sur le socket
        public static void ReceptionThread()
        {
            while (true)
            {
                if (finJournee)
                    Commande.Receive(controler);
                

            }
        }

        
        //Recoi grâce a l'observer les plats et les envoie
        public void Notifier(string data)
        {
            Commande.Send(data);
        }

       
    }


}
