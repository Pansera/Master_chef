using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Salle
{
    public class ClientConcret : IClient
    {
        
        private int nbPersonne;
        private int presence;
        private int groupe;
        //private Serveur SV = new Serveur() ;
        public int NbPersonne { get => nbPersonne; set => nbPersonne = value; }
        public int Presence { get => presence; set => presence = value; }
        public int Groupe { get => groupe; set => groupe = value; }

        public ClientConcret()
        {
            Thread abc = new Thread(() => Manger());
            abc.Start();
            abc.Abort();
        }

        public int Arriver()
        {
            Random rnd = new Random();
            Presence = rnd.Next(100);
                if (Presence < 50)
                {
                Groupe = rnd.Next(100);
                    if (Groupe < 50)
                    {
                    NbPersonne = rnd.Next(2, 10);
                    }
                    else
                    {
                    NbPersonne = 1;
                    }
                }
                else 
                {
                    NbPersonne = 0;
                }
                return NbPersonne;
            
        }
        public int Commander()
        {
            Random rnd = new Random();
            int recette = rnd.Next(0, 10);
            return recette;
        }

        public void Manger()
        {

        }
    }
}
