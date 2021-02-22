using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface ICalculator
    {
        void Evaluate(string input, out double result);
    }
}
