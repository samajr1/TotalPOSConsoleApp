using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TotalPOSConsoleApp.Helpers
{
    public static class ConsoleFormattingHelper
    {
        /// <summary>
        /// Enters the number of new lines required for proper spacing in the console.  Minimum of 1 new line.
        /// </summary>
        /// <param name="numberOfNewLines"> Expected number of new line characters to inser into the console. </param>
        public static void NewLines(int numberOfNewLines)
        {
            string newLine = "\n";
            for (int i = 1; i < numberOfNewLines; i++)
            {
                newLine = string.Concat(newLine, newLine);
            }

            Write(newLine);
        }

        public static string FormatDecimalPlaces(decimal input)
        {
            return string.Format("{0: 0.00}", input);
        }
    }
}
