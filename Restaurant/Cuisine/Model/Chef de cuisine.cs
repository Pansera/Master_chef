using SocketTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class Chef_de_cuisine : AbstractModel
    {

        public Chef_de_cuisine()
        {
            
            //Instancier les thread pour le cuisinier et le commis
            Thread CuisinierThread = new Thread(() => new Cuisinier());
            CuisinierThread.Start();

            Thread CommisThread = new Thread(() => new Commis());
            CommisThread.Start();
            
        }

        //Récupère les commande et les transmet
        public override void getCommande(string result)
        {
            this.commande = result;
            Console.WriteLine(commande);
            Thread.Sleep(5000);
            notifierObservateurs(commande);
        }

      
    }
}
