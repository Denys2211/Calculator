using System;
using System.Collections.Generic;
using AppData;
using Microsoft.Data.Sqlite;
using SQLite;

namespace Calculator
{
    interface DataRepository
    {

        void AddInDataBase(string name, SQLiteConnection connection, params string[] inpu);

        IEnumerable<History> ReadDataBase(string name, SQLiteConnection connection);

        void DeleteDataTable(string name, SQLiteConnection connection);
    }
}
