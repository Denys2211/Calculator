
namespace ConsoleApp
{
    class CalcFacade
    {
        public IAudit Audit{ get; set; }
        public ICalculator Calculator { get; set; }
        public IContext Context { get; set;}
        public IData Data { get; set; }
        internal CalcFacade(IData data, IAudit audit,ICalculator calculator, IContext context)
        {
            Audit = audit;
            Calculator = calculator;
            Context = context;
            Data = data;
        }
        internal void Start()
        {
            for(; ; )
            {
                Data.DataEntry(out string input, out string[] symbol);
                if (Audit.CheckAvailability(input) == default)
                    continue;
                if (Audit.CheckQuantity(input, symbol) == default)
                    continue;
                if (Audit.СheckNumericCharacter(input, symbol) == default)
                    continue;
                Data.OutputDisplay(Calculator.Evaluate(input));
                Context.ClearList();
            }
        }
    }
}

