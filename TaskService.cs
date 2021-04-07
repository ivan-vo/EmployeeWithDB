using System;
using System.Threading.Tasks;
using Npgsql;

namespace tasklist
{
    class ToDoTaskService
    {
        public static void OpenDB()
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            // Insert some data
            // using (var cmd = new NpgsqlCommand("INSERT INTO tasklist (title, done) VALUES (@title, false)", conn))
            // {
            //     cmd.Parameters.AddWithValue("title", "Hello world task");
            //     cmd.ExecuteNonQuery();
            // }
            // // Retrieve all rows
            // using (var cmd = new NpgsqlCommand("SELECT title, done FROM tasklist", conn))
            // using (var reader = cmd.ExecuteReader())
            //     while (reader.Read())
            //     {   
            //         var title = reader.GetString(0);
            //         var done = reader.GetBoolean(1);
            //         char doneFlage = done ? 'x' : ' ';
            //         Console.WriteLine($"- [{doneFlage}] {title}");
            //     }
            // You can find more info about the ADO.NET API in the MSDN docs or in many tutorials on the Internet.
            // test
        }
        public static void PrintAllTasks()
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT id, title, done, do_date, description FROM tasklist", conn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    var title = reader.GetString(1);
                    var done = reader.GetBoolean(2);
                    char doneFlage = done ? 'x' : ' ';
                    int id = reader.GetInt32(0);
                    string date;
                    string description = reader.GetString(4);
                    if (reader.IsDBNull(3))
                    {
                        date = "No date";
                    }
                    else
                    {
                        date = reader.GetDateTime(3).ToString();
                    }

                    // var desc = reader.GetString(3);                
                    Console.WriteLine($"{id} - \t[{doneFlage}] {title} {date} [{description}]");
                }
        }
        public static void AddTask(ToDoItem item)
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO tasklist (title, done, description,do_date) VALUES (@title, false, @description, @do_date)", conn))
            {
                cmd.Parameters.AddWithValue("title", item.title);
                cmd.Parameters.AddWithValue("description", item.description);
                cmd.Parameters.AddWithValue("do_date", item.doDate);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteTask(int id)
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM tasklist WHERE id =@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public static void CompleteTask(int id)
        {
            var connString = "Host=127.0.0.1;Username=to_do_task_app;Password=ivanvoronov;Database=to_do_task";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("update tasklist set done=true WHERE id =@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
