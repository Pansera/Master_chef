using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle
{
    public class MaitreHotel
    {
        //private string nom;
        //private string prenom;
        //private readonly MaitreHotel UniqueInstance;
        public ClientConcret CL;
        public int check;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();
        private bool tabledispo;
        private object tables8;
        private object tables4;
        public Table TB;


        public void CheckClient(int check)
        {
            check = CL.Arriver();

            if(check > 1)
            {
               this.VerifieTableDisponible(check);
            }
            

        }

        public void AppelIChefRang(bool tabledispo, int check)
        {
            

        }
        
        public void VerifieTableDisponible(int check)
        {
                    
            if(check <= 4)
            {
                tables4 = TB.Table4p();
               // int exiawin = .FindIndex(p => p.nbPlace <= 4);
                //Console.WriteLine(exiawin);
                tabledispo = true;
                    this.AppelIChefRang(tabledispo, check)
            }
            else if (check < 8)
            {
                table8 = TB.Table8p();
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

        public MaitreHotel()
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

