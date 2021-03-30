using System;
using System.Collections.Generic;
using Calculator;

namespace InterpreterCalc
{

    delegate double Operation(IExpression left, IExpression right);

    public class Calculations : ICalculator
    {
        private Operation Variabl { get; set; }
        private Operation Add { get; set; }
        private Operation Subtract { get; set; }
        private Operation Division { get; set; }
        private Operation Multiplication { get; set; }
        private IExpression[] Number { get; set; }
        public double Result { get; private set; }
        private IContext Context { get; set; }
        public int IndexStack { get; private set; }
        internal Calculations(IContext context)
        {
            IndexStack = 0;
            Context = context;
            Add = (left, right) => left.Interpret(Context) + right.Interpret(Context);
            Subtract = (left, right) => left.Interpret(Context) - right.Interpret(Context);
            Division = (left, right) => left.Interpret(Context) / right.Interpret(Context);
            Multiplication = (left, right) => left.Interpret(Context) * right.Interpret(Context);
        }
        public void CreateExpression(string input)
        {

            string value = "";
            for (int i = 0; i < input.Length; i++)
            {
                string symbol = input.Substring(i, 1);

                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    Context[IndexStack].Push(value);

                    value = "";
                }
                if (symbol.Equals("("))
                {
                    IndexStack++;

                    i = CalculationInBracket(i, symbol, input);
                }

                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))

                    Context[IndexStack].Push(symbol);

                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;

                    if (i == (input.Length - 1))
                        Context[IndexStack].Push(value);

                }
            }
        }

        public void CalculationExp()
        {
            for (int i = Context.List.Count - 1; i >= 0; i--)
            {
                if (Context.List[i] == "/")
                {
                    Variabl = Division;
                    CreateOperations(i);
                    i -= 1;
                }
                if (Context.List[i] == "*")
                {
                    Variabl = Multiplication;
                    CreateOperations(i);
                    i -= 1;
                }
            }
            for (int i = Context.List.Count - 1; i >= 0; i--)
            {
                if (Context.List[i] == "+")
                {
                    Variabl = Add;
                    CreateOperations(i);
                    i -= 1;
                }
                if (Context.List[i] == "-")
                {
                    Variabl = Subtract;
                    CreateOperations(i);
                    i -= 1;
                }
            }
        }

        public void NumberFiltering(List<String> list)
        {
            Number = new IExpression[list.Count];

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] != "+" &&
                    list[i] != "-" &&
                    list[i] != "*" &&
                    list[i] != "/")

                    Number[i] = new NumberExpression(i);

            }
        }
        public void CreateOperations(int index)
        {
            
            Operations expression = new Operations(Number[index + 1], Number[index - 1], Variabl);

            Result = expression.OperationsWithExpression();

            Context.RemoveList(index - 1);

            Context.RemoveList(index);

            Context.SetList(index - 1, Result);

        }

        public int CalculationInBracket(int i, string symbol, string input)
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
            CreateExpression(innerExp);

            Context.СreatureList(IndexStack);

            NumberFiltering(Context.List);

            CalculationExp();

            Context[IndexStack - 1].Push(Result.ToString());

            IndexStack--;

            return i;

        }
    }
}