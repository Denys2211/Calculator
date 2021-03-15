using System;
using System.Collections.Generic;
using System.Text;

namespace Exception
{
    class UserExceptions : ArgumentException
    {
        public int Value { get; }
        public UserExceptions(string message, int val)
            :base(message)
        {
            Value = val;
        }
    }
}
