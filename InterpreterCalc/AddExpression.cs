using Calculator;

namespace InterpreterCalc
{
    // нетерминальное выражение для сложения
    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret(IContext context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }
}
