using Calculator.CustomerFacade.Collections;

namespace Calculator.CustomerFacade.CustomerInterpreter
{
    interface IContext
    {

        MyCollection<string> this[int i]
        {
            get;
        }

        void СreateList(int valueList);

        double GetList(int i, int IndexList);

        void RemoveList(int index, int IndexList);

    }
}
