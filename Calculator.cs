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
        internal void Evaluate(string input, out int result)
        {
            List<String> list = context.FormationExpression(input);
            IExpression[] Number = new IExpression[list.Count];
            IExpression expression;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] != "+" &&
                    list[i] != "-" &&
                    list[i] != "*" &&
                    list[i] != "/")
                {
                    input = Convert.ToString(i);
                    context.SetVariable(input, int.Parse(list[i]));
                    Number[i] = new NumberExpression(input);
                }
            }
            result = 0;
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "*")
                {
                    expression = new MultiplicationExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveVariables(Convert.ToString(i - 1));
                    context.SetVariable(Convert.ToString(i - 1), result);
                    i -= 1;
                }
                if (list[i] == "/")
                {
                    expression = new DivisionExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveVariables(Convert.ToString(i - 1));
                    context.SetVariable(Convert.ToString(i - 1), result);
                    i -= 1;
                }

            }
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == "-")
                {
                    expression = new SubtractExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveVariables(Convert.ToString(i - 1));
                    context.SetVariable(Convert.ToString(i - 1), result);
                    i -= 1;
                }
                if (list[i] == "+")
                {
                    expression = new AddExpression(Number[i + 1], Number[i - 1]);
                    result = expression.Interpret(context);
                    context.RemoveVariables(Convert.ToString(i - 1));
                    context.SetVariable(Convert.ToString(i - 1), result);
                    i -= 1;
                }

            }
        }
        internal void OutputDisplay(double result)
        {
            Console.WriteLine($"Calculation result: {result}");
            Console.ReadKey();
        }
    }
}