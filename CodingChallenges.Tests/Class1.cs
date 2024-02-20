using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Numatic.Apps.CodingChallenges.Tests
{

    [TestClass]
    public class Class1
    {

        [TestMethod]
        public void TestMethod()
        {

            bool temp = false;

            Assert.IsFalse(temp, "Temp must be false");

        }

    }
}
