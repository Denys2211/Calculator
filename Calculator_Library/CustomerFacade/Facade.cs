using System.Collections.Generic;
using SQLite;
using System;
using Calculator.CustomerFacade.Audit;
using Calculator.CustomerFacade.CustomerInterpreter;
using Calculator.CustomerFacade.CoreModels;
using Calculator.CustomerFacade.CustomerLogger;

namespace Calculator.CustomerFacade
{
    public class CalcFacade
    {
        public delegate void Handler(string message);
        public event Handler Notify;
        private IAudit Audit { get; set; }
        private ICustomerParser Calculator { get; set; }
        private IContext Context { get; set; }
        private SQLiteConnection Connection { get; set; }
        private Item Data { get; set; }
        private IDataRepository SqlExpress { get; set; }
        private FileLogger Log { get; set; }
        internal CalcFacade(Item data, IDataRepository sqlExpress, IAudit audit, ICustomerParser exp_evaluate, IContext context, SQLiteConnection connection, FileLogger log)
        {
            Log = log;
            Connection = connection;
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
            SqlExpress = sqlExpress;
        }
        public double Start(string input)
        {
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade),"///////Start of calculation///////");

            Audit.CheckAvailability(input);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Check availability");

            Audit.СheckNumericCharacter(input, Data.Symbol);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Сheck numeric character");

            Audit.CheckQuantity(input);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Check quantity");
            
            Audit.CorrectInput(input);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Check correct input");

            Context.СreateList(Audit.CountBracket);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Сreate list");

            Calculator.CreateExpression(input);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Create expression");

            Calculator.FilterNumbers();
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Filter numbers");

            Calculator.CalculateExpression();
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Calculate expression");

            double result = Calculator.Result;
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Read result");


            SqlExpress.AddInDataBase("History", Connection, result, input);
            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Add in data base result");


            Logger.LogMessage(Severity.Warning, nameof(CalcFacade), "Finish!!!");

            return result;

        }

        public IEnumerable<History> Calculation_history() => SqlExpress.ReadDataBase(Connection);

        public void Clean_history()
        {

            SqlExpress.DeleteDataTable("History", Connection);

            Notify?.Invoke($"--------Done!-------- ");

        }

        public string ReadLogger() => Log.ReaderFile();

        public void Clean_Log()
        {

            Log.CleanLog();

        }

    }
}

