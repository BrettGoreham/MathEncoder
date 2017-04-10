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
    public class ProgramTests
    {

        [TestMethod()]
        public void computeAndRemoveAllFullyInitializedTestAdditionSubtraction()
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
            
            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            ////c=3 d uncomputed
            Assert.AreEqual(1, toCompute.Count);


            intVariable f = new intVariable("f", new List<String>() { "c", "+", "b" });
            context.Add(f.name, f);
            toCompute.Add(f);

            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            //c = 3 f  = 5 d is uncomputed
            Assert.AreEqual(1, toCompute.Count);


            intVariable e = new intVariable("e", new List<String>() { "f", "+", "c" });
            context.Add(e.name, e);
            toCompute.Add(e);

            Program.computeAndReturnAllFullyInitialized(toCompute, context);
            //e = 8 d = 10
            Assert.AreEqual(0, toCompute.Count);

            Assert.AreEqual(1, a.Value);
            Assert.AreEqual(2, b.Value);
            Assert.AreEqual(3, c.Value);
            Assert.AreEqual(10, d.Value);
            Assert.AreEqual(8, e.Value);
            Assert.AreEqual(5, f.Value);
        }


        [TestMethod()]
        public void computeAndRemoveAllFullyInitializedTestExponents()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            Random rnd = new Random();
            int first = rnd.Next(0, 10);
            int second = rnd.Next(0, 10);

            intVariable c = new intVariable("c", new List<String>() { "a", "^", "b" });
            context.Add(c.name,c);

            intVariable d = new intVariable("d", new List<String>() { "2", "^", "b" });
            context.Add(d.name, d);

            intVariable e = new intVariable("e", new List<String>() { first.ToString(), "^", second.ToString() });
            context.Add(e.name, e);

            List<intVariable> toCompute = new List<intVariable>() { c, d, e };

            
            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            Assert.AreEqual(16, c.Value);
            Assert.AreEqual(16, d.Value);
            Assert.AreEqual((int)Math.Pow(first,second), e.Value);
        }



        [TestMethod()]
        public void computeAndRemoveAllFullyInitializedTestBrackets()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            Random rnd = new Random();
            int first = rnd.Next(0, 10);
            int second = rnd.Next(0, 10);

            intVariable c = new intVariable("c", new List<String>() {"(", "a", "^", "b", ")" });
            context.Add(c.name, c);

            intVariable d = new intVariable("d", new List<String>() {"(", "2", "*", "b", ")" });
            context.Add(d.name, d);

            intVariable e = new intVariable("e", new List<String>() {"(", first.ToString(), "+", second.ToString(), ")"});
            context.Add(e.name, e);

            List<intVariable> toCompute = new List<intVariable>() { c, d, e };


            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            Assert.AreEqual(16, c.Value);
            Assert.AreEqual(8, d.Value);
            Assert.AreEqual(first + second, e.Value);


            intVariable complex = new intVariable("complex", new List<String>()
                                        { "(", "a", "^", "b", "+", "(", "a", "*", "b", "+", "1", ")", ")" });
            context.Add(complex.name, complex);
            toCompute.Add(complex);

            int expected = (((int)Math.Pow(a.Value, b.Value)) + ( a.Value * b.Value + 1 ) ) ;

            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            Assert.AreEqual(expected, complex.Value);

        }



        [TestMethod()]
        public void computeAndRemoveAllFullyInitializedTestMultiplcationAndDivision()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            Random rnd = new Random();
            int first = rnd.Next(0, 10);
            int second = rnd.Next(0, 10);

            intVariable c = new intVariable("c", new List<String>() { "a", "*", "b" });
            context.Add(c.name, c);

            intVariable d = new intVariable("d", new List<String>() { "b", "/", "2" });
            context.Add(d.name, d);

            intVariable e = new intVariable("e", new List<String>() { first.ToString(), "*", second.ToString() });
            context.Add(e.name, e);

            List<intVariable> toCompute = new List<intVariable>() { c, d, e };


            Program.computeAndReturnAllFullyInitialized(toCompute, context);

            Assert.AreEqual(8, c.Value);
            Assert.AreEqual(2, d.Value);
            Assert.AreEqual(first * second, e.Value);
        }
    }
}