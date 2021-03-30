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

        int IndexStack { get; }

        void CreateExpression(string input);

        void CalculationExp();

        void CreateOperations(int index);

        void NumberFiltering(List<String> list);
    }
}
