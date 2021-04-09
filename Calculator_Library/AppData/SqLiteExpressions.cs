using System;
using Calculator;
using Microsoft.Data.Sqlite;
using Exceptions;

namespace AppData 
{
    public class SqLiteExpressions : ISqlExpression
    {

        public void AddInDataBase( string name, SqliteConnection connection, params string[] input)
        {
            try
            {
                CreateDataTable(name, connection);

                string date_time = (DateTime.Now).ToString();

                string sqlExp;

                if(name =="History")

                    sqlExp = $"INSERT INTO History(Expression, Result, DateTime) VALUES ('{input[0]}','{input[1]}','{date_time}')";

                else if (name == "Log")

                    sqlExp = $"INSERT INTO Log(DateTime, Message) VALUES ('{date_time}','{input[0]}')";

                else

                    throw new DataBExceptions("Database Add error");

                using (connection)
                {
                    connection.Open();

                    var command = new SqliteCommand
                    {
                        Connection = connection,

                        CommandText = sqlExp
                    };
                    command.ExecuteNonQuery();
                    
                }
            }
            catch
            {
                throw new DataBExceptions("Database Add error");
            }
            
        }

        public object[][] ReadDataBase(string name, SqliteConnection connection)

        {
            try
            {
                int numberOfItems = GetNumberOfItemsInDB(name, connection);

                string SqlExp = $"SELECT * FROM {name}";

                using (connection)
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand(SqlExp, connection);

                    using SqliteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        object[][] table = new object[numberOfItems][];

                        for (int i = 0; reader.Read(); i++)
                        {
                            table[i] = new object[reader.FieldCount];

                            for (int j = 0; j < reader.FieldCount; j++)

                                table[i][j] = reader[j];

                        }
                        return table;
                    }
                    else

                        throw new ArgumentException("There is no history!!!");
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
        public void DeleteDataTable(string name, SqliteConnection connection)
        {
            try
            {

                using (connection)
                {
                    connection.Open();

                    var command = new SqliteCommand
                    {
                        Connection = connection,

                        CommandText = $"DELETE FROM {name}"
                    };
                    command.ExecuteNonQuery();

                    command.CommandText = $"UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = '{name}'"; 

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new DataBExceptions("Database clean error");
            }
        }
        public void CreateDataTable(string name, SqliteConnection connection)
        {
            try
            {
                string SqlExp;

                if (name == "History")

                SqlExp = "CREATE table IF NOT EXISTS History(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Expression NTEXT NOT NULL, Result FLOAT NOT NULL, DateTime DATETIME NOT NULL)";

                else if (name == "Log")

                SqlExp = "CREATE table IF NOT EXISTS Log(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, DateTime DATETIME NOT NULL, Message NTEXT NOT NULL)";
                
                else

                    throw new DataBExceptions("Database create error");

                using (connection)
                {
                    connection.Open();

                    var command = new SqliteCommand
                    {
                        Connection = connection,

                        CommandText = SqlExp
                    };
                    command.ExecuteNonQuery();

                }
            }
            catch
            {
                throw new DataBExceptions("Database create error");
            }
        }
        public int GetNumberOfItemsInDB(string name, SqliteConnection connection)
        {
            string SqlExp = $"SELECT COUNT(_id) FROM {name}";

            using (connection)
            {
                connection.Open();

                SqliteCommand queryCommand = new SqliteCommand
                {
                    Connection = connection,

                    CommandText = SqlExp
                };
                queryCommand.ExecuteNonQuery();

                return Convert.ToInt32(queryCommand.ExecuteScalar());
            }
        }
    }
}
