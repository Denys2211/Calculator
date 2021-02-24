using System;
using ConsoleApp;

namespace Audit
{
    internal class Audit_Input: IAudit
    {
        private string Verify { get; set; }
        public string СheckNumericCharacter(string input, string[] symbol)
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
            if(check)
                 Verify = default;
            else
                 Verify = input;
            return Verify;
        }
         public string CheckAvailability( string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("You did not enter numbers to calculate.Please try again. ");
                Verify = default; 
            }
            else
                Verify = input;
            return Verify;
        }
         public string CheckQuantity( string input, string[] symbol)
        {
            if (input.Split(symbol, StringSplitOptions.RemoveEmptyEntries).Length == 1)
            {
                Console.Write("You enter one numbers.Please try again. ");
                Verify = default;
            }
            else
                Verify = input;
            return Verify;
        }
    }    
}
