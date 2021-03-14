using System;
using System.Collections.Generic;
using System.Text;

namespace Exeption
{
    class UserExeption : ArgumentException
    {
        public int Value { get; }
        public UserExeption(string masseg, int val)
            :base(masseg)
        {
            Value = val;
        }
    }
}
