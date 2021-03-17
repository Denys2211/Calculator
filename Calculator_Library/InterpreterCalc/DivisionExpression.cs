using Calculator;
using System;
using Exception;

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

            if (LeftExpression != null && RightExpression != null)
            {
                if (RightExpression.Interpret(context) == 0)

                    throw new DivideByZeroException();

                return LeftExpression.Interpret(context) / RightExpression.Interpret(context);
            }

            else
                
                throw new CalcExceptions("Incorrect input! Division failed.");
        }
    }
}
