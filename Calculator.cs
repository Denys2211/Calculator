using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{

    class Calculator
    {

        internal void DataEntry(out string input, out string[] symbol)
        {
            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            input = Console.ReadLine();
        }
        internal void Evaluate(string input, out double result)
        {
            Stack<String> stack = new Stack<String>();

            string value = "";
            for (int j = 0; j < input.Length; j++)
            {
                String symbol = input.Substring(j, 1);
                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }
                if (symbol.Equals("("))
                {
                    string innerExp = "";
                    j++; 
                    int bracketCount = 0;
                    for (; j < input.Length; j++)
                    {
                    symbol = input.Substring(j, 1);

                        if (symbol.Equals("(")) bracketCount++;

                        if (symbol.Equals(")"))
                        {
                            if (bracketCount == 0) break;
                            bracketCount--;
                        }
                        innerExp += symbol;
                    }
                    Evaluate(innerExp, out result);
                    stack.Push(result.ToString());
                }
                else if (symbol.Equals("+") ||
                         symbol.Equals("-") ||
                         symbol.Equals("*") ||
                         symbol.Equals("/"))
                
                    stack.Push(symbol);
                
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (j == (input.Length - 1))
                        stack.Push(value);

                }
            }

            List<String> list = stack.ToList<String>();

            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "*")
                {
                    list[i] = (Convert.ToDouble(list[i + 1]) * Convert.ToDouble(list[i - 1])).ToString();
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i - 1);
                    i -= 1;
                }

                if (list[i] == "/")
                {
                    list[i] = (Convert.ToDouble(list[i + 1]) / Convert.ToDouble(list[i - 1])).ToString();
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i - 1);
                    i -= 1;
                }
            }

            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "+")
                {
                    list[i] = (Convert.ToDouble(list[i + 1]) + Convert.ToDouble(list[i - 1])).ToString();
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i - 1);
                    i -= 1;
                }
          
                if (list[i] == "-")
                {
                    list[i] = (Convert.ToDouble(list[i + 1]) - Convert.ToDouble(list[i - 1])).ToString();
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i - 1);
                    i -= 1;
                }
            }
            stack.Clear();

            result = Convert.ToDouble(list[0]);
        }

        internal void OutputDisplay(double result)
        {
            Console.WriteLine($"Calculation result: {result}");
            Console.ReadKey();
        }
    }
}