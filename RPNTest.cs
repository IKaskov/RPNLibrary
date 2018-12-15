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
            Assert.AreEqual(27, RPN.CalculateRPN(new List<string> { "9", "+", "9", "+", "9" }));
        }

        [Test]
        public static void TestOperations03()
        {
            Assert.AreEqual(27, RPN.CalculateRPN("9+9+9"));
        }

        [Test]
        public static void TestOperations4()
        {
            Assert.AreEqual(90, RPN.CalculateRPN(new List<string> { "9", "+", "9", "^", "2" }));
        }

        [Test]
        public static void TestOperations04()
        {
            Assert.AreEqual(90, RPN.CalculateRPN("9+9^2"));
        }

        [Test]
        public static void TestOperations5()
        {
            Assert.AreEqual(90, RPN.CalculateRPN("9+Sqrt(81)^2"));
        }

        [Test]
        public static void TestOperations6()
        {
            Assert.AreEqual(18, RPN.CalculateRPN("9--9"));
        }

        [Test]
        public static void TestOperations7()
        {
            Assert.AreEqual(-9, RPN.CalculateRPN("0-9"));
        }

        [Test]
        public static void TestOperations8()
        {
            Assert.AreEqual(4, RPN.CalculateRPN("-2^2"));
        }
    }
}
