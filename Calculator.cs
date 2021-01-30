using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{

    class Calculator
    {
        Context context;
        internal Calculator(Context context)
        {
            this.context = context;
        }

        internal void DataEntry(out string input, out string[] symbol)
        {
            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            input = Console.ReadLine();
        }
        internal void Evaluate(string input, out double result)
        {
            Stack<string> stack = new Stack<string>();
            string value = "";
            string innerExp = "";
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
                    stack.Push(Convert.ToString(result));
                }

                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))

                    stack.Push(symbol);

                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (i == (input.Length - 1))
                        stack.Push(value);

                }
            }
            context.СreatureList(stack, out List <String> list);
            IExpression[] Number = new IExpression[list.Count];
            IExpression expression;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] != "+" &&
                    list[i] != "-" &&
                    list[i] != "*" &&
                    list[i] != "/")
                
                    Number[i] = new NumberExpression(i);
                
            }
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "*")
                {
                    expression = new MultiplicationExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveList(i - 1);
                    context.RemoveList(i);
                    context.SetList(i-1, result);
                    i -= 1;
                }
                if (list[i] == "/")
                {
                    expression = new DivisionExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveList(i - 1);
                    context.RemoveList(i);
                    context.SetList(i - 1, result);
                    i -= 1;
                }

            }
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "-")
                {
                    expression = new SubtractExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveList(i - 1);
                    context.RemoveList(i);
                    context.SetList(i - 1, result);
                    i -= 1;
                }
                if (list[i] == "+")
                {
                    expression = new AddExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveList(i - 1);
                    context.RemoveList(i);
                    context.SetList(i - 1, result);
                    i -= 1;
                }

            }
            result = double.Parse(list[0]);
        }
        internal void OutputDisplay(double result)
        {
            Console.WriteLine($"Calculation result: {result}");
            Console.ReadKey();
        }
    }
}