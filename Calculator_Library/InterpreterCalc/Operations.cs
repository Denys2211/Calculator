using Calculator;
using Exceptions;

namespace InterpreterCalc
{
    class Operations 
    {
        public readonly string OPERATION = "Mathematical operation failed! ";

        private IExpression LeftExpression { get; set; }

        private IExpression RightExpression { get; set; }

        public Operation MathOperation { get; set; }

        public Operations(IExpression left, IExpression right, Operation mathOp)
        {
            LeftExpression = left;
            RightExpression = right;
            MathOperation = mathOp;
        }

        public double OperationsWithExpression()
        {
            try
            {
                if (LeftExpression != null && RightExpression != null)

                    return MathOperation(LeftExpression, RightExpression);
                else
                    throw new CalcExceptions(OPERATION +"There are no numbers.");
            }
             catch
            {
                 throw new CalcExceptions(OPERATION);
            }
        }
    }
}
