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
    public class CreateurTests
    {
        [TestMethod()]
        public void FactoryMethodTest()
        {
            Assert.Equals(1, new Createur().FactoryMethod());
        }
    }
}