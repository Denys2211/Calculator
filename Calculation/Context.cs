using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp;

namespace Interpreter
{
    class Context: IContext
    {
        List<String> list;

        public void СreatureList(Stack<string> stack, out List<String> list)
        {
             this.list = list = stack.ToList<String>();
        }

        public double GetList(int i)
        {
            return double.Parse(list[i]);
        }

        public void SetList(int index, double result)
        {
            list[index] = Convert.ToString(result);
        }

        public void RemoveList(int index)
        {
            list.RemoveAt(index);
        }

        public void ClearList()
        {
            list.Clear();
        }
    }
    
}
