using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface SqlExpression
    {
        void AddInDB(double result, string input);

        void ReaderDataBase();

        void DeleteDataBase();

        void CreateDataTable();
    }
}
