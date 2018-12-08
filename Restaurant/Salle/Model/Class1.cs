using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace testThread
{
    public class Horloge
    {
        private static int compteur = 0;
        private static Mutex mut = new Mutex();
        private static bool stopHorloge = false;

        public int Compteur { get => compteur; set => compteur = value; }
        public static bool StopHorloge { get => stopHorloge; set => stopHorloge = value; }

        public void Start()
        {
            StopHorloge = false;
            Console.WriteLine("Création du thread :");
            Thread t = new Thread(StartTemps);
            t.Start();
            Console.WriteLine("t Start");
        }
        public void StartTemps()
        {
            do
            {
                Compteur = Compteur + 1;
                Console.WriteLine(Compteur + " seconde");
                Thread.Sleep(1000);

            } while (StopHorloge == false && Compteur < 20);
        }

        public void StopTemps()
        {
            StopHorloge = true;
        }
        public void reinitTemps()
        {
            Compteur = 0;
        }
        public class Programme
        {
            static void Main()
            {
                Horloge horloge = new Horloge();
                horloge.Start();
            }
        }
    }
}
