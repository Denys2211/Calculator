using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Audit
    {
        internal void СheckNumericCharacter(string input, string[] symbol, out string verify)
        {
            bool check = false; 
            string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            float[] intArray = new float[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!float.TryParse(inputString[i], out intArray[i]))
                {
                    Console.Write("This is not a numeric!Please try again. ");
                    check = true;
                }
            }
            if(check == true)
                verify = "false";
            else
                verify = input;
        }
        internal void CheckAvailability( string input, out string verify)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("You did not enter numbers to calculate.Please try again. ");
                verify = "false"; 
            }
            else
            verify = input;
        }
        internal void CheckQuantity( string input, string[] symbol, out string verify)
        {
            if (input.Split(symbol, StringSplitOptions.RemoveEmptyEntries).Count() == 1)
            {
                Console.Write("You enter one numbers.Please try again. ");
                verify = "false";
            }
            else
            verify = input;
        }
    }    
}
