using System.Threading;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Logger;
using System;


namespace Calculator
{
    public class CalcFacade
    {
        public delegate void Handler(string message);
        public event Handler Notify;
        private IAudit Audit { get; set; }
        private ICalculator Calculator { get; set; }
        private IContext Context { get; set; }
        private SqliteConnection Connection { get; set; }
        private IData Data { get; set; }
        private ISqlExpression SqlExpress { get; set; }
        private ILogger Log { get; set; }
        internal CalcFacade(IData data, ISqlExpression sqlExpress, IAudit audit, ICalculator exp_evaluate, IContext context, SqliteConnection connection, ILogger log)
        {
            this.Log = log;
            this.Connection = connection;
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
            SqlExpress = sqlExpress;
        }
        public double Start(string input)
        {
            Log.WritteFile($"[{DateTime.Now}]\t///////Start of calculation///////");

            Data.DataEntry(out string[] symbol);
            Log.WritteFile($"[{DateTime.Now}]\tRead data");

            Audit.СheckNumericCharacter(input, symbol);
            Log.WritteFile($"[{DateTime.Now}]\tСheck numeric character");

            Audit.CheckQuantity(input);
            Log.WritteFile($"[{DateTime.Now}]\tCheck quantity");

            Audit.CorrectInput(input);
            Log.WritteFile($"[{DateTime.Now}]\tCheck correct input");

            Audit.CheckAvailability(input);
            Log.WritteFile($"[{DateTime.Now}]\tCheck availability");

            Context.СreateList(Audit.CountBracket);
            Log.WritteFile($"[{DateTime.Now}]\tСreate list");

            Calculator.CreateExpression(input);
            Log.WritteFile($"[{DateTime.Now}]\tCreate expression");

            Calculator.FilterNumbers();
            Log.WritteFile($"[{DateTime.Now}]\tFilter numbers");

            Calculator.CalculateExpression();
            Log.WritteFile($"[{DateTime.Now}]\tCalculate expression");

            double result = Calculator.Result;
            Log.WritteFile($"[{DateTime.Now}]\tRead result");

            SqlExpress.AddInDataBase("History", Connection, input, result.ToString());
            Log.WritteFile($"[{DateTime.Now}]\tAdd in data base result");

            Notify?.Invoke($"Сalculation successful. There will be an operation on the {Audit.CountNumbers} numbers. ");
            Log.WritteFile($"[{DateTime.Now}]\tFinish!!!");

            return result;

        }

        public List<List<object>> Calculation_history() => SqlExpress.ReadDataBase("History", Connection);

        public void Clean_history()
        {

            SqlExpress.DeleteDataTable("History", Connection);

            Notify?.Invoke($"--------Done!-------- ");

        }

        public string ReadLogger() => Log.ReaderFile();

    }
}

