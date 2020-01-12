using System;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Linq;

namespace SQLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SQLiteConnection("URI=file:chinook.db; FailIfMissing = True");
            connection.Open();

            string query = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1";

            var command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            Console.WriteLine("Results");

            while(reader.Read())
            {
                Console.WriteLine($"{reader.GetString(0)}");
            }

            Console.WriteLine("");
            Console.WriteLine("Results with linq");

            connection.Table<

            Console.ReadLine();
            connection.Close();
        }
    }
}
