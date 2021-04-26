using System;
using Calculator;
using SQLite;
using Exceptions;
using System.Collections.Generic;

namespace AppData 
{
    public class HistoryRepository : DataRepository
    {
        static object locker = new object();
        public  void AddInDataBase( string name, SQLiteConnection connection, params string[] input)
        {
            try
            {
                connection.CreateTable<History>();

                if (name == "History")

                    connection.Execute($"INSERT INTO History(Expression, Result, DateTime) VALUES ('{input[0]}','{input[1]}','{DateTime.Now}')");

                else

                    throw new DataBExceptions("Database Add error");

            }
            catch
            {
                throw new DataBExceptions("Database Add error");
            }
            
        }

        public IEnumerable<History> ReadDataBase(string name, SQLiteConnection connection)

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
