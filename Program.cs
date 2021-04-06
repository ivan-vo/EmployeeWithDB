using System;
using System.Threading.Tasks;
using Npgsql;

namespace tasklist
{
    class Program
    {
        static void Main()
        {
            Task task = ReadTasks();
            task.Wait();
        }
        static async Task ReadTasks()
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Insert some data
            await using (var cmd = new NpgsqlCommand("INSERT INTO tasklist (title, done) VALUES (@title, false)", conn))
            {
                cmd.Parameters.AddWithValue("title", "Hello world task");
                await cmd.ExecuteNonQueryAsync();
            }

            // // Retrieve all rows
            await using (var cmd = new NpgsqlCommand("SELECT title, done FROM tasklist", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {   
                    var title = reader.GetString(0);
                    var done = reader.GetBoolean(1);
                    char doneFlage = done ? 'x' : ' ';
                    Console.WriteLine($"- [{doneFlage}] {title}");
                }
            // You can find more info about the ADO.NET API in the MSDN docs or in many tutorials on the Internet.
            // test
        }
    }
}
