using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RPNLibrary
{
    [TestFixture]
    class RPNTest
    {
        [Test]
        public static void TestOperations1()
        {
            Assert.AreEqual(3, RPN.CalculateRPN(new List<string> { "-6", "+", "9" }));
        }

        [Test]
        public static void TestOperations2()
        {
            Assert.AreEqual(new List<string> { "6", "9", "+" }, RPN.GetRPNFromList(new List<string> { "6", "+", "9" }));
       }

        [Test]
        public static void TestOperations3()
        {
            Assert.AreEqual(9, 8);
        }
        }
}
