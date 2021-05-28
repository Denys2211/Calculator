using SQLite;
using System;
using System.IO;
using Calculator.CustomerFacade.CustomerLogger;
using Calculator.CustomerFacade;
using Calculator.CustomerFacade.CoreModels;
using Calculator.CustomerFacade.CustomerInterpreter;
using Calculator.CustomerFacade.Audit;

namespace Calculator
{
    public class AppCalculator
    {
        public CalcFacade IDE { get; set; }
        public AppCalculator()
        {
            FileLogger log = new FileLogger(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var connection = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "usersdata.db"));
            IDataRepository sqlExpress = new HistoryRepository();
            Item data = new Item();
            IContext context = new Context();
            IAudit audit = new Audit_Input();
            ICustomerParser exp_evaluate = new CustomerParser(context);
            var ide = new CalcFacade(data, sqlExpress, audit, exp_evaluate, context, connection, log);
            IDE = ide;
        }
    }
}
