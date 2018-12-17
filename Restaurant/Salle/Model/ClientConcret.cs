using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    class ClientConcret : IClient
    {
        private bool reservation;
        private bool presser;
        private int nbPersonne;
        private int presence;
        private int groupe;

        public int NbPersonne { get => nbPersonne; set => nbPersonne = value; }
        public int Presence { get => presence; set => presence = value; }
        public int Groupe { get => groupe; set => groupe = value; }

        public int Arriver()
        {
            Random rnd = new Random();
            Presence = rnd.Next(100);
                if (Presence < 50)
                {
                Groupe = rnd.Next(100);
                    if (Groupe < 50)
                    {
                    NbPersonne = rnd.Next(2, 6);
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
        public int Payer()
        {
            return 0;
        }
        public void Commander()
        {

        }

        public void Manger()
        {

        }

        public void Assoir()
        {

        }

        void IClient.Payer()
        {
            throw new NotImplementedException();
        }
    }
}
