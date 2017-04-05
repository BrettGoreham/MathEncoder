using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizrtProjectV2
{
    //This class is based on all Math Logic needed to find a value for an arglist
    //Can add more Math as needed and more operations via the swtich statement.
    public static class MathLogic
    {

        public static int calculateValueOfArgList(List<String> argList, Dictionary<String, intVariable> context)
        {
            SearchAndCalulateBrackets(argList, context);

            SearchAndCalculateMultiplicationAndDivision(argList, context);
            
            return AddOrSubtractArgListWithContext(argList, context);
        }





        //Calculates the arg list based on context.
        //This method assumes that all variables in an equation have been intialized in the context.
        public static int AddOrSubtractArgListWithContext(List<String> argList, Dictionary<String, intVariable> context)
        {

            //assuming that args list has right amount of parameters
            String operation = "base";
            int value = 0;
            for (int i = 0; i < argList.Count; i++)
            {
                if (argList[i] == "(")
                {
                    ComputeValueOfBracket(argList, context, i);
                }
                switch (operation)
                {
                    case "base":
                        {

                            value = getValueFromString(argList[i], context);
                            operation = "operation";
                            break;
                        }
                    case "operation":
                        {
                            operation = argList[i];
                            break;
                        }
                    case "+":
                        {
                            value = value + getValueFromString(argList[i], context);
                            operation = "operation";
                            
                            break;
                        }
                    case "-":
                        {
                            value = value - getValueFromString(argList[i], context);
                            operation = "operation";
                            break;
                        }

                }
            }

            return value;
        }

        private static void SearchAndCalculateMultiplicationAndDivision(List<string> argList, Dictionary<string, intVariable> context)
        {
            for (int i = 0; i < argList.Count; i++)
            {
                if (argList[i] == "*")
                {
                    int value = getValueFromString(argList[i - 1], context) * 
                                    getValueFromString(argList[i+1], context);

                    argList.RemoveRange(i - 1, 3);
                    argList.Insert(i - 1, value.ToString());
                    i--;
                }

                if (argList[i] == "/")
                {
                    int value = getValueFromString(argList[i - 1], context) /
                                    getValueFromString(argList[i + 1], context);

                    argList.RemoveRange(i - 1, 3);
                    argList.Insert(i - 1, value.ToString());
                    i--;
                }
            }
        }


        private static void SearchAndCalulateBrackets(List<string> argList, Dictionary<string, intVariable> context)
        {
            int count = 0;
            while(count < argList.Count)
            {
                if(argList[count] == "(")
                {
                    ComputeValueOfBracket(argList, context, count);
                }
                count++;
            }
        }

        private static void ComputeValueOfBracket(List<String> argList, Dictionary<String, intVariable> context, 
                                                    int startIndexOfBracket)
        {
           
            Boolean IsNotFound = true;
            int indexOfNextBracket = startIndexOfBracket + 1;
            while (IsNotFound)
            {

                if(argList[indexOfNextBracket] == "(")
                {
                    ComputeValueOfBracket(argList, context, indexOfNextBracket);
                }

                if(argList[indexOfNextBracket] == ")")
                {
                    List<String> insideBracket = 
                        argList.GetRange(startIndexOfBracket + 1, indexOfNextBracket - startIndexOfBracket - 1);

                    int ValueOfBrackets = AddOrSubtractArgListWithContext(insideBracket, context);
                    
                    //remove Bracket from the argument list and replace it with the value of the bracket.
                    argList.RemoveRange(startIndexOfBracket, (indexOfNextBracket - startIndexOfBracket)  + 1); 
                    //isnt inclusive so remove up to next bracket + 1

                    argList.Insert(startIndexOfBracket, ValueOfBrackets.ToString());
                    IsNotFound = false;
                }
                indexOfNextBracket++;
            }
            return;
        }

        private static int getValueFromString(String s, Dictionary<String, intVariable> context)
        {
            if (context.ContainsKey(s))
            {
                return context[s].getValue();
            }
            else
            {
                return Int32.Parse(s);
            }
        }
    }
}
