using System;
using Calculator;
using SQLite;
using System.Collections.Generic;
using Calculator.CustomerFacade.Exceptions;

namespace Calculator.CustomerFacade.CoreModels
{
    public class HistoryRepository : IDataRepository
    {
        static readonly object locker = new object();
        public  void AddInDataBase( string name, SQLiteConnection connection, double result, params string[] input)
        {
            try
            {
                connection.CreateTable<History>();

                if (name == "History")

                    connection.Execute($"INSERT INTO History(Expression, Result, DateTime) VALUES ('{input[0]}','{result}','{DateTime.Now}')");

                else

                    throw new DataBExceptions("Database Add error");

            }
            catch
            {
                throw new DataBExceptions("Database Add error");
            }
            
        }

        public IEnumerable<History> ReadDataBase(SQLiteConnection connection)

        {
            try
            {
                lock(locker)
                {
                    return connection.Table<History>().ToList();
                }
            }
            catch
            {
                throw new DataBExceptions("Database reader error");
            }


        }
        public void DeleteDataTable(string name, SQLiteConnection connection)
        {
            try
            {
                connection.Execute($"DELETE FROM {name}");
                connection.Execute($"UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = '{name}'");

            }
            catch
            {
                throw new DataBExceptions("Database clean error");
            }
        }
    }
}
