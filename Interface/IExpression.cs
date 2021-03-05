
namespace Calculator
{
    // интерфейс интерпретатора
    interface IExpression
    {
        double Interpret(IContext context);
    }
}
