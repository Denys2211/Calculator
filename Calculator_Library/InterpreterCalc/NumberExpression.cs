using Calculator;
using Exceptions;
using System;

namespace InterpreterCalc
{   
    struct NumberExpression : IExpression
    {
        
        private int Index { get; set; }

        public IContext Context { get; set; }

        public int IndexList { get; set; }

        private double Value { get; set; }

        public static implicit operator NumberExpression(int value) => new NumberExpression { Index = value };

        public static explicit operator double(NumberExpression instance1) => instance1.Value;

        public static NumberExpression operator +(NumberExpression instance1, NumberExpression instance2)
        {
            return new NumberExpression { Value = instance1.Interpret() + instance2.Interpret() };
        }
        public static NumberExpression operator -(NumberExpression instance1, NumberExpression instance2)
        {
            return new NumberExpression { Value = instance1.Interpret() - instance2.Interpret() };
        }
        public static NumberExpression operator /(NumberExpression instance1, NumberExpression instance2)
        {
            if (instance2.Interpret() == 0)
                throw new CalcExceptions("Division by 0!!!");
            return new NumberExpression { Value = instance1.Interpret() / instance2.Interpret() };
           
        }
        public static NumberExpression operator *(NumberExpression instance1, NumberExpression instance2)
        {
            return new NumberExpression { Value = instance1.Interpret() * instance2.Interpret() };
        }
        public double Interpret() => Context.GetList(Index, IndexList);
    }
}
