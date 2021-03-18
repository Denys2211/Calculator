using Calculator;
using Exceptions;

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
                throw new CalcExceptions("Incorrect input! Addition failed.");
            }
        }
    }
}
