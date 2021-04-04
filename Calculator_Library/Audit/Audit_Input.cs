using System;
using Calculator;
using Exceptions;

namespace Audit
{
    public class Audit_Input : IAudit
    {
        public int CountBracket { get; private set; }

        public int CountNumbers { get; private set; }

        public void СheckNumericCharacter(string input, string[] symbol)
        {
            string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            if (inputString.Length == 0 && input.Length !=0)
            {
                throw new AudExceptions("This is not a numeric!"); 
            }
            while (CountNumbers < inputString.Length)
            {
                char chr = inputString[CountNumbers].ToCharArray()[0];
                if (!char.IsDigit(chr))
                {
                    throw new AudExceptions("This is not a numeric!");
                }
                CountNumbers++;
            }
        }
        public void CheckQuantity(string input)
        {
            if (input.Length == 1)
            {

                throw new AudExceptions("You enter one number. ");

            }
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
                    if (chr[0] != '(' && char.IsDigit(chr[i - 1]))
                        checkCount++;
                }
                if (symbol.Equals(")"))
                {
                    if(checkCount > 0)
                    checkCount--;
                    if (chr[^1] != ')' && char.IsDigit(chr[i + 1]))
                        checkCount++;
                }
                if (symbol.Equals("+") || symbol.Equals("-") || symbol.Equals("/") || symbol.Equals("*"))
                {
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i + 1]) && chr[i + 1] != '(' && chr[i + 1] != ')')
                        checkCount++;
                }
            } 
            if (checkCount != 0 || (chr.Length != 0 && !char.IsDigit(chr[^1]) && chr[^1] != ')') )
            {

                throw new AudExceptions("Not the correct expression. ");

            }
        }
        public void CheckAvailability(string input)
        {
            if (input == string.Empty)
            {
                throw new AudExceptions("You did not enter numbers to calculate. ");
            }
        }
    }
}
