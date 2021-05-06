using System.Threading;
using System.Collections.Generic;
using SQLite;
using Logger;
using System;
using System.Diagnostics;


namespace Calculator
{
    public class CalcFacade
    {
        public delegate void Handler(string message);
        public event Handler Notify;
        private IAudit Audit { get; set; }
        private ICalculator Calculator { get; set; }
        private IContext Context { get; set; }
        private SQLiteConnection Connection { get; set; }
        private IData Data { get; set; }
        private IDataRepository SqlExpress { get; set; }
        private ILogger Log { get; set; }
        internal CalcFacade(IData data, IDataRepository sqlExpress, IAudit audit, ICalculator exp_evaluate, IContext context, SQLiteConnection connection, ILogger log)
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
            WriteLog("///////Start of calculation///////");

            Data.DataEntry(out string[] symbol);
            WriteLog("Read data");

            Audit.CheckAvailability(input);
            WriteLog("Check availability");

            Audit.CheckQuantity(input);
            WriteLog("Check quantity");

            Audit.СheckNumericCharacter(input, symbol);
            WriteLog("Сheck numeric character");

            Audit.CorrectInput(input);
            WriteLog("Check correct input");

            Context.СreateList(Audit.CountBracket);
            WriteLog("Сreate list");

            Calculator.CreateExpression(input);
            WriteLog("Create expression");

            Calculator.FilterNumbers();
            WriteLog("Filter numbers");

            Calculator.CalculateExpression();
            WriteLog("Calculate expression");

            double result = Calculator.Result;
            WriteLog("Read result");

            SqlExpress.AddInDataBase("History", Connection, result, input);
            WriteLog("Add in data base result");

            Notify?.Invoke($"Сalculation successful. There will be an operation on the {Audit.CountNumbers} numbers. ");
            WriteLog("Finish!!!");

            return result;

        }

        public IEnumerable<AppData.History> Calculation_history() => SqlExpress.ReadDataBase("History", Connection);

        public void Clean_history()
        {

            SqlExpress.DeleteDataTable("History", Connection);

            Notify?.Invoke($"--------Done!-------- ");

        }

        public string ReadLogger() => Log.ReaderFile();

        private void WriteLog(string text)
        {

            Log.WriteFile($"[{DateTime.Now}]\t{text}");

        }

    }
}

