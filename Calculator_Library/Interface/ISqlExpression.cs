using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface ISqlExpression
    {
        void AddInDataBase(double result, string input);

        List<object[]> ReadDataBase();

        void DeleteDataTable();

        void CreateDataTable();

    }
}
