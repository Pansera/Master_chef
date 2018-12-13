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
    public class ClientConcretTests
    {
        [TestMethod()]
        public void ArriverTest()
        {
            int testc = new ClientConcret().Arriver();
            Assert.IsTrue(testc > 0 , "The actualCount was not greater than five");
        }
    }
}