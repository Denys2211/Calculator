using System;
using System.Collections.Generic;

namespace Calculator
{
    interface IContext
    {
        Stack<string> СreatureStack();
        List<String> СreatureList(Stack<string> stack);
        double GetList(int i);
        void SetList(int index, double result);
        void RemoveList(int index);
        void ClearList();
    }
}
