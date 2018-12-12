using Salle.Model;
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
        public int resetClient;
        private static MaitreHotel instance = null;
        private static readonly object padlock = new object();
        private bool tabledispo;
        private ChefRang CR = new ChefRang();

        public Table TB;
        public ListTable place = new ListTable();

        

        public void CheckClient(int check)
        {
            check = CL.Arriver();

            if(check > 1)
            {
               this.VerifieTableDisponible(check);
            }
        }

        public void AppelIChefRang(List<Table> test, int check)
        {
            Table reserver = test.Where(i => i.Tabledispo == true).First();
            var index = test.IndexOf(reserver);
            test[index] = new Table() { Tabledispo = false };
            resetClient = CL.Arriver();
            resetClient = 0;
            CR.AccompagneClient(test, check);
           
        }
        
        public void VerifieTableDisponible(int check)
        {
            if(check <= 4)
            {
                List<Table> test = TB.GetTable4();
                int exiawin = test.FindIndex(p => p.Tabledispo == true);
                if (exiawin == 0)
                {
                    this.AppelIChefRang(test, check);
                }
                else
                {
                    List<Table> test2 = TB.GetTable8();
                    int exiawin2 = test2.FindIndex(p => p.Tabledispo == true);
                    if (exiawin2 == 0)
                    {
                        this.AppelIChefRang(test2, check);
                    }
                    else
                    {
                        Console.WriteLine("Navrée Monsieur, nous avons plus de place.");
                    }
                }
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

