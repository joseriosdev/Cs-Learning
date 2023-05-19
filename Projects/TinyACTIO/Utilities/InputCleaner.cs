using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyACTIO.Utilities
{
    public class InputCleaner
    {
        public static InputValidatorWrapper IsValidValue(string input, string[] validValues)
        {
            var validator = new InputValidatorWrapper() { IsValid = false, NewInput = null };
            while (validator.IsValid == false)
            {
                foreach (string value in validValues)
                    if (value == input) validator.IsValid = true;

                if (validator.IsValid) break;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter a valid value");
                Console.ResetColor();
                input = Console.ReadLine();
                input = RemoveNull(input);
                validator.NewInput = input;
            }
            return validator;
        }
        public static int TransformToInt(string input)
        {
            int num;

            while (true)
            {
                try
                {
                    num = Int32.Parse(input);
                    return num;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please, enter a number");
                    Console.ResetColor();
                    input = Console.ReadLine();
                    input = RemoveNull(input);
                }
            }
        }
        static public string RemoveNull(string? input)
        {
            while (true)
            {
                if (input != null)
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a value");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
        }
    }
}
