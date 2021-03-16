using System;
using Calculator;
using Microsoft.Data.Sqlite;
using Exception;

namespace AppData 
{
    public class SqLiteExpressions : ISqlExpression
    {
        private SqliteConnection Connect { get; set; }
        public SqLiteExpressions(SqliteConnection connection)
        {
            Connect = connection;
        }
        public void AddInDB(double result, string input)
        {
            try
            {
                string date_time = (DateTime.Now).ToString();
                string sqlAdd = $"INSERT INTO History(Expression, Result, DateTime) VALUES ('{input}','{result}','{date_time}')";
                using (Connect)
                {
                    Connect.Open();

                    var command = new SqliteCommand();

                    command.Connection = Connect;
                    command.CommandText = sqlAdd;
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new DataBExceptions("Database Add error");
            }
            
        }

        public object[,] ReaderDataBase()

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
                        if (reader.HasRows)
                        {
                           
                            object[,] mas = new object[10, 4];
                            int i = 0;
                            int j = 10;
                            while (reader.Read() && j<=10)
                            {
                                mas[i, 0] = reader.GetValue(0);
                                mas[i, 1] = reader.GetValue(1);
                                mas[i, 2] = reader.GetValue(2);
                                mas[i, 3] = reader.GetValue(3);
                                i++;
                                j--;
                            }
                            return  mas;
                        }
                        else

                            throw new ArgumentException("There is no history of calculations!");
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
        public void DeleteDataBase()
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
                    command.CommandText = "CREATE table IF NOT EXISTS History(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Expression TEXT NOT NULL, Result DOUBLE NOT NULL, DateTime TEXT NOT NULL)";
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
