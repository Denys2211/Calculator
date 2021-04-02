using Calculator;

namespace InterpreterCalc
{
    class NumberExpression : IExpression
    {
        private int Index { get; set; }
        private int IndexList { get; set; }
        public NumberExpression(int variableName, int IndexList)
        {
            Index = variableName;
            this.IndexList = IndexList;
        }
        public double Interpret(IContext context) => double.Parse(context[IndexList][Index]);
    }
}
