using System;
using System.Collections.Generic;
using System.Linq;
using Calculator;

namespace InterpreterCalc
{
    class Context : IContext
    {
        public Stack<string> Stack { get; set; }

        private List<String> List { get; set; }

        public Stack<string> СreatureStack() => Stack = new Stack<string>();
        
        public List<String> СreatureList(Stack<string> stack)
        {
            List = stack.ToList<String>();

            List.Add("0");

            return List;
        }

        public double GetList(int i) => double.Parse(List[i]);

        public void SetList(int index, double result)
        {
            List[index] = Convert.ToString(result);
        }

        public void RemoveList(int index)
        {
            List.RemoveAt(index);
        }

        public void ClearList()
        {
            List.Clear();
        }
    }

}
