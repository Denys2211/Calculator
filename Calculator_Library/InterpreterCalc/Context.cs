using System;
using System.Linq;
using Calculator;
using Collections;

namespace InterpreterCalc
{
    class Context : IContext
    {
        private MyCollection<string>[] List; 

        public MyCollection<string> this[int i]
        {
            get
            {
                return List[i];
               
            }
        }

        public void СreateList(int countBracket)
        {

            List = new MyCollection<string>[countBracket];

            for(int i= countBracket-1; i >= 0; i--)
            {
                List[i] = new MyCollection<string>
                {
                    [0] = "0"
                };
            }

        }

        public double GetList(int i, int indexList) => double.Parse(List[indexList][i]);

        public void RemoveList(int index, int indexList)
        {
            List[indexList].RemoveAt(index);
        }
    }

}
