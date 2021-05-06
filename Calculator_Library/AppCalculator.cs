using AppData;
using Audit;
using InterpreterCalc;
using SQLite;
using Logger;
using System;
using System.IO;

namespace Calculator
{
    public class AppCalculator
    {
        public CalcFacade IDE { get; set; }
        public AppCalculator()
        {
            ILogger log = new CalcLogger();
            var connection = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "usersdata.db"));
            IDataRepository sqlExpress = new HistoryRepository();
            IData data = new DataConsole();
            IContext context = new Context();
            IAudit audit = new Audit_Input();
            ICalculator exp_evaluate = new Calculations(context);
            var ide = new CalcFacade(data, sqlExpress, audit, exp_evaluate, context, connection, log);
            IDE = ide;
        }
    }
}
