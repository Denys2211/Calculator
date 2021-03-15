using System;
using Calculator;

namespace Audit
{
    internal class Audit_Input : IAudit
    {
        private string Verify { get; set; }
        public string СheckNumericCharacter(string input, string[] symbol)
        {
            bool check = false;
            string[] inputString = input.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            if (inputString.Length == 0 && input.Length !=0)
            {
                Console.Write("This is not a numeric! ");
                check = true;
            }
            for (int i = 0; i < inputString.Length; i++)
            {
                char chr = inputString[i].ToCharArray()[0];
                if (!char.IsDigit(chr))
                {
                    Console.Write("This is not a numeric! ");
                    check = true;
                }
            }
            if (check)
                Verify = default;
            else
                Verify = input;
            return Verify;
        }
        public string CheckQuantity(string input)
        {
            if (input.Length == 1)
            {
                Console.Write("You enter one number. ");
                Verify = default;
            }
            else
                Verify = input;
            return Verify;
        }
        public string CorrectInput(string input)
        {
            int bracketCount = 0;
            char[] chr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input.Substring(i, 1);
                if (!char.IsDigit(chr[0]) && chr[0] != '(' && chr[0] != ')')
                    bracketCount++;
                if (symbol.Equals("("))
                {
                    bracketCount++;
                    if (chr[0] != '(' && char.IsDigit(chr[i - 1]))
                        bracketCount++;
                }
                if (symbol.Equals(")"))
                {
                    bracketCount--;
                    if (chr[chr.Length - 1] != ')' && char.IsDigit(chr[i + 1]))
                        bracketCount++;
                }
                if (symbol.Equals("+") || symbol.Equals("-") || symbol.Equals("/") || symbol.Equals("*"))
                {
                    if (i + 1 < chr.Length && !char.IsDigit(chr[i + 1]) && chr[i + 1] != '(' && chr[i + 1] != ')')
                        bracketCount++;
                }
            } 
            if (bracketCount != 0 || (chr.Length != 0 && !char.IsDigit(chr[chr.Length - 1]) && chr[chr.Length - 1] != ')') )
            {
                Console.Write("Not the correct expression. ");
                Verify = default;
            }
            else
                Verify = input;
            return Verify;
        }
        public string CheckAvailability(string input)
        {
            if (input == string.Empty)
            {
                Console.Write("You did not enter numbers to calculate. ");
                Verify = default;

            }
            else
                Verify = input;
            return Verify;
        }
    }
}
