using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    sealed class MaitreHotel
    {
        private string nom;
        private string prenom;
        //private readonly MaitreHotel UniqueInstance;
        public ClientConcret CL;
        private int check;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();

        public int CheckClient()
        {
            check = CL.Arriver();
            return check;

        }

        public AppelIChefRang()
        {
            

        }

        public VerifieTableDisponible()
        {

        }

        public AttribueTable()
        {
            int var = CheckClient();
            if(var < 1)
            {
                var = 0;
            }

        }
        
        public int GetPosition()
        {

        }

        MaitreHotel()
        {

        }

        public static MaitreHotel GetInstance()
        {
            lock (padlock)
            {
                    if (instance == null)
                    {
                        instance = new MaitreHotel();
                    }
                    return instance;
            }
            
        }

    }

    }
}
