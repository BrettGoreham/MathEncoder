using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext
{
    //This class is responsible for all code that impliments the main algorithm
    public class Program
    {
        private static Dictionary<String, intVariable> Context = new Dictionary<string, intVariable>();
        private static List<intVariable> toCompute = new List<intVariable>();
        static void Main(string[] args)
        {                
            string line;
            //while ((line = file.ReadLine()) != null)
            while (true)
            {
                line = Console.ReadLine();
                ParseAndAttemptComputeEquations(line);
            }
            
        }

        //returns all equations that get computed because of addition of equation
        public static List<intVariable> ParseAndAttemptComputeEquations(String line)
        {
            String VariableName;
            List<String> ArgList;

            Parser.parseInputLineToNameAndArgList(line, out VariableName, out ArgList);
            intVariable current;
            if (Context.ContainsKey(VariableName))
            {
                current = Context[VariableName];
                current.addToArgsList(ArgList);
                //Reassignment of a value
            }
            else
            {
                current = new intVariable(VariableName, ArgList);
                Context.Add(current.name, current);
                //New Variable being assigned to
            }
            toCompute.Add(current);
            return computeAndReturnAllFullyInitialized(toCompute, Context);
        }

        //Compute all variables values in the list that can be completed with the context.
        //If the value is computed it is removed from the list.
        public static List<intVariable> computeAndReturnAllFullyInitialized(List<intVariable> toCompute, Dictionary<String, intVariable> Context)
        {
            List<intVariable> computedVariables = new List<intVariable>();
            int count = 0;
            while (count < toCompute.Count)
            {
                intVariable compute = toCompute[count];
                if (compute.TryComputeValue(Context))
                {
                    Console.WriteLine("===> " + compute.name + " = " + compute.Value);
                    computedVariables.Add(compute);
                    toCompute.Remove(compute);
                    count = 0; //reset count because this may give us ability to compute new things :D
                }
                else {
                    count++;
                }
            }

            return computedVariables;
        }
    }
}
