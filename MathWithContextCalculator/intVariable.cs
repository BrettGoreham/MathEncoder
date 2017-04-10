using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWithContext
{

    //This class is responsible for holding information of one variable.
    //Also responsible for controlling the computation of a variables value.
    public class intVariable
    {
        private int value { get; set; }
        public String name { get; set; }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                this.hasValue = true;
            }
        }

        //used if we can not find the value right
        public Boolean hasValue { get; set; } = false; //default false
        public List<String> args { get; set; } = new List<String>();

        public intVariable(String name, int value)
        {
            this.name = name;
            Value = value;

        }


        public intVariable(String name, List<String> args)
        {
            this.name = name;
            this.args = args;
        }



        public void addToArgsList(List<String> argsList)
        {
            if (args.Count == 0)
            {
                args = argsList;
            }
            else
            {
                // if not empty we need to add a new + sign 
                // case if
                // a = b
                // then a = c without b being computed    now  a = b + c
                args.Add("+");
                args.Concat(argsList);
            }
        }

        //Tries to compute a value for this object based on its arglist.
        //returns true if value is calculated
        //returns false if there is something in its arg list that isnt a number, the varible name is
        //not in the context, or the variable doesnt have a value in the context.
        public Boolean TryComputeValue(Dictionary<String, intVariable> context)
        {
            //if its arg list has something in it that isnt computed yet we cannot compute it yet.
            for (int i = 0; i < args.Count; i += 1)
            {
                int n;
                if (args[i] != "+" && args[i] != "-" &&
                    args[i] != "*" && args[i] != "/" &&
                    args[i] != "(" && args[i] != ")" && args[i] != "^")
                {
                    bool isNumeric = int.TryParse(args[i], out n);

                    if (!isNumeric)
                    {
                        if (!context.ContainsKey(args[i]))
                        {
                            return false;
                        }
                        else
                        {
                            if (!context[args[i]].hasValue)
                            {
                                return false;
                            }
                        }

                    }
                }
            }
            Value = (MathLogic.calculateValueOfArgList(this.args, context));
            this.args = new List<String>();
            return true;
        }
    }
}