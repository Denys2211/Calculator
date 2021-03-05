
namespace Calculator
{
    class CalcFacade
    {
        public delegate string MethodAudit(string input, string[] symbol);
        public IAudit Audit{ get; set; }
        public ICalculator Calculator { get; set; }
        public IContext Context { get; set;}
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
            MethodAudit Operation = Audit.CheckQuantity;
            Operation += Audit.СheckNumericCharacter;
            Operation += Audit.CorrectInput; 
            for (; ; )
            {
                Data.DataEntry(out string input, out string[] symbol);
                if (Operation(input, symbol) == default)
                    continue;
                Data.OutputDisplay(Calculator.EvaluateExp(input));
                Context.ClearList();
            }
        }
    }
}

