using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface ISqlExpression
    {
        void AddInDataBase(double result, string input);

        List<object[]> ToReadDataBase();

        void DeleteDataTable();

        void CreateDataTable();

    }
}
