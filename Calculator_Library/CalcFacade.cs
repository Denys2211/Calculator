using System.Collections.Generic;
using Collections;

namespace Calculator
{
    public class CalcFacade
    {
        public delegate void Handler(string message);
        public event Handler Notify;
        private IAudit Audit { get; set; }
        private ICalculator Calculator { get; set; }
        private IContext Context { get; set; }
        private IData Data { get; set; }
        private ISqlExpression Command { get; set; }
        internal CalcFacade(IData data, ISqlExpression command,  IAudit audit, ICalculator exp_evaluate, IContext context)
        {
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
            Command = command;
        }
        public double Start(string input)
        {
            Data.DataEntry(out string[] symbol);

            Audit.СheckNumericCharacter(input, symbol);

            Audit.CheckQuantity(input);

            Audit.CorrectInput(input);

            Audit.CheckAvailability(input);

            Context.СreateList(Audit.CountBracket);

            Calculator.CreateExpression(input);

            Calculator.FilterNumbers();

            Calculator.CalculateExpression();

            double result = Calculator.Result;

            Command.AddInDataBase(result, input);

            Notify?.Invoke($"Сalculation successful. There will be an operation on the {Audit.CountNumbers} numbers. ");

            return result;

        }

        public List<object[]> Calculation_history() => Command.ReadDataBase();
 
        public void Clean_history()
        {
            
            Command.DeleteDataTable();
            Notify?.Invoke($"--------Done!-------- ");

        }
        public MyCollection<string> List()
        {

           return  Context[0];

        }
    }
}

