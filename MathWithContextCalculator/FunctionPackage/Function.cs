using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.FunctionPackage
{
    public class Function
    {

        public Function(params FunctionLinkedListPart[] parts)
        {
            foreach(FunctionLinkedListPart part in parts)
            {
                addFunctionPart(part);
            }
        }

        private FunctionLinkedListPart headOfFunction;
        public FunctionLinkedListPart HeadOfFunction
        {
            get { return headOfFunction; }
            set { headOfFunction = value; }
        }

        public void addFunctionPart(FunctionLinkedListPart toAdd)
        {
            if (headOfFunction == null)
            {
                headOfFunction = toAdd;
            }
            else {
                if(headOfFunction.Exponent < toAdd.Exponent)
                {
                    toAdd.Next = headOfFunction;
                    headOfFunction = toAdd;
                }
                else
                {
                    FunctionLinkedListPart curr = headOfFunction;
                    Boolean isFound = false;
                    while(curr.Next != null && !isFound)
                    {
                        if (curr.Next.Exponent < toAdd.Exponent)
                        {
                            toAdd.Next = curr.Next;
                            curr.Next = toAdd;
                            isFound = true;
                        }
                        else if ( curr.Next.Exponent == toAdd.Exponent)
                        {
                            curr.Next.Exponent += toAdd.Exponent;
                            isFound = true;
                        }
                        curr = curr.Next;
                    }

                    if (!isFound)
                    {
                        curr.Next = toAdd;
                    }
                }
            }
        }

        public List<Double> findRoots()
        {
            FunctionLinkedListPart curr = this.headOfFunction;

            if (curr.Exponent > 2)
            {
                throw new FunctionFeatureNotSupportedException(
                       "Unable to find roots unless funtion is quadratic or lower");
            }

            double xSquaredCoef = 0;
            double xCoef = 0;
            double intercept = 0;
            Boolean functionEmpty = false;
            if (curr.Exponent == 2)
            {
                xSquaredCoef = curr.Coefficient;
                if (curr.Next != null)
                {
                    curr = curr.Next;
                }
                else { functionEmpty = true; }
            }
            if ((!functionEmpty) && curr.Exponent == 1)
            {
                xCoef = curr.Coefficient;
                if (curr.Next != null)
                {
                    curr = curr.Next;
                }
                else { functionEmpty = true; }
            }
            if ((!functionEmpty) && curr.Exponent == 0)
            {
                intercept = curr.Coefficient;
            }

            double xCoefSquared = Math.Pow(xCoef, 2);
            double sqrtPart = Math.Sqrt(xCoefSquared - (4 * xSquaredCoef * intercept));
            if (Double.IsNaN(sqrtPart))
            {
                throw new Exception();
            }

            double roota = ((-1 * (xCoef)) + (sqrtPart)) / (2 * xSquaredCoef);
            double rootb = ((-1 * (xCoef)) - (sqrtPart)) / (2 * xSquaredCoef);

            return new List<double>() { roota, rootb };
        }

        public static double findMinOrMax(int xSquaredCoef, int xCoef, int intercept)
        {
            throw new NotImplementedException("find min or max has not been implemented yet");
        }

        public static void DerivePart(int coefficient, int exponent)
        {
            throw new NotImplementedException("Derive Part has not been implemented yet");
        }
    }
}
