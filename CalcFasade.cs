
namespace Calculator
{
    class CalcFacade
    {
        public IAudit Audit { get; set; }
        public ICalculator Calculator { get; set; }
        public IContext Context { get; set; }
        public IData Data { get; set; }
        internal CalcFacade(IData data, IAudit audit, ICalculator exp_evaluate, IContext context)
        {
            Audit = audit;
            Calculator = exp_evaluate;
            Context = context;
            Data = data;
        }
        internal void Start()
        {
            for (; ; )
            {
                    string input = Data.DataEntry(out string[] symbol);
                    if (Audit.СheckNumericCharacter(input, symbol) == default)
                        continue;
                    if (Audit.CheckQuantity(input) == default)
                        continue;
                    if (Audit.CorrectInput(input) == default)
                        continue;
                    if (Audit.CheckAvailability(input) == default)
                        continue;
                try
                {
                    Data.OutputDisplay(Calculator.EvaluateExp(input));
                    Context.ClearList();
                }
                catch
                {
                    System.Console.WriteLine("--------An unforeseen mistake!--------");
                }
                break;
            }
            
        }
        internal void Calculation_history()
        {
            Data.ReaderDataBase();
        }
        internal void Toclean_history()
        {
            Data.DeleteDataBase();
        }
    }
}

