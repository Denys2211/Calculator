using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IData
    {
        void DataEntry(out string input, out string[] symbol);
        void OutputDisplay(double result);
    }
}
