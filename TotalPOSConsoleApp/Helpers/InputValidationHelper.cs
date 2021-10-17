using static System.Console;

namespace TotalPOSConsoleApp.Helpers
{
    public static class InputValidationHelper
    {
        /// <summary>
        /// Alerts the user of an invalid entry then gives space to try again.
        /// </summary>
        public static void InvalidEntry()
        {
            WriteLine("Invalid Entry!");
            ConsoleFormattingHelper.NewLines(1);
        }

        /// <summary>
        /// Alerts the user that their entry is required then gives space to try again.
        /// </summary>
        public static void RequiredField()
        {
            WriteLine("This is a required field.");
            ConsoleFormattingHelper.NewLines(1);
        }

        public static bool InputStringRequiredValidator(string input)
        {
            bool validInput = true;
            if (string.IsNullOrWhiteSpace(input))
            {
                validInput = false;
                RequiredField();
            }

            return validInput;
        }

        public static bool InputIntegerRequiredValidator(string input, out int quantity)
        {
            bool validInput = true;
            bool quantityParsed = int.TryParse(input, out quantity);
            if (!quantityParsed || quantity < 1)
            {
                validInput = false;
                InvalidEntry();
            }

            return validInput;
        }

        public static bool InputDecimalRequiredValidator(string input, out decimal price)
        {
            bool validInput = true;
            bool priceParsed = decimal.TryParse(input, out price);
            if (!priceParsed || price < decimal.Zero || price > 9999.99m)
            {
                validInput = false;
                InvalidEntry();
            }

            return validInput;
        }

        public static bool InputPromptValidator(char readChar, out bool promptResponse)
        {
            ConsoleFormattingHelper.NewLines(1);
            bool validInput = false;
            readChar = char.ToUpper(readChar);
            if (Equals(readChar, 'Y') || Equals(readChar, 'N'))
            {
                validInput = true;
            }
            else
            {
                InvalidEntry();
            }
            promptResponse = Equals(readChar, 'Y');
            return validInput;
        }
    }
}
