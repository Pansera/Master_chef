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
        //private readonly MaitreHotel UniqueInstance;
        public ClientConcret CL;
        private int check;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();
        private bool tabledispo;

        public void CheckClient()
        {
            check = CL.Arriver();
            if(check < 0)
            {
                //this.VerifieTableDisponible(check);
            }
            else
            {
                check = 0;
            }

        }

        public void AppelIChefRang(bool tabledispo, int check)
        {
            

        }
        /*
        public  VerifieTableDisponible(int check)
        {
            if(check > table4place)
            {
                tablex - check
                tabledispo = true
                this.AppelIChefRang(tabledispo, check)
            }
            else if (4 < check < 8)
            {
                tabley - check;
                tabledispo = true
                this.AppelIChefRang(tabledispo, check)
            }
            else{
                tabledispo = false
                this.AppelIChefRang(tabledispo)
                
            }
            

        }

        public AttribueTable(tabledispo)
        {
            

        }
        
        public int GetPosition()
        {

        }
        public void PlusDePlace()
        {
            int partir = CL.Arriver()
            partir = 0;
        }*/

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

