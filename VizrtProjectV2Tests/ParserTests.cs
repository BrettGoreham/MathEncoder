using Microsoft.VisualStudio.TestTools.UnitTesting;
using VizrtProjectV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizrtProjectV2.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void parseInputLineToNameAndArgListTest()
        {
            String line = "a = 1 + 2";

            String name;
            List<String> args;

            Parser.parseInputLineToNameAndArgList(line, out name, out args);

            Assert.AreEqual("a", name);
            Assert.AreEqual("1", args[0]);
            Assert.AreEqual("+", args[1]);
            Assert.AreEqual("2", args[2]);
        }
    }
}