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
            try
            {
                return LeftExpression.Interpret(context) / RightExpression.Interpret(context);

            }
            catch(DivideByZeroException ex) 
            {
                Console.WriteLine($"Error!{ex.Message}");
                return double.NaN;
            }
        }
    }
}
