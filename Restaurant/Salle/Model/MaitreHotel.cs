using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    class MaitreHotel
    {
        private string nom;
        private string prenom;
        private readonly MaitreHotel UniqueInstance;
        public ClientConcret CL;
        private int check;

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

        private MaitreHotel()
        {

        }

        public MaitreHotel GetInstance()
        {

        }

    }
}
