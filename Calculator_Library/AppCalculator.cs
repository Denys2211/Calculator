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
            ISqlExpression sqlExpress = new SqLiteExpressions();
            IData data = new DataConsole();
            IContext context = new Context();
            IAudit audit = new Audit_Input();
            ICalculator exp_evaluate = new Calculations(context);
            var ide = new CalcFacade(data, sqlExpress, audit, exp_evaluate, context, connection);
            IDE = ide;
        }
    }
}
