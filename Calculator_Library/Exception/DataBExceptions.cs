using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    public class DataBExceptions : ArgumentException
    {
        public DataBExceptions(string message)
            : base(message)
        {
        }
    }
}
