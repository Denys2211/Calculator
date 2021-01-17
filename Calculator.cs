using System;
using System.Data;
using System.Collections.Generic;

namespace ConsoleApp2
{

     class Calculator
    {

        internal void DataEntry(out string input, out string[] symbol)
        {
            symbol = new [] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            input = Console.ReadLine();
        }
        internal void Evaluate(string input, out double result)
        {

            Stack<string> stack = new Stack<string>();

            string value = "";
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input.Substring(i, 1); 
                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }

                if (symbol.Equals("("))
                {

                    string innerExp = "";
                    i++; //отримати наступний символ
                    int bracketCount = 0;
                    for (; i < input.Length; i++)
                    {
                        symbol = input.Substring(i, 1);

                        if (symbol.Equals("("))
                            bracketCount++;

                        if (symbol.Equals(")"))
                            if (bracketCount == 0)
                                break;
                            else
                                bracketCount--;
                        innerExp += symbol;
                    }

                    Evaluate(innerExp, out result);//обчислення виразу в дужках
                    stack.Push(result.ToString());
                }
                else if (symbol.Equals("+")) stack.Push(symbol);
                else if (symbol.Equals("-")) stack.Push(symbol);
                else if (symbol.Equals("*")) stack.Push(symbol);
                else if (symbol.Equals("/")) stack.Push(symbol);
               
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (i == (input.Length - 1))
                        stack.Push(value);
                }
            }
            result = 0;
            while (stack.Count >= 3)
            {

                double right = Convert.ToDouble(stack.Pop());
                string op = stack.Pop();
                double left = Convert.ToDouble(stack.Pop());

                if (op == "+") result = left + right;
                else if (op == "-") result = left - right;
                else if (op == "*") result = left * right;
                else if (op == "/") result = left / right;

                stack.Push(result.ToString());
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