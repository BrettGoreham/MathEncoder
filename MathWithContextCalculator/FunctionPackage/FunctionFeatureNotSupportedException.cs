using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext.FunctionPackage
{
    class FunctionFeatureNotSupportedException : Exception
    {
        public FunctionFeatureNotSupportedException()
        {

        }

        public FunctionFeatureNotSupportedException(string message)
            : base(message)
        {

        }
    }
}
