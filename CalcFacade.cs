using System;
using System.Data;
using System.Linq;

namespace ConsoleApp
{
    class CalcFacade
    {
        Audit audit;
        Calculator calculator;
        Context context;
        IData data;
        internal CalcFacade(IData data, Audit audit,Calculator calculator, Context context)
        {
            this.audit = audit;
            this.calculator = calculator;
            this.context = context;
            this.data = data;
        }
        internal void Start()
        {
            for(; ; )
            {
                data.DataEntry(out string input, out string[] symbol);
                audit.CheckAvailability(input, out string verify);
                if (verify == null)
                    continue;
                audit.CheckQuantity(input, symbol, out string verify1);
                if (verify1 == null)
                    continue;
                audit.СheckNumericCharacter(input, symbol, out string verify2);
                if (verify2 == null)
                    continue;
                calculator.Evaluate(input, out double result);
                data.OutputDisplay(result);
                context.ClearList();
            }
        }
    }
}

