using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3FItemRenamer
{
    /// <summary>
    /// A collection of static utility methods which implement a simple text-based
    /// user interface.
    /// (Borrowed from a Uni assignment's template)
    /// </summary>
    public class UserInterface
    {

        /// <summary>
        /// Displays a menu, with the options numbered from 1 to options.Length,
        /// the gets a validated integer in the range 1..options.Length. 
        /// Subtracts 1, then returns the result. If the supplied list of options 
        /// is empty, returns an error value (-1).
        /// </summary>
        /// <param name="title">A heading to display before the menu is listed.</param>
        /// <param name="options">The list of objects to be displayed.</param>
        /// <returns>Return value is either -1 (if no options are provided) or a 
        /// value in 0 .. (options.Length-1).</returns>
        public static int GetOption(string title, params object[] options)
        {
            if (options.Length == 0)
            {
                return -1;
            }

            PrintOptions(title, options);

            int option = GetInt($"Please enter a choice between 1 and {options.Length}", 1, options.Length);
            Console.WriteLine();
            return option - 1;
        }

        // Prints a list of options
        public static void PrintOptions(string title, params object[] options)
        {
            int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Length)));

            Console.WriteLine(title);

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadLeft(digitsNeeded)}) {options[i]}");
            }
        }

        /// <summary>
        /// Gets a validated integer between the designated lower and upper bounds.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <param name="min">The lower bound.</param>
        /// <param name="max">The upper bound.</param>
        /// <returns>A value x such that lowerBound <= x <= upperBound.</returns>
        public static int GetInt(string prompt, int min, int max, string errorMsg)
        {
            if (min > max)
            {
                int t = min;
                min = max;
                max = t;
            }

            while (true)
            {
                int result = GetInt(prompt);

                if (min <= result && result <= max)
                {
                    return result;
                }
                else
                {
                    Error(errorMsg);
                }
            }
        }

        // Get an int with a default errror message
        public static int GetInt(string prompt, int min, int max)
        {
            return GetInt(prompt, min, max, "Supplied value is out of range");
        }

        /// <summary>
        /// Gets a validated integer.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <returns>An integer supplied by the user.</returns>
        public static int GetInt(string prompt)
        {
            while (true)
            {
                string response = GetInput(prompt);

                int result;

                if (int.TryParse(response, out result))
                {
                    return result;
                }
                else
                {
                    Error("Supplied value is not an integer");
                }
            }
        }

        /// <summary>
        /// Gets a validated floating point between the designated lower and upper bounds.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <param name="min">The lower bound.</param>
        /// <param name="max">The upper bound.</param>
        /// <returns>A value x such that lowerBound <= x <= upperBound.</returns>
        public static double GetDouble(string prompt, double min, double max, string errorMsg)
        {
            if (min > max)
            {
                double t = min;
                min = max;
                max = t;
            }

            while (true)
            {
                double result = GetDouble(prompt);

                if (min <= result && result <= max)
                {
                    return result;
                }
                else
                {
                    Error(errorMsg);
                }
            }
        }

        // Overload of GetDouble with a default error message
        public static double GetDouble(string prompt, double min, double max)
        {
            return GetDouble(prompt, min, max, "Supplied value is out of range");
        }

        /// <summary>
        /// Gets a validated floating point value.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <returns>A floating point value supplied by the user.</returns>
        public static double GetDouble(string prompt)
        {
            while (true)
            {
                string response = GetInput(prompt);

                double result;

                if (double.TryParse(response, out result))
                {
                    return result;
                }
                else
                {
                    Error("Supplied value is not numeric");
                }
            }
        }


        /// <summary>
        /// Gets a validated Boolean value.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <returns>A Boolean value supplied by the user.</returns>
        public static bool GetBool(string prompt)
        {
            while (true)
            {
                string response = GetInput(prompt);

                bool result;

                if (bool.TryParse(response, out result))
                {
                    return result;
                }
                else if(response.ToLower() == "y" || response.ToLower() == "yes")
                {
                    return true;
                }
                else if(response.ToLower() == "n" || response.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    Error("Invalid response, please enter y or n");
                }
            }
        }




        /// <summary>
        /// Gets a single line of text from user.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <returns>Returns a single line of text from user.</returns>
        public static string GetInput(string prompt)
        {
            Console.Write("{0}: ", prompt);
            return Console.ReadLine();
        }

        // Get input with validation
        public static string GetInput(string prompt, IValidator validator)
        {
            Console.Write("{0}: ", prompt);
            string input = Console.ReadLine();
            if (validator.Validate(input))
                return input;
            else
                return GetInput(prompt, validator);
        }

        /// <summary>
        /// Gets a single line of text from user. The text is processed one
        /// character at a time, and the input is concealed.
        /// </summary>
        /// <param name="prompt">Text used to ask the user for input.</param>
        /// <returns>Returns a single line of text from user.</returns>
        public static string GetPassword(string prompt)
        {
            Console.Write("{0}: ", prompt);
            StringBuilder password = new System.Text.StringBuilder();

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);
                var key = keyInfo.Key;

                if (key == ConsoleKey.Enter)
                    break;
                else if (key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        Console.Write("\b \b");
                        password.Remove(password.Length - 1, 1);
                    }
                }
                else
                {
                    Console.Write("*");
                    password.Append(keyInfo.KeyChar);
                }
            }

            Console.WriteLine();
            return password.ToString();
        }

        // Get Password with validation
        public static string GetPassword(string prompt, IValidator validator)
        {
            string password = GetPassword(prompt);
            if (validator.Validate(password))
                return password;
            return GetPassword(prompt, validator);
        }

        /// <summary>
        /// Displays an error message and asks user to try again.
        /// </summary>
        /// <param name="msg">The message to display</param>
        public static void Error(string msg)
        {
            Console.WriteLine($"{msg}, please try again");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the content of an arbitrary object.
        /// </summary>
        /// <param name="msg">The object to display</param>
        public static void Message(object msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine();
        }
    }
}
