using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Context
    {
        Stack<String>[] stack;
        List<String> list;
        public Context()
        {
            stack = new Stack<String>[5];
        }
         
        internal void FormationExpression(int indexStack, string input, out bool temples, out string innerExp, out int bracketCount)
        {
            stack[indexStack] = new Stack<String>();
            string value = "";
            innerExp = "";
            temples = false;
            bracketCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                String symbol = input.Substring(i, 1);
                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack[indexStack].Push(value);
                    value = "";
                }
                if (symbol.Equals("("))
                {
                    temples = true;
                    innerExp = "";
                    i++;
                    bracketCount = 1;
                    for (; i < input.Length; i++)
                    {
                        symbol = input.Substring(i, 1);

                        if (symbol.Equals("(")) bracketCount++;

                        if (symbol.Equals(")"))
                        {
                            if (bracketCount == 1) break;
                            bracketCount--;
                        }
                        innerExp += symbol;
                    }
                }
                if (temples)
                    break;
                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))

                    stack[indexStack].Push(symbol);

                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (i == (input.Length - 1))
                        stack[indexStack].Push(value);

                }
            }
                
        }

        public void СreatureList(int indexStack, out List<String> list)
        {
             this.list = list = stack[indexStack].ToList<String>();
        }

        public int GetList(int i)
        {
            return int.Parse(list[i]);
        }

        public void SetList(int index, int result)
        {
            list[index] = Convert.ToString(result);
        }

        public void SetStack(int indexStack, int result)
        {
            stack[indexStack].Push(Convert.ToString(result)); 
        }

        public void RemoveList(int index)
        {
            list.RemoveAt(index);
        }

        internal void ClearStack(int indexStack)
        {
            stack[indexStack].Clear();
        }

        internal void ClearList()
        {
            list.Clear();
        }
    }
    
}
