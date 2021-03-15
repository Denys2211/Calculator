using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    class AudExceptions : ArgumentException
    {
        public AudExceptions(string message)
            : base(message)
        {
        }
    }
}
