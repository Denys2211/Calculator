using System;

namespace ConsoleApp
{
    internal class Audit_Input: IAudit
    {
         public void СheckNumericCharacter(string input, string[] symbol, out string verify)
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
                verify = default;
            else
                verify = input;
        }
         public void CheckAvailability( string input, out string verify)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("You did not enter numbers to calculate.Please try again. ");
                verify = default; 
            }
            else
            verify = input;
        }
         public void CheckQuantity( string input, string[] symbol, out string verify)
        {
            if (input.Split(symbol, StringSplitOptions.RemoveEmptyEntries).Length == 1)
            {
                Console.Write("You enter one numbers.Please try again. ");
                verify = default;
            }
            else
            verify = input;
        }
    }    
}
