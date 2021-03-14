using System;
using System.Collections.Generic;
using System.Text;

namespace Exeption
{
    class UserExeption : ArgumentException
    {
        public int Value { get; }
        public UserExeption(string messag, int val)
            :base(messag)
        {
            Value = val;
        }
    }
}
