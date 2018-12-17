using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Tests
{
    [TestClass()]
    public class MaitreHotelTests
    {
        [TestMethod()]
        public void CheckClientTest()
        {
            int testc = new ClientConcret().Arriver();
            Assert.IsTrue(testc > 1 & testc < 9, "The actualCount was not greater than five");
        }

        [TestMethod()]
        public void AppelIChefRangTest()
        {
            
        }

        [TestMethod()]
        public void GetInstanceTest()
        {
            
        }
    }
}