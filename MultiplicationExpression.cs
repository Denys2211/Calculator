using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class MultiplicationExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public MultiplicationExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) * rightExpression.Interpret(context);
        }
    }
}
