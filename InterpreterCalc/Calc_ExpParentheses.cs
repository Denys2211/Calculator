﻿using System;
using System.Collections.Generic;
using Calculator;

namespace InterpreterCalc
{

    class Calc_ExpParentheses : ICalculator
    {
        private double Result { get; set; }
        private IContext Context { get; set; }
        internal Calc_ExpParentheses(IContext context)
        {
            Context = context;
        }
        public double EvaluateExp(string input)
        {
            Stack<string> stack = Context.СreatureStack();
            string value = "";
            string innerExp = "";
            for (int i = 0; i < input.Length; i++)
            {
                String symbol = input.Substring(i, 1);
                char chr = symbol.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }
                if (symbol.Equals("("))
                {
                    i++;
                    int bracketCount = 0;
                    for (; i < input.Length; i++)
                    {
                        symbol = input.Substring(i, 1);

                        if (symbol.Equals("(")) bracketCount++;

                        if (symbol.Equals(")"))
                        {
                            if (bracketCount == 0) break;
                            bracketCount--;
                        }
                        innerExp += symbol;
                    }
                    stack.Push(EvaluateExp(innerExp).ToString());
                }

                if (symbol.Equals("+") ||
                    symbol.Equals("-") ||
                    symbol.Equals("*") ||
                    symbol.Equals("/"))

                    stack.Push(symbol);

                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += symbol;
                    if (i == (input.Length - 1))
                        stack.Push(value);

                }
            }
            List<String> list = Context.СreatureList(stack);
            IExpression[] Number = new IExpression[list.Count];
            IExpression expression;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] != "+" &&
                    list[i] != "-" &&
                    list[i] != "*" &&
                    list[i] != "/")

                    Number[i] = new NumberExpression(i);

            }
            for (int i = list.Count - 2; i >= 0; i--)
            {
                switch(list[i])
                {
                    case "*":
                        expression = new MultiplicationExpression(Number[i + 1], Number[i - 1]);
                        Result = expression.Interpret(Context);
                        Context.RemoveList(i - 1);
                        Context.RemoveList(i);
                        Context.SetList(i - 1, Result);
                        i -= 1;
                        break;
                    case "/":
                        expression = new DivisionExpression(Number[i + 1], Number[i - 1]);
                        Result = expression.Interpret(Context);
                        Context.RemoveList(i - 1);
                        Context.RemoveList(i);
                        Context.SetList(i - 1, Result);
                        i -= 1;
                        break;
                }
            }
            for (int i = list.Count - 2; i >= 0; i--)
            {
                switch(list[i])
                {
                    case "-":
                        expression = new SubtractExpression(Number[i + 1], Number[i - 1]);
                        Result = expression.Interpret(Context);
                        Context.RemoveList(i - 1);
                        Context.RemoveList(i);
                        Context.SetList(i - 1, Result);
                        i -= 1;
                        break;
                    case "+":
                        expression = new AddExpression(Number[i + 1], Number[i - 1]);
                        Result = expression.Interpret(Context);
                        Context.RemoveList(i - 1);
                        Context.RemoveList(i);
                        Context.SetList(i - 1, Result);
                        i -= 1;
                        break;
                }
            }
            return Result = double.Parse(list[0]);
        }
        
    }
}