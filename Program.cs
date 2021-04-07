using System;
using System.Threading.Tasks;
using Npgsql;

namespace tasklist
{
    class Program
    {
        static void Main()
        {
            // ToDoTaskService.PrintAllTasks();
            // ToDoItem task1 = new ToDoItem("Test data",DateTime.Parse("2021-04-10"),"Кипити молока, м*яса, хліб, рибу");
            // ToDoTaskService.AddTask(task1);
            // ToDoTaskService.DeleteTask(12);
            // ToDoTaskService.CompleteTask(2);
            ToDoTaskService.PrintAllTasks();

        }
    }
}
