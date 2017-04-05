using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizrtProjectV2
{
    //This class is responsible for all code that impliments the main algorithm
    public class Program
    {
        static void Main(string[] args)
        {
            //This variable is the context of the variables
            //it holds all initialized variables whether they are computed or not.
            Dictionary<String, intVariable> Context = new Dictionary<string, intVariable>();
            //This list holds variables that are in the Context but do not have an empty args list.
            List<intVariable> toCompute = new List<intVariable>();
                
            string line;
            //while ((line = file.ReadLine()) != null)
            while (true)
            {
                line = Console.ReadLine();
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
                computeAndRemoveAllFullyInitialized(toCompute, Context);
            }
                //file.Close();
                //Console.ReadLine();
        }

        //Compute all variables values in the list that can be completed with the context.
        //If the value is computed it is removed from the list.
        public static void computeAndRemoveAllFullyInitialized(List<intVariable> toCompute, Dictionary<String, intVariable> Context)
        {
            int count = 0;
            while (count < toCompute.Count)
            {
                intVariable compute = toCompute[count];
                if (compute.TryComputeValue(Context))
                {
                    Console.WriteLine("===> " + compute.name + " = " + compute.getValue());
                    toCompute.Remove(compute);
                    count = 0; //reset count because this may give us ability to compute new things :D
                }
                else {
                    count++;
                }
            }
        }
    }
}
