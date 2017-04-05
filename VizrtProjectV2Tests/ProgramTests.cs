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
    public class ProgramTests
    {

        [TestMethod()]
        public void computeAndRemoveAllFullyInitializedTest()
        {
            intVariable a = new intVariable("a", 1);
            intVariable b = new intVariable("b", 2);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            intVariable c = new intVariable("c", new List<String>() {"a", "+", "b" } );
            context.Add(c.name, c); 

            intVariable d = new intVariable("d", new List<String>() { "e", "+", "b" });
            context.Add(d.name, d);
            List<intVariable> toCompute = new List<intVariable>() { c, d };
            
            Program.computeAndRemoveAllFullyInitialized(toCompute, context);

            ////c=3 d uncomputed
            Assert.AreEqual(1, toCompute.Count);


            intVariable f = new intVariable("f", new List<String>() { "c", "+", "b" });
            context.Add(f.name, f);
            toCompute.Add(f);

            Program.computeAndRemoveAllFullyInitialized(toCompute, context);

            //c = 3 f  = 5 d is uncomputed
            Assert.AreEqual(1, toCompute.Count);


            intVariable e = new intVariable("e", new List<String>() { "f", "+", "c" });
            context.Add(e.name, e);
            toCompute.Add(e);

            Program.computeAndRemoveAllFullyInitialized(toCompute, context);
            //e = 8 d = 10
            Assert.AreEqual(0, toCompute.Count);

            Assert.AreEqual(1, a.getValue());
            Assert.AreEqual(2, b.getValue());
            Assert.AreEqual(3, c.getValue());
            Assert.AreEqual(10, d.getValue());
            Assert.AreEqual(8, e.getValue());
            Assert.AreEqual(5, f.getValue());
        }
    }
}