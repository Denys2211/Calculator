using Calculator;
namespace InterpreterCalc
{
    class MultiplicationExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public MultiplicationExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret(IContext context)
        {
            return leftExpression.Interpret(context) * rightExpression.Interpret(context);
        }
    }
}
