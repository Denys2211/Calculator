using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Context
    {
        Stack<String> stack;
        List<String> list;
        public Context()
        {
            stack = new Stack<String>();
        }
        internal void FormationExpression(string input, out List<String> list)
        {
            string value = "";
            for (int j = 0; j < input.Length; j++)
            {
                String symbol = input.Substring(j, 1);
                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }
                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))
                
                    stack.Push(symbol);
                
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (j == (input.Length - 1))
                        stack.Push(value);

                }
            }
            list = stack.ToList<String>();
        }
        public void Transfer(List<String> list)
        {
            this.list = list;
        }
        public int GetVariable(int i)
        {
            return int.Parse(list[i]);
        }

        public void SetVariable(int index, int result)
        {

            list[index] = Convert.ToString(result);
        }
        public void RemoveVariables(int index)
        {
            list.RemoveAt(index);
        }
        internal void Clear()
        {
            stack.Clear();
            list.Clear();
        }
    }
    
}
