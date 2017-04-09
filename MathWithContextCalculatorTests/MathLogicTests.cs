using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathWithContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.Tests
{
    [TestClass()]
    public class MathLogicTests
    {
        [TestMethod()]
        public void AddArgListWithContextTest()
        {
            intVariable a = new intVariable("a", 1);
            intVariable b = new intVariable("b", 2);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);
            List<String> argList1 = new List<String>() { "a","+", "b" };
            List<String> argList2 = new List<String>() { "5", "+", "b" };
            List<String> argList3 = new List<String>() { "5" };

            List<String> argList4 = new List<String>() { "5", "+", "1", "+", "1", "+", "1"};
           
            Assert.AreEqual(3, MathLogic.AddOrSubtractArgListWithContext(argList1, context));
            Assert.AreEqual(7, MathLogic.AddOrSubtractArgListWithContext(argList2, context));
            Assert.AreEqual(5, MathLogic.AddOrSubtractArgListWithContext(argList3, context));
            Assert.AreEqual(8, MathLogic.AddOrSubtractArgListWithContext(argList4, context));
        }
    }
}