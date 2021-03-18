using System;

namespace Exceptions
{
    public class AudExceptions : Exception
    {
        public AudExceptions(string message)
            : base(message)
        {
        }
    }
}
