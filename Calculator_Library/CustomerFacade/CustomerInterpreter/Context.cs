using System.Globalization;
using Calculator;
using Calculator.CustomerFacade.Collections;

namespace Calculator.CustomerFacade.CustomerInterpreter
{
    internal class Context : IContext
    {
        public MyCollection<string>[] CalcExpression { get; private set; }

        public MyCollection<string> this[int i] => CalcExpression[i];

        public void СreateList(int countBracket)
        {

            CalcExpression = new MyCollection<string>[countBracket];

            for(int i= countBracket-1; i >= 0; i--)
            {
                CalcExpression[i] = new MyCollection<string>
                {
                    [0] = "0"
                };
            }

        }

        public double GetList(int i, int indexList)
        {

            return double.Parse(CalcExpression[indexList][i], CultureInfo.InvariantCulture);
                
        }

        public void RemoveList(int index, int indexList)
        {
            CalcExpression[indexList].RemoveAt(index);
        }
    }

}
