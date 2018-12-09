using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle;

namespace Salle.Test
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
