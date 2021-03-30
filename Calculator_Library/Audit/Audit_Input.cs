using System;
using Calculator;
using Exceptions;

namespace Audit
{
    public class Audit_Input : IAudit
    {
        
        public void СheckNumericCharacter(string input, string[] symbol, out int i)
        {
            i = 0;
            string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            if (inputString.Length == 0 && input.Length !=0)
            {
                throw new AudExceptions("This is not a numeric!"); 
            }
            while (i < inputString.Length)
            {
                char chr = inputString[i].ToCharArray()[0];
                if (!char.IsDigit(chr))
                {
                    throw new AudExceptions("This is not a numeric!");
                }
                i++;
            }
        }
        public void CheckQuantity(string input)
        {
            if (input.Length == 1)
            {

                throw new AudExceptions("You enter one number. ");

            }
        }
        public void CorrectInput(string input, out int countBracket)
        {
            countBracket = 1;
            int checkCount = 0;
            char[] chr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input.Substring(i, 1);
                if (!char.IsDigit(chr[0]) && chr[0] != '(' && chr[0] != ')'&& chr[0] != '-' && chr[0] != '+')
                    checkCount++;
                if (symbol.Equals("("))
                {
                    countBracket++;
                    checkCount++;
                    if (chr[0] != '(' && char.IsDigit(chr[i - 1]))
                        checkCount++;
                }
                if (symbol.Equals(")"))
                {
                    if(checkCount > 0)
                    checkCount--;
                    if (chr[chr.Length - 1] != ')' && char.IsDigit(chr[i + 1]))
                        checkCount++;
                }
                if (symbol.Equals("+") || symbol.Equals("-") || symbol.Equals("/") || symbol.Equals("*"))
                {
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i + 1]) && chr[i + 1] != '(' && chr[i + 1] != ')')
                        checkCount++;
                }
            } 
            if (checkCount != 0 || (chr.Length != 0 && !char.IsDigit(chr[chr.Length - 1]) && chr[chr.Length - 1] != ')') )
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
