using System.Collections.Generic;
using SQLite;

namespace Calculator.CustomerFacade.CoreModels
{
    interface IDataRepository
    {

        void AddInDataBase(string name, SQLiteConnection connection, double result, params string[] inpu);

        IEnumerable<History> ReadDataBase(SQLiteConnection connection);

        void DeleteDataTable(string name, SQLiteConnection connection);
    }
}
