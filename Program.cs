using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
         static void Main()
         {
            Calculation calc = new Calculation();
            Audit aud = new Audit();
            CalcFacade ide = new CalcFacade(aud, calc);
            User uss = new User();
            uss.Star(ide);
         }
    }
}
    
