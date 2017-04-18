using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.FunctionPackage
{
    public class FunctionLinkedListPart
    {
        public FunctionLinkedListPart(double coefficient, double exponent)
        {
            this.Coefficient = coefficient;
            this.Exponent = exponent;
        }

        private FunctionLinkedListPart next;
        public FunctionLinkedListPart Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        private double coefficient;
        public double Coefficient
        {
            get
            {
                return coefficient;
            }
            set
            {
                coefficient = value;
            }
        }

        private double exponent;
        public double Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }
    }
}
