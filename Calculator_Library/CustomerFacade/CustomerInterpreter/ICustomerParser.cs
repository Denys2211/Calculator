namespace Calculator.CustomerFacade.CustomerInterpreter
{
    interface ICustomerParser
    { 
        double Result { get; }

        int IndexList { get; }

        void CreateExpression(string input);

        void CalculateExpression();

        void FilterNumbers();
    }
}
