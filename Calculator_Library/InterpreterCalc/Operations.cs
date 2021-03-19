using Calculator;
using Exceptions;

namespace InterpreterCalc
{
    class Operations : IExpression
    {
        private IExpression LeftExpression { get; set; }
        private IExpression RightExpression { get; set; }
        public Operation Actions{get;set;}

        public Operations(IExpression left, IExpression right, Operation act)
        {
            LeftExpression = left;
            RightExpression = right;
            Actions = act;
        }

        public double Interpret(IContext context)
        {
            if(LeftExpression != null && RightExpression != null)
                return Actions(LeftExpression, RightExpression);
            else 
            { 
                throw new CalcExceptions("Multiplication failed!");
            }
        }
    }
}
