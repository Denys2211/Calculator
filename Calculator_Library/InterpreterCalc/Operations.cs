using Calculator;
using Exceptions;

namespace InterpreterCalc
{
    class Operations 
    {
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
            if(LeftExpression != null && RightExpression != null)
                return MathOperation(LeftExpression, RightExpression);
            else 
            { 
                throw new CalcExceptions("Operations failed!");
            }
        }
    }
}
