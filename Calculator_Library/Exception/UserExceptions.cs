using System;

namespace Exceptions
{
    public class UserExceptions : Exception
    {
        public int Value { get; }
        public UserExceptions(string message, int val)
            :base(message)
        {
            Value = val;
        }
    }
}
