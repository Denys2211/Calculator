using AppData;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

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
        internal CalcFacade(IData data, ISqlExpression sqlExpress, IAudit audit, ICalculator exp_evaluate, IContext context, SqliteConnection connection)
        {
            this.Connection = connection;
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
            SqlExpress = sqlExpress;
        }
        public double Start(string input)
        {
            SqlExpress.AddInDataBase("Log", Connection,"///////Start of calculation///////");

            Data.DataEntry(out string[] symbol);

            SqlExpress.AddInDataBase("Log", Connection, "Read data");

            Audit.СheckNumericCharacter(input, symbol);

            SqlExpress.AddInDataBase("Log", Connection, "Сheck numeric character");

            Audit.CheckQuantity(input);

            SqlExpress.AddInDataBase("Log", Connection, "Check quantity");

            Audit.CorrectInput(input);

            SqlExpress.AddInDataBase("Log", Connection, "Check correct input");

            Audit.CheckAvailability(input);

            SqlExpress.AddInDataBase("Log", Connection, "Check availability");

            Context.СreateList(Audit.CountBracket);

            SqlExpress.AddInDataBase("Log", Connection, "Сreate list");

            Calculator.CreateExpression(input);

            SqlExpress.AddInDataBase("Log", Connection, "Create expression");

            Calculator.FilterNumbers();

            SqlExpress.AddInDataBase("Log", Connection, "Filter numbers");

            Calculator.CalculateExpression();

            SqlExpress.AddInDataBase("Log", Connection, "Calculate expression");

            double result = Calculator.Result;

            SqlExpress.AddInDataBase("Log", Connection, "Read result");

            SqlExpress.AddInDataBase("History", Connection, input, result.ToString());

            SqlExpress.AddInDataBase("Log", Connection, "Add in data base result");

            Notify?.Invoke($"Сalculation successful. There will be an operation on the {Audit.CountNumbers} numbers. ");

            SqlExpress.AddInDataBase("Log", Connection, "Finish!!!");

            return result;

        }

        public List<List<object>> Calculation_history() => SqlExpress.ReadDataBase("History", Connection);

        public void Clean_history()
        {

            SqlExpress.DeleteDataTable("History", Connection);

            Notify?.Invoke($"--------Done!-------- ");

        }

        public List<List<object>> ReadLogger() => SqlExpress.ReadDataBase("Log", Connection);

    }
}

