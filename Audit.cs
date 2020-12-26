using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Audit
    {
         internal float[] ValidationNumbers(char symbol)
        {
            for (; ; )
            {
                bool a = false;
                string input = Console.ReadLine();
                string[] inputString = input.Split(symbol);
                float[] intArray = new float[inputString.Length];

                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    continue;
                }
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (!float.TryParse(inputString[i], out intArray[i]))
                    {
                        a = true;
                        break;
                    }
                }
                if (a == true)
                {
                    Console.Write("This is not a numeric!Please try again:");
                    continue;
                }
                if (input.Split(symbol).Count() == 1)
                {
                    Console.Write("You enter one numbers.Please try again: ");
                    continue;
                }
                return intArray;
            }
        }
        internal string ValidationData()
        {
            for(; ; )
            {
                bool a = false;
                string[] symbol = { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") " };
                string input = Console.ReadLine();
                string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
                float[] intArray = new float[inputString.Length];
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    continue;
                }
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (!float.TryParse(inputString[i], out intArray[i]))
                    {
                        a = true;
                        break;
                    }
                }
                if (a == true)
                {
                    Console.Write("This is not a numeric!Please try again:");
                    continue;
                }
                if (input.Split(symbol, StringSplitOptions.RemoveEmptyEntries).Count() == 1)
                {
                    Console.Write("You enter one numbers.Please try again: ");
                    continue;
                }
                return input;
            }
        }
    }
}
