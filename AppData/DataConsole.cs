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
            string sqlAdd = $"INSERT INTO Users(Result_separated, Date_Time) VALUES ('{Input} = {result}','{date_time}')";
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
            string sqlExpression = "SELECT * FROM Users";
            using (Connect)
            {
                Connect.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, Connect);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var Result_separated = reader.GetValue(0);
                            var Date_Time = reader.GetValue(1);

                            Console.WriteLine($"{Result_separated} \t {Date_Time}");
                        }
                    }
                }
            }

        }
    }
}
