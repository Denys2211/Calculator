using System;
using Collections;

namespace Calculator
{
    interface IContext
    {

        MyCollection<string> this[int i]
        {
            get;
        }

        void СreatureList(int valueList);

        double GetList(int i, int IndexList);

        void RemoveList(int index, int IndexList);

        void ClearList();
    }
}
