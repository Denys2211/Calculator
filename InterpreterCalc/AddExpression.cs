using Calculator;

namespace InterpreterCalc
{
    class AddExpression : IExpression
    {
        private IExpression LeftExpression { get; set; }
        private IExpression RightExpression { get; set; }

        public AddExpression(IExpression left, IExpression right)
        {
            LeftExpression = left;
            RightExpression = right;
        }

        public double Interpret(IContext context)
        {
            if (LeftExpression != null && RightExpression != null)
                return LeftExpression.Interpret(context) + RightExpression.Interpret(context);
            else
            {
                System.Console.WriteLine("Incorrect input! Addition failed.");
                return double.NaN;
            }
        }
    }
}
