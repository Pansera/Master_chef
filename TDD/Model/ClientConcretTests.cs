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
            Assert.IsTrue(new ClientConcret().Arriver() > 0 & new ClientConcret().Arriver() < 9, "The actualCount was not greater than five");
        }
    }
}