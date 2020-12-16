using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Audit
    {
         public string ValidationNumbers(char sv)
        {
            for (; ; )
            {                
                bool a = false;
                string input = Console.ReadLine();
                string[] inputString = input.Split(sv);
                int[] intArray = new int[inputString.Length];

                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("You did not enter numbers to calculate.Please try again: ");
                    continue;
                }
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (!int.TryParse(inputString[i], out intArray[i]))
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
                if (input.Split(sv).Count() == 1)
                {
                    Console.Write("You enter one numbers.Please try again: ");
                    continue;
                }
                return input;
            }
        }
    }
}
