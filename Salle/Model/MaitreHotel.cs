using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static Semaphore _pool;
        private bool CR1dispo = true;
        private bool CR2dispo = true;



        public int placeRestante;

        public Table TB;
        public ListTable place = new ListTable();

        public bool CR1 { get => CR1dispo; set => CR1dispo = value; }
        public bool CR2 { get => CR2dispo; set => CR2dispo = value; }

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
            var idTable = test.IndexOf(reserver);
            if(check < 4)
            {
                placeRestante = 4 - check;
            }
            else
            {
                placeRestante = 8 - check;
            }
            test[idTable] = new Table() { Tabledispo = false };
            test[idTable] = new Table() { nbPlace = placeRestante };
            resetClient = CL.Arriver();
            resetClient = 0;
            //CR.(test, check);
            //_pool = new Semaphore(0, 2);
            if(CR1dispo == true)
            {
                CR1 = false;
                ChefRang a = new ChefRang(idTable, check);
                CR1 = true;
            }
            else
            {
                CR2 = false;
                ChefRang a = new ChefRang(idTable, check);
                CR2 = true;
            }
            
            //_pool.Release();

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

