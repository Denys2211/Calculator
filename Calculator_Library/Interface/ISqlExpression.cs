using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface ISqlExpression
    {
        void AddInDB(double result, string input);

        object[,] ReaderDataBase();

        void DeleteDataBase();

        void CreateDataTable();

        int GetNumberOfItemsInDB();
    }
}
