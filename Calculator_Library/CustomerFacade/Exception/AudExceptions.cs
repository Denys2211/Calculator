using System;

namespace Calculator.CustomerFacade.Exceptions
{
    public class AudExceptions : Exception
    {
        public AudExceptions(string message)
            : base(message)
        {
        }
    }
}
