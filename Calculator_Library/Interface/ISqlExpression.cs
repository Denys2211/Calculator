using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Calculator
{
    interface ISqlExpression
    {

        void AddInDataBase(string name, SqliteConnection connection, params string[] inpu);

        object[][] ReadDataBase(string name, SqliteConnection connection);

        void DeleteDataTable(string name, SqliteConnection connection);

        void CreateDataTable(string name, SqliteConnection connection);

        int GetNumberOfItemsInDB(string name, SqliteConnection connection);

    }
}
