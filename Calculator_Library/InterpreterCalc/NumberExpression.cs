using Calculator;

namespace InterpreterCalc
{
    class NumberExpression : IExpression
    {
        int index;
        public NumberExpression(int variableName)
        {
            index = variableName;
        }
        public double Interpret(IContext context) => context.GetList(index);
    }
}
