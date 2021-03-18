using System.Collections.Generic;

namespace Calculator
{
    public class CalcFacade
    {
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

            double result = Calculator.EvaluateExp(input);

            Context.ClearList();

            Command.AddInDB(result, input);

            return result;

        }
        public List<object[]> Calculation_history()
        {

            return Command.ReaderDataBase();

        }
        public void Toclean_history()
        {

            Command.DeleteDataBase();
            
        }
    }
}

