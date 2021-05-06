using Calculator;
using Exceptions;
using System;

namespace InterpreterCalc
{
    class Operations : IExpression
    {
        public readonly string OPERATION = "Mathematical operation failed! ";

        private NumberExpression LeftExpression { get; set; }

        private NumberExpression RightExpression { get; set; }

        public Operation MathOperation { get; set; }

        public Operations(NumberExpression left, NumberExpression right, Operation mathOp)
        {
            LeftExpression = left;
            RightExpression = right;
            MathOperation = mathOp;
        }

        public double Interpret()
        {
            try
            {
                return (double)MathOperation(LeftExpression, RightExpression);
            }
            catch (CalcExceptions ex)
            {
                throw new CalcExceptions(ex.Message);
            }
            catch
            {
                throw new CalcExceptions(OPERATION);
            }
        }
    }
}
