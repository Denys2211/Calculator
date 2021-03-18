using System;

namespace Exceptions
{
    public class CalcExceptions : Exception
    {
        public CalcExceptions(string message)
            : base(message)
        {
        }
    }
}
