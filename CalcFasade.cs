using Exception;
namespace Calculator
{
    class CalcFacade
    {
        public IAudit Audit { get; set; }
        public ICalculator Calculator { get; set; }
        public IContext Context { get; set; }
        public IData Data { get; set; }
        public SqlExpression Command { get; set; }
        internal CalcFacade(IData data, SqlExpression command,  IAudit audit, ICalculator exp_evaluate, IContext context)
        {
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
            Command = command;
        }
        internal void Start()
        {
            string input = Data.DataEntry(out string[] symbol);
          
            Audit.СheckNumericCharacter(input, symbol);

            Audit.CheckQuantity(input);

            Audit.CorrectInput(input);

            Audit.CheckAvailability(input);

            double result = Calculator.EvaluateExp(input);

            Data.OutputDisplay(result);

            Context.ClearList();

            Command.AddInDB(result, input);

        }
        internal void Calculation_history()
        {

            Command.ReaderDataBase();

        }
        internal void Toclean_history()
        {

            Command.DeleteDataBase();
            
        }
    }
}

