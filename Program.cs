using AppData;
using Audit;
using InterpreterCalc;
using Microsoft.Data.Sqlite;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqliteConnection("Data Source=usersdata.db");
            IData data = new DataConsole(connection);
            IContext context = new Context();
            ICalculator exp_evaluate = new Calc_ExpParentheses(context);
            IAudit audit = new Audit_Input();
            var ide = new CalcFacade(data, audit, exp_evaluate, context);
            User user = new User(ide);
            user.Operation();
        }
    }
}
