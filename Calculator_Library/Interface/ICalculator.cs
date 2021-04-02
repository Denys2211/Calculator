using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterpreterCalc;

namespace Calculator
{
    interface ICalculator
    {
        double Result { get; }

        int IndexList { get; }

        void CreateExpression(string input);

        void CalculateExpression();

        void FilterNumbers();
    }
}
