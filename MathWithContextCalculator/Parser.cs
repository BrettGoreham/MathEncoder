using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizrtProjectV2
{
    //This class is based on Parsing input from the user.
    public static class Parser
    {
        public static void parseInputLineToNameAndArgList(String inputLine, 
                                                         out String name, out List<String> ArgList)
        {
            string[] components = inputLine.Split(' ');

            name = components[0];
            ArgList = new List<String>();
            for (int i = 2; i < components.Length; i++)
            {
                //I was having a bit of trouble of the file having spaces or the split method
                // giving componenets that were "" or " "
                //probably from copy and pasting the file into notepad
                if (!(components[i] == " " || components[i] == ""))
                {
                    ArgList.Add(components[i]);
                }
            }
        }
    }
}
