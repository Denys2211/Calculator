using Calculator;
using Exception;

namespace InterpreterCalc
{
    class SubtractExpression : IExpression
    {
        private IExpression LeftExpression { get; set; }
        private IExpression RightExpression { get; set; }

        public SubtractExpression(IExpression left, IExpression right)
        {
            LeftExpression = left;
            RightExpression = right;
        }

        public double Interpret(IContext context)
        {
            if (LeftExpression != null && RightExpression != null)
                return LeftExpression.Interpret(context) - RightExpression.Interpret(context);
            else
            {
                throw new CalcExceptions("Incorrect input! Subtract failed.");
            }
        }
    }
}
