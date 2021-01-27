using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    // терминальное выражение
    class NumberExpression : IExpression
    {
        int index;
        public NumberExpression(int variableName)
        {
            index = variableName;
        }
        public int Interpret(Context context)
        {
            return context.GetList(index);
        }
    }
}
