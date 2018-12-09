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
        ClientConcret CL;
        [DeploymentItem("SalleTests.dll")]
        [TestMethod()]
        public void ArriverTest()
        {
            int test = CL.Arriver();
            Assert.IsTrue(test >= 0 && test <= 6);
        }
    }
}