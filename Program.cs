using AppData;
using Audit;
using InterpreterCalc;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IData data = new DataConsole();
            IContext context = new Context();
            ICalculator exp_evaluate = new Calc_ExpParentheses(context);
            IAudit audit = new Audit_Input();
            CalcFacade ide = new CalcFacade(data, audit, exp_evaluate, context);
            ide.Start();
        }
    }
}
