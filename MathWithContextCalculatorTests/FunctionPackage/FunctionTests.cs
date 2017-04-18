using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathWithContext.FunctionPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.FunctionPackage.Tests
{
    [TestClass()]
    public class FunctionTests
    {
        [TestMethod()]
        public void FunctionTest()
        {
           // Assert.Fail();
        }
        
        [TestMethod()]
        public void addFunctionPartTest()
        {
            try {
                Random rnd = new Random();
                double exponent = rnd.NextDouble();
                double coefficient = rnd.NextDouble();
                FunctionLinkedListPart a = new FunctionLinkedListPart(coefficient, exponent);

                Function func1 = new Function();
                Function func2 = new Function(a);

                func1.addFunctionPart(a);

                Assert.AreEqual(a, func1.HeadOfFunction);
                Assert.AreEqual(a, func2.HeadOfFunction);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void OrderOfAddedFunctionPartTests()
        {
            List<FunctionLinkedListPart> parts = new List<FunctionLinkedListPart>();

            parts.Add(new FunctionLinkedListPart(5, 5));
            parts.Add(new FunctionLinkedListPart(4, 4));
            parts.Add(new FunctionLinkedListPart(3, 3));
            parts.Add(new FunctionLinkedListPart(2, 2));
            parts.Add(new FunctionLinkedListPart(1, 1));

            Random rnd = new Random();
            List<int> a = Enumerable.Range(0, 5).OrderBy(x => rnd.Next()).Take(5).ToList();

            Function func = new Function();
            foreach (int index in a)
            {
                func.addFunctionPart(parts[index]);
            }


            FunctionLinkedListPart curr = func.HeadOfFunction;
            foreach(FunctionLinkedListPart part in parts)
            {
                Assert.AreEqual(part.Exponent, curr.Exponent);
                curr = curr.Next;
            }

        }

        //TODO: add tests that test both functions we know have roots and dont.
        [TestMethod()]
        public void findRootsTest()
        {
            Random rnd = new Random();
            int xSquared = rnd.Next(-4, 6);
            if (xSquared == 0) {
                xSquared = 1;
            }
            int x = rnd.Next(-10, 10);
            int intercept = 6;
            if (xSquared >= 0)
            {
                intercept = rnd.Next(-10, 0);
            }
            else
            {
                intercept = rnd.Next(0, 10);
            }
            


            List<FunctionLinkedListPart> parts = new List<FunctionLinkedListPart>();
            parts.Add(new FunctionLinkedListPart(xSquared, 2));
            parts.Add(new FunctionLinkedListPart(x, 1));
            parts.Add(new FunctionLinkedListPart(intercept, 0));

            Function func = new Function(parts.ToArray());

            Boolean noRoots = false;
            List<double> roots = new List<double>();
            try {
                roots = func.findRoots();
            }
            catch (Exception e)
            {
                noRoots = true;
            }

            double xCoefSquared = Math.Pow(x, 2);
            double sqrtPart = Math.Sqrt(xCoefSquared - (4 * xSquared * intercept));
            if (Double.IsNaN(sqrtPart) && !noRoots)
            {
                Assert.Fail();
            }
            else
            {
                double roota = ((-1 * (x)) + (sqrtPart)) / (2 * xSquared);
                double rootb = ((-1 * (x)) - (sqrtPart)) / (2 * xSquared);

                List<double> result = new List<double>() { roota, rootb };


                foreach (double root in result)
                {
                    if (!roots.Contains(root))
                    {
                        Assert.Fail();
                    }
                }
            }
            


        }
        /*
        [TestMethod()]
        public void findMinOrMaxTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void DerivePartTest()
        {
            Assert.Fail();
        }*/
    }
}