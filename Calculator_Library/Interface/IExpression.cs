
namespace Calculator
{
    interface IExpression
    {
        double Interpret(IContext context);
    }
}
