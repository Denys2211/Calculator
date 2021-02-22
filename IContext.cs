using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IContext
    {
        void СreatureList(Stack<string> stack, out List<String> list);
        double GetList(int i);
        void SetList(int index, double result);
        void RemoveList(int index);
        void ClearList();
    }
}
