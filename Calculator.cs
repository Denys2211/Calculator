using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
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
                for (int i = 0; i < input.Length; i++)
                {
                    String symbol = input.Substring(i, 1);
                    char chr = symbol.ToCharArray()[0];

                    if (!char.IsDigit(chr) && chr != '.' && value != "")
                    {
                        stack.Push(value);
                        value = "";
                    }
                    if (symbol.Equals("("))
                    {
                        string innerExp = "";
                        i++; 
                        int bracketCount = 0;
                        for (; i < input.Length; i++)
                        {
                        symbol = input.Substring(i, 1);

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
                    {
                        stack.Push(symbol);
                    }
                    else if (char.IsDigit(chr) || chr == '.')
                    {
                        value += symbol;
                        if (i == (input.Length - 1))
                            stack.Push(value);

                    }
                }
                List<String> list = stack.ToList<String>();
            
                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] == "/")
                    {
                        list[i] = (Convert.ToDouble(list[i + 1]) / Convert.ToDouble(list[i - 1])).ToString();
                        list.RemoveAt(i + 1);
                        list.RemoveAt(i - 1);
                        i -= 2;
                    }
                }

                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] == "*")
                    {
                        list[i] = (Convert.ToDouble(list[i + 1]) * Convert.ToDouble(list[i - 1])).ToString();
                        list.RemoveAt(i + 1);
                        list.RemoveAt(i - 1);
                        i -= 2;
                    }
                }
                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] == "+")
                    {
                        list[i] = (Convert.ToDouble(list[i + 1]) + Convert.ToDouble(list[i - 1])).ToString();
                        list.RemoveAt(i + 1);
                        list.RemoveAt(i - 1);
                        i -= 2;
                    }
                }
                for (int i = list.Count - 2; i >= 0; i--)
                {
                    if (list[i] == "-")
                    {
                        list[i] = (Convert.ToDouble(list[i + 1]) - Convert.ToDouble(list[i - 1])).ToString();
                        list.RemoveAt(i + 1);
                        list.RemoveAt(i - 1);
                        i -= 2;
                    }
                }
                stack.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    stack.Push(list[i]);
                }

                result = Convert.ToDouble(stack.Pop());
            
                
        }
            internal void OutputDisplay(double result)
            {
                Console.WriteLine($"Calculation result: {result}");
                Console.ReadKey();
            }
        
    }
}