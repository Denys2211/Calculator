
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
                try 
                {
                    if (Audit.СheckNumericCharacter(input, symbol) == default)
                        continue;
                    if (Audit.CheckQuantity(input) == default)
                        continue;
                    if (Audit.CorrectInput(input) == default)
                        continue;
                    if (Audit.CheckAvailability(input) == default)
                        continue;

                }
                catch
                {
                    System.Console.WriteLine("Input validation error!");
                    break;
                }
                try
                {
                    Data.OutputDisplay(Calculator.EvaluateExp(input));
                    Context.ClearList();
                }
                catch
                {
                    System.Console.WriteLine("--------Unforeseen calculation error!--------");
                }
                break;
            }
            
        }
        internal void Calculation_history()
        {
            try
            {
                Data.ReaderDataBase();
            }
            catch
            {
                System.Console.WriteLine("Database read error");
            }
        }
        internal void Toclean_history()
        {
            try
            {
                Data.DeleteDataBase();
            }
            catch
            {
                System.Console.WriteLine("Database clean error");
            }
        }
    }
}

