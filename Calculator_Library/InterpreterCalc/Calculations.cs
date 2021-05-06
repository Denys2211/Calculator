using System;
using System.Globalization;
using Collections;
using Calculator;

namespace InterpreterCalc
{
    internal delegate NumberExpression Operation(NumberExpression left, NumberExpression right);

    public class Calculations : ICalculator
    {
        private Operation Variable { get; set; }
        private readonly Operation[] MathOp;
        private NumberExpression[] Number { get; set; }
        public double Result { get; private set; }
        private IContext Context { get; set; }
        public int IndexList { get; private set; }
        internal Calculations(IContext context)
        {
            Context = context;
            MathOp = CreateMasMathOperation();
        }

        private  Operation[] CreateMasMathOperation()
        {
            return new Operation[]
                        {
                (left, right) => left + right,
                (left, right) => left - right,
                (left, right) => left / right,
                (left, right) => left * right
                        };
        }

        public void CreateExpression(string input)
        {

            var value = "";
            for (var i = 0; i < input.Length; i++)
            {
                var symbol = input.Substring(i, 1);

                var chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != ',' && value != "")
                {
                    Context[IndexList].Add(value);

                    value = "";
                }
                if (symbol.Equals("("))
                {
                    IndexList++;

                    i = CalculationInBracket(i, input);
                }

                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))

                    Context[IndexList].Add(symbol);

                else if (char.IsDigit(chr) || chr == ',')
                {
                    if (symbol == ",")
                        symbol = ".";
                    value += symbol;

                    if (i == (input.Length - 1))
                        Context[IndexList].Add(value);

                }
            }
        }

        public void CalculateExpression()
        {
            for (int i = 1; i < Context[IndexList].Count; ++i)
            {
                if (Context[IndexList][i] == "/")
                {
                    Variable = MathOp[2];
                    CreateOperations(i);
                    i -= 1;
                }
                if (Context[IndexList][i] == "*")
                {
                    Variable = MathOp[3];
                    CreateOperations(i);
                    i -= 1;
                }
            }
            for (int i = 1; i < Context[IndexList].Count; ++i)
            {
                if (Context[IndexList][i] == "+")
                {
                    Variable = MathOp[0];
                    CreateOperations(i);
                    i -= 1;
                }
                if (Context[IndexList][i] == "-")
                {
                    Variable = MathOp[1];
                    CreateOperations(i);
                    i -= 1;
                }
            }
        }

        public void FilterNumbers()
        {
            Number = new NumberExpression[Context[IndexList].Count];

            for (int i = Context[IndexList].Count - 1; i >= 0; i--)
                if (Context[IndexList][i] != "+" &&
                    Context[IndexList][i] != "-" &&
                    Context[IndexList][i] != "*" &&
                    Context[IndexList][i] != "/")
                {
                    Number[i] = i;
                    Number[i].IndexList = IndexList;
                    Number[i].Context = Context;
                }
        }
        private void CreateOperations(int index)
        {
            
            var expression = new Operations(Number[index - 1], Number[index + 1], Variable);

            Result = expression.Interpret();

            Context.RemoveList(index - 1, IndexList);

            Context.RemoveList(index - 1, IndexList);

            Context[IndexList][index - 1] = Result.ToString();

        }

        private int CalculationInBracket(int i, string input)
        {
            string innerExp = "";
            i++;
            int bracketCount = 0;

            for (; i < input.Length; i++)
            {
               string symbol = input.Substring(i, 1);

                if (symbol.Equals("(")) bracketCount++;

                if (symbol.Equals(")"))
                {
                    if (bracketCount == 0) break;
                    bracketCount--;
                }
                innerExp += symbol;
            }
            CreateExpression(innerExp);

            FilterNumbers();

            CalculateExpression();

            IndexList--;

            Context[IndexList].Add(Result.ToString());

            return i;

        }
    }
}