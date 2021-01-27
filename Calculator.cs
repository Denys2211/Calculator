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
        internal void Evaluate(int indexStack, string input, out int result)
        {
            context.FormationExpression(indexStack, input, out bool temples, out string innerExp, out int bracketCount);
            if (temples)
            {
                indexStack = bracketCount;
                Evaluate(indexStack, innerExp, out result);
                context.SetStack(indexStack-1, result);
                indexStack--;
            }
            context.СreatureList(indexStack, out List <String> list);
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
            result = int.Parse(list[0]);
        }
        internal void OutputDisplay(int result)
        {
            Console.WriteLine($"Calculation result: {result}");
            Console.ReadKey();
        }
    }
}