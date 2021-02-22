using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IAudit
    {
        void СheckNumericCharacter(string input, string[] symbol, out string verify);

        void CheckAvailability(string input, out string verify);

        void CheckQuantity(string input, string[] symbol, out string verify);
    }
}
