using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    public class MaitreHotel
    {
        private string nom;
        private string prenom;
        //private readonly MaitreHotel UniqueInstance;
        public ClientConcret CL;
        private int check;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();
        private bool tabledispo;
        private object table8;
        private object table4;
        //public Table TB;


        public void CheckClient()
        {
            check = CL.Arriver();

            if(check < 0)
            {
                //this.VerifieTableDisponible(check);
            }
            

        }

        public void AppelIChefRang(bool tabledispo, int check)
        {
            

        }
        /*
        public VerifieTableDisponible(int check)
        {
            table8 = TB.Table8place();
            table4 = TB.Table4place();
            if(check <= 4)
            {
                foreach ()
                    tabledispo = true;
                this.AppelIChefRang(tabledispo, check)
            }
            else if (check < 8)
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
        /*
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

