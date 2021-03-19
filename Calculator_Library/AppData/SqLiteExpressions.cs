using System;
using Calculator;
using Microsoft.Data.Sqlite;
using Exceptions;
using System.Collections.Generic;


namespace AppData 
{
    public class SqLiteExpressions : ISqlExpression
    {
        private SqliteConnection Connect { get; set; }
        public SqLiteExpressions(SqliteConnection connection)
        {
            Connect = connection;
            CreateDataTable();

        }
        public void AddInDataBase(double result, string input)
        {
            try
            {
                string date_time = (DateTime.Now).ToString();
                string sqlExpression = $"INSERT INTO History(Expression, Result, DateTime) VALUES ('{input}','{result}','{date_time}')";
                using (Connect)
                {
                    Connect.Open();

                    var command = new SqliteCommand();

                    command.Connection = Connect;
                    command.CommandText = sqlExpression;
                    command.ExecuteNonQuery();
                    
                }
            }
            catch
            {
                throw new DataBExceptions("Database Add error");
            }
            
        }

        public List<object[]> ToReadDataBase()

        {
            try
            {
                string sqlExpress = "SELECT * FROM History";

                using (Connect)
                {
                    Connect.Open();

                    SqliteCommand command = new SqliteCommand(sqlExpress, Connect);
                    
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {

                            var history = new List<object[]>();
                            
                            while (reader.Read())
                            {
                            history.Add(
                                new[]
                                {
                                reader.GetValue(0),
                                reader.GetValue(1),
                                reader.GetValue(2),
                                reader.GetValue(3)
                                }
                                );
                            }
                        if(history.Count == 0)

                            throw new ArgumentException("There is no history of calculations!");

                        return history;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw new DataBExceptions(ex.Message);
            }
            catch
            {
                throw new DataBExceptions("Database reader error");
            }
            
        
        }
        public void DeleteDataTable()
        {
            try
            {
                using (Connect)
                {
                    Connect.Open();

                    var command = new SqliteCommand();

                    command.Connection = Connect;
                    command.CommandText = "DELETE FROM History";
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'History'";
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new DataBExceptions("Database clean error");
            }
        }
        public void CreateDataTable()
        {
            try
            {
                using (Connect)
                {
                    Connect.Open();

                    var command = new SqliteCommand();
                    command.Connection = Connect;
                    command.CommandText = "CREATE table IF NOT EXISTS History(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Expression NTEXT NOT NULL, Result FLOAT NOT NULL, DateTime DATETIME NOT NULL)";
                    command.ExecuteNonQuery();

                }
            }
            catch
            {
                throw new DataBExceptions("Database create error");
            }
        }
    }
}
