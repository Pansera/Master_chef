using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cuisine.Model
{
    class Plongeur : APosteMobile
    {
        private bool allumer = false;
        private bool check = false;
        private bool etatLaveVaiselle;
        private int id = 0;
        public int Id1 { get => id; set => id = value; }
        public bool Allumer { get => allumer; set => allumer = value; }

        public void getID()
        {
            Id++;
            Id1 = Id;
        }

        public void Start()
        {
            if(Id1 == 0)
            {
                getID();
            }
            Thread thCheck = new Thread(allumeLaveVaiselle);
        }

        public bool checkLavaiselle()
        {
            return LaveVaiselle.Occuper;
        }

        public void allumeLaveVaiselle()
        {
            while (Allumer == true)
            {
                rempliLaveVaiselle();
                Thread.Sleep(1000);
                LaveVaiselle.Start();
                Thread.Sleep(10000);
                videLavevaiselle();
                Thread.Sleep(1000);
            }
        }

        public void eteintLaveVaiselle()
        {
            LaveVaiselle.Stop();
            Allumer = false;
        }

        public void rempliLaveVaiselle()
        {
            if (LaveVaiselle.AssiettesALaver > 24 && LaveVaiselle.Occuper ==false)
            {
                Console.WriteLine("Impossible de remplir le lave-vaiselle, trop d'assiettes à laver");
            }
            else
            {
                LaveVaiselle.AssiettesALaver = Ustensiles.AssiettesSales + LaveVaiselle.AssiettesALaver;
                Ustensiles.AssiettesSales = 0;
                Console.WriteLine("Les assiettes sales sont dans le lave-vaiselle");

            }
            if (LaveVaiselle.CouvertsALaver > 24 && LaveVaiselle.Occuper == false)
            {
                Console.WriteLine("Impossible de remplir le lave-vaiselle, trop d'assiettes à laver");
            }
            else
            {
                LaveVaiselle.CouvertsALaver = Ustensiles.CouvertsSales + LaveVaiselle.CouvertsALaver;
                Ustensiles.CouvertsSales = 0;
                Console.WriteLine("Les verres sales sont dans le lave-vaiselle");

            }
            if (LaveVaiselle.VerresALaver > 24 && LaveVaiselle.Occuper == false)
            {
                Console.WriteLine("Impossible de remplir le lave-vaiselle, trop d'assiettes à laver");
            }
            else
            {
                LaveVaiselle.VerresALaver = Ustensiles.VerresSales + LaveVaiselle.VerresALaver;
                Ustensiles.VerresSales = 0;
                Console.WriteLine("Les verres sales sont dans le lave-vaiselle");
            }
        }

        public void videLavevaiselle()
        {
            if(LaveVaiselle.AssiettesPropres == 0)
            {
                Console.WriteLine("Pas d'assiettes à ranger");
            }
            else
            {
                Ustensiles.AssiettesPropres = LaveVaiselle.AssiettesPropres;
                LaveVaiselle.AssiettesPropres = 0;
            }
            if (LaveVaiselle.CouvertsPropres == 0)
            {
                Console.WriteLine("Pas de couverts à ranger");
            }
            else
            {
                Ustensiles.CouvertsPropres = LaveVaiselle.CouvertsPropres;
                LaveVaiselle.CouvertsPropres = 0;
            }
            if (LaveVaiselle.VerresPropres == 0)
            {
                Console.WriteLine("Pas de verres à ranger");
            }
            else
            {
                Ustensiles.VerresPropres = LaveVaiselle.VerresPropres;
                LaveVaiselle.VerresPropres = 0;
            }
        }
    }
}
