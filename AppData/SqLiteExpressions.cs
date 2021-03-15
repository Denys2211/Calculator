using System;
using Calculator;
using Microsoft.Data.Sqlite;
using Exception;

namespace AppData 
{
    class SqLiteExpressions : SqlExpression
    {
        private SqliteConnection Connect { get; set; }
        public SqLiteExpressions(SqliteConnection connection)
        {
            Connect = connection;
            CreateDataTable();
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

        public void ReaderDataBase()

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
                        Console.WriteLine("Id_\tExpression\tResult\t\tDateTime");
                        while (reader.Read())
                        {
                            var Id_ = reader.GetValue(0);
                            var Expression = reader.GetValue(1);
                            var Result = reader.GetValue(2);
                            var DateTime = reader.GetValue(3);

                            Console.WriteLine(new string('_', 55));
                            Console.WriteLine($"{Id_}\t{Expression}\t\t{Result}\t{DateTime}");
                        }
                        Console.WriteLine(new string('_', 55));
                    }
                    else

                        throw new DataBExceptions("There is no history of calculations!");
                }
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
                    Console.WriteLine("-----------Done!---------");
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
