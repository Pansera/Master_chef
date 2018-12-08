using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public int TestMethod1()
        {
            Random rnd = new Random();
            int Presence = rnd.Next(100);
            int NbPersonne;
            if (Presence < 50)
            {
                int Groupe = rnd.Next(100);
                
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

    }
}
