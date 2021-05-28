using System;

namespace Calculator.CustomerFacade.Exceptions
{
    public class DataBExceptions : Exception
    {
        public DataBExceptions(string message)
            : base(message)
        {
        }
    }
}
