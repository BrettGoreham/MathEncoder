﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathWithContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.Tests
{
    [TestClass()]
    public class intVariableTests
    {
        [TestMethod()]
        public void TryComputeValueTest()
        {
            intVariable a = new intVariable("a", 1);
            intVariable b = new intVariable("b", 2);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            intVariable c = new intVariable("c", new List<String>() { "a", "+", "b" });
            context.Add(c.name, c);

            intVariable d = new intVariable("d", new List<String>() { "e", "+", "b" });
            context.Add(d.name, d);

            intVariable e = new intVariable("e", new List<String>() { "1", "+", "2" });
            context.Add(e.name, e);

            intVariable f = new intVariable("f", new List<String>() { "1+2", "+", "2" });
            context.Add(f.name, f);

            Assert.IsTrue(c.TryComputeValue(context));

            Assert.IsFalse(d.TryComputeValue(context)); //is false because e isnt in context with value.
            Assert.IsTrue(e.TryComputeValue(context));


            Assert.IsTrue(d.TryComputeValue(context)); //is true now because e is initialized fully.

            Assert.IsFalse(f.TryComputeValue(context)); // fails because 1+2 isnt a variable or parseable to int.
        }

        [TestMethod()]
        public void TryComputeValueMultiplacationAndDivision()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            intVariable c = new intVariable("c", new List<String>() { "a", "*", "b" });
            context.Add(c.name, c);
            Assert.IsTrue(c.TryComputeValue(context));

            intVariable d = new intVariable("d", new List<String>() { "b", "/", "a" });
            context.Add(d.name, d);
            Assert.IsTrue(d.TryComputeValue(context));

            intVariable e = new intVariable("e", new List<String>() { "9", "/", "3" });
            context.Add(e.name, e);
            Assert.IsTrue(e.TryComputeValue(context));

            intVariable f = new intVariable("f", new List<String>() { "b", "*", "1" });
            context.Add(f.name, f);
            Assert.IsTrue(f.TryComputeValue(context));



        }

        [TestMethod()]
        public void TryComputeValueBracket()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);


            intVariable c = new intVariable("c", new List<String>() { "(", "a", "*", "b", ")" });
            context.Add(c.name, c);
            Assert.IsTrue(c.TryComputeValue(context));

            intVariable d = new intVariable("d", new List<String>() { "(", "a", "+", "b", ")" });
            context.Add(d.name, d);
            Assert.IsTrue(d.TryComputeValue(context));

            intVariable e = new intVariable("e", new List<String>() { "(", "a", "^", "b", ")" });
            context.Add(e.name, e);
            Assert.IsTrue(e.TryComputeValue(context));
        }

        [TestMethod()]
        public void TryComputeValueExponents()
        {
            intVariable a = new intVariable("a", 2);
            intVariable b = new intVariable("b", 4);
            Dictionary<String, intVariable> context = new Dictionary<string, intVariable>();
            context.Add(a.name, a);
            context.Add(b.name, b);

            intVariable c = new intVariable("c", new List<String>() { "a", "^", "b" });
            context.Add(c.name, c);
            Assert.IsTrue(c.TryComputeValue(context));

            intVariable d = new intVariable("d", new List<String>() { "b", "^", "2" });
            context.Add(d.name, d);
            Assert.IsTrue(d.TryComputeValue(context));

            intVariable e = new intVariable("e", new List<String>() { "9", "^", "3" });
            context.Add(e.name, e);
            Assert.IsTrue(e.TryComputeValue(context));

        }

    }
}