using System.Collections.Generic;
using System.Linq;
using TotalPOSConsoleApp.Helpers;
using static System.Console;

namespace TotalPOSConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to my Total POS system.");
            ConsoleFormattingHelper.NewLines(2);

            /* Begin New Order */
            bool newOrderResponse;
            do
            {
                string name;
                bool validInput;
                do
                {
                    WriteLine("Please enter your name.");
                    name = ReadLine();

                    validInput = InputValidationHelper.InputStringRequiredValidator(name);
                }
                while (!validInput);


                string address;
                do
                {
                    WriteLine("Please enter your address.");
                    address = ReadLine();

                    validInput = InputValidationHelper.InputStringRequiredValidator(address);
                }
                while (!validInput);

                WriteLine("Optional: Please enter your phone number.");
                string phoneNumber = ReadLine();

                /* Line Item ordering */
                Dictionary<KeyValuePair<string, decimal>, int> lineItems = new Dictionary<KeyValuePair<string, decimal>, int>();
                bool newProductResponse;
                do
                {
                    ConsoleFormattingHelper.NewLines(1);
                    string pin;
                    do
                    {
                        WriteLine("Please enter your Product Identifier Number.");
                        pin = ReadLine();

                        validInput = InputValidationHelper.InputStringRequiredValidator(pin);
                    }
                    while (!validInput);

                    int quantity;
                    do
                    {
                        WriteLine("Please enter a quantity. (Minimum 1)");
                        string input = ReadLine();

                        validInput = InputValidationHelper.InputIntegerRequiredValidator(input, out quantity);
                    }
                    while (!validInput);

                    decimal price;
                    do
                    {
                        WriteLine("Please enter a price for this item. ($0-$9999.99)");
                        string input = ReadLine();

                        validInput = InputValidationHelper.InputDecimalRequiredValidator(input, out price);
                    }
                    while (!validInput);

                    lineItems.Add(new KeyValuePair<string, decimal>(pin, price), quantity);
                    ConsoleFormattingHelper.NewLines(2);

                    /* New Product Prompt */
                    do
                    {
                        WriteLine("Would you like to add a new product? (Y/N)");
                        char input = ReadKey(false).KeyChar;
                        validInput = InputValidationHelper.InputPromptValidator(input, out newProductResponse);
                    } while (!validInput);
                }
                while (newProductResponse);
                ConsoleFormattingHelper.NewLines(3);

                /* Display Order Invoice */
                WriteLine("Customer Information");
                WriteLine($"Name:\t\t{name}");
                WriteLine($"Address:\t{address}");
                WriteLine($"Phone:\t\t{phoneNumber}");
                ConsoleFormattingHelper.NewLines(1);

                WriteLine("Order Information");
                foreach (KeyValuePair<KeyValuePair<string, decimal>, int> lineItem in lineItems)
                {
                    WriteLine($"{lineItem.Key.Key}\t${lineItem.Key.Value}/item\t\t({lineItem.Value})\t\t\t\t${ConsoleFormattingHelper.FormatDecimalPlaces(decimal.Round(lineItem.Key.Value * lineItem.Value, 2))}");
                }
                ConsoleFormattingHelper.NewLines(2);

                /* Display Subtotal */
                decimal subTotal = lineItems.Sum(x => x.Key.Value * x.Value);
                WriteLine($"SubTotal:\t${ConsoleFormattingHelper.FormatDecimalPlaces(decimal.Round(subTotal, 2))}");

                /* Display Total */
                WriteLine($"Total:\t\t${ConsoleFormattingHelper.FormatDecimalPlaces(decimal.Round(subTotal * 1.06m, 2))}");

                /* New Order Prompt */
                do
                {
                    ConsoleFormattingHelper.NewLines(2);
                    WriteLine("Would you like to start a new order? (Y/N)");
                    char input = ReadKey(false).KeyChar;
                    validInput = InputValidationHelper.InputPromptValidator(input, out newOrderResponse);
                } while (!validInput);
                ConsoleFormattingHelper.NewLines(2);
            } while (newOrderResponse);

            WriteLine("Thank you for using my Total POS system.");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
