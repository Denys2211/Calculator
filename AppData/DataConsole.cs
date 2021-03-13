using System;
using Calculator;
using Microsoft.Data.Sqlite;                  

namespace AppData
{
    class DataConsole : IData
    {
        private SqliteConnection Connect{ get; set;}
        private string Input { get; set; }
        public DataConsole(SqliteConnection connection)
        {
            Connect = connection;
            CreateDataTable();
        }
        public string DataEntry(out string[] symbol)
        {
            symbol = new[] { "*(", "+(", "-(", "/(", ")*", ")/", ")+", ")-", "-", "+", "/", "*", ")", "(", " (", ") ", };
            Console.Write("Separated MatheXpression: ");
            return  Input = Console.ReadLine();
        }
        public void OutputDisplay(double result)
        {
            Console.WriteLine($"Calculation result: {result}");
            string date_time = (DateTime.Now).ToString();
            string sqlAdd = $"INSERT INTO History(Expression, Result, DateTime) VALUES ('{Input}','{result}','{date_time}')";
            using (Connect)
            {
                Connect.Open();

                var command = new SqliteCommand();

                command.Connection = Connect;
                command.CommandText = sqlAdd;
                command.ExecuteNonQuery();
            }
        }

        public void ReaderDataBase()
    
        {
            string sqlExpression = "SELECT * FROM History";
            using (Connect)
            {
                Connect.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, Connect);
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
                        Console.WriteLine("There is no history of calculations!");

                }
            }
        }
        public void DeleteDataBase()
        {
            using (Connect)
            {
                Connect.Open();

                var command = new SqliteCommand();

                command.Connection = Connect;
                command.CommandText = "DELETE FROM History";
                command.ExecuteNonQuery();
                Console.WriteLine("-----------Done!---------");
            }

        }
        public void CreateDataTable()
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
    }

}
