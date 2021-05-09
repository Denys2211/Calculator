using System;
using Calculator;
using Exceptions;

namespace Audit
{
    public class Audit_Input : IAudit
    {

        public readonly string number_haracter = "This is not a numeric! ";

        public readonly string quantity = "You enter one number! ";

        public readonly string correct_input= "Not the correct expression! ";

        public readonly string availability = "No data to calculate! ";

        public int CountBracket { get; private set; }

        public void СheckNumericCharacter(string input, string[] symbol)
        {
            string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            if (inputString.Length == 0 && input.Length != 0)
            {
                throw new AudExceptions(number_haracter); 
            }
            
        }
        public void CheckQuantity(string input)
        {

            char[] chr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(chr[i]) && chr[i] != ',')
                    return;
            }
                throw new AudExceptions(quantity);

        }
        public void CorrectInput(string input)
        {
            CountBracket = 1;
            int checkCount = 0;
            char[] chr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input.Substring(i, 1);
                if (!char.IsDigit(chr[0]) && chr[0] != '(' && chr[0] != ')'&& chr[0] != '-' && chr[0] != '+')
                    checkCount++;
                if (symbol.Equals("("))
                {
                    CountBracket++;
                    checkCount++;
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i + 1]) && chr[i + 1] !='-' && chr[i + 1] != '(')
                        checkCount++;
                    if (chr[0] != '(' && char.IsDigit(chr[i - 1]))
                        checkCount++;
                    if(i + 2 < chr.Length && chr[i + 2] == ')')
                        checkCount++;
                }
                if (symbol.Equals(")"))
                {
                    checkCount--;
                    if(checkCount < 0)
                        throw new AudExceptions(correct_input);
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i - 1]) && char.IsDigit(chr[i + 1]))
                        checkCount++;
                }

                if (symbol.Equals(","))
                    if (!char.IsDigit(chr[i + 1]))
                        checkCount++;

                if (symbol.Equals("+") || symbol.Equals("-") || symbol.Equals("/") || symbol.Equals("*"))
                {
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i + 1]) && chr[i + 1] != '(' && chr[i + 1] != ')')
                        checkCount++;
                }
            } 
            if (checkCount != 0 || (chr.Length != 0 && !char.IsDigit(chr[^1]) && chr[^1] != ')') )
            {

                throw new AudExceptions(correct_input);

            }
        }
        public void CheckAvailability(string input)
        {

            if (input == string.Empty)
            {
                throw new AudExceptions(availability);
            }
        }
    }
}
