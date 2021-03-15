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
            SqlExpression command = new SqLiteExpressions(connection);
            IData data = new DataConsole();
            IContext context = new Context();
            ICalculator exp_evaluate = new Calc_ExpParentheses(context);
            IAudit audit = new Audit_Input();
            var ide = new CalcFacade(data, command, audit, exp_evaluate, context);
            User user = new User(ide);
            user.Operation();
        }
    }
}
