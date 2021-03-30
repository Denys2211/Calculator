using System;
using System.Collections.Generic;
using System.Linq;
using Calculator;

namespace InterpreterCalc
{
    class Context : IContext
    {
        private Stack<string>[] Stack; 

        public List<String> List { get; private set; }

        public Stack<string> this[int i]
        {
            get
            {
                return Stack[i];
               
            }
            private set
            {
                Stack[i] = value;
            }
        }

        public void СreatureStack(int countBracket)
        {

            Stack = new Stack<string>[countBracket];

            for(int i= countBracket-1; i >= 0; i--)
            {
                Stack[i] = new Stack<string>();
            }

        }
        public void СreatureList(int indexStack)
        {

            List = Stack[indexStack].ToList<String>();

            List.Add("0");

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
