using Calculator;
using System;
namespace InterpreterCalc
{
    class DivisionExpression : IExpression
    {
        private IExpression LeftExpression { get; set; }
        private IExpression RightExpression { get; set; }

        public DivisionExpression(IExpression left, IExpression right)
        {
            LeftExpression = left;
            RightExpression = right;
        }

        public double Interpret(IContext context)
        {
            if (RightExpression.Interpret(context) == 0)
                throw new Exception("Division by 0!!! ");
            return LeftExpression.Interpret(context) / RightExpression.Interpret(context);
        }
    }
}
