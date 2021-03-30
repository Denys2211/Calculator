using System;
using System.Collections.Generic;

namespace Calculator
{
    interface IContext
    {

        Stack<string> this[int i]
        {
            get;
        }
        List<String> List { get; }

        void СreatureStack(int valueStack);

        void СreatureList(int indexStack);

        double GetList(int i);

        void SetList(int index, double result);

        void RemoveList(int index);

        void ClearList();
    }
}
