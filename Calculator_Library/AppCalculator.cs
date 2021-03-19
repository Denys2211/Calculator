using AppData;
using Audit;
using InterpreterCalc;
using Microsoft.Data.Sqlite;

namespace Calculator
{
    public class AppCalculator
    {
        public CalcFacade IDE { get; set; }
        public AppCalculator()
        {
            var connection = new SqliteConnection("Data Source=usersdata.db");
            ISqlExpression command = new SqLiteExpressions(connection);
            IData data = new DataConsole();
            IContext context = new Context();
            ICalculator exp_evaluate = new Calculations(context);
            IAudit audit = new Audit_Input();
            var ide = new CalcFacade(data, command, audit, exp_evaluate, context);
            IDE = ide;
        }
    }
}
