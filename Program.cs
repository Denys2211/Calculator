
namespace ConsoleApp
{
    class Program
    {
          static void Main()
         {
            IData data = new DataConsole();
            IContext context = new Context();
            ICalculator calculator = new Calc_ExpParentheses(context);
            IAudit audit = new Audit_Input();
            CalcFacade ide = new CalcFacade(data, audit, calculator, context);
            User uss = new User();
            uss.Star(ide);
         }
    }
}

