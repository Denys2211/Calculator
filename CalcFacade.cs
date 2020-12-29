using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class CalcFacade
    {
        Audit audit;
        Calculation calculation;
        DataTable data;
        internal CalcFacade(Audit audit,Calculation calculation, DataTable data)
        {
            this.audit = audit;
            this.calculation = calculation;
            this.data = data;
        }
        internal void Start()
        {
            for(; ; )
            {
                calculation.DataEntry(out string input, out string[] symbol);
                audit.CheckAvailability(input, out string verify);
                if (verify == "false")
                    continue;
                audit.CheckQuantity(input, symbol, out string verify1);
                if (verify1 == "false")
                    continue;
                audit.СheckNumericCharacter(input, symbol, out string verify2);
                if (verify2 == "false")
                    continue;
                calculation.MatheXpression(data, input);
            }
        }
    }
}

