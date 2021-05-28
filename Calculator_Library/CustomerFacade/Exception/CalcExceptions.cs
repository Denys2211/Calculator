using System;

namespace Calculator.CustomerFacade.Exceptions
{
    public class CalcExceptions : Exception
    {
        public CalcExceptions(string message)
            : base(message)
        {
        }
    }
}
