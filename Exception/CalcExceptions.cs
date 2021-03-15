using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    class CalcExceptions : ArgumentException
    {
        public CalcExceptions(string message)
            : base(message)
        {
        }
    }
}
