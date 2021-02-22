using System;
using System.Data;
using System.Linq;

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
                Audit.CheckAvailability(input, out string verify);
                if (verify == default)
                    continue;
                Audit.CheckQuantity(input, symbol, out string verify1);
                if (verify1 == default)
                    continue;
                Audit.СheckNumericCharacter(input, symbol, out string verify2);
                if (verify2 == default)
                    continue;
                Calculator.Evaluate(input, out double result);
                Data.OutputDisplay(result);
                Context.ClearList();
            }
        }
    }
}

