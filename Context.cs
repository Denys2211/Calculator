using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Context
    {
        Dictionary<string, int> variables;
        Stack<String> stack;
        List<String> list;
        public Context()
        {
            variables = new Dictionary<string, int>();
            stack = new Stack<String>();
        }
        internal List<String> FormationExpression(string input)
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
            return list;

        }
        public int GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, int value)
        {
                variables.Add(name, value);
        }
        public void RemoveVariables(string name)
        {
            variables.Remove(name);
        }
        internal void Clear()
        {
            variables.Clear();
            stack.Clear();
        }
    }
    
}
