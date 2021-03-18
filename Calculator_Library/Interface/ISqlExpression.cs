using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface ISqlExpression
    {
        void AddInDB(double result, string input);

        List<object[]> ReaderDataBase();

        void DeleteDataBase();

        void CreateDataTable();

    }
}
