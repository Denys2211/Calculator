using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    // интерфейс интерпретатора
    interface IExpression
    {
        int Interpret(Context context);
    }
}
