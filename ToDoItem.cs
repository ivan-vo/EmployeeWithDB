using System;
using System.Threading.Tasks;
using Npgsql;

namespace tasklist
{
    class ToDoItem
    {
        public readonly string title;
        public readonly bool done;
        public readonly DateTime doDate;
        public string description;
        public ToDoItem(string title, DateTime doDate)
        {
            this.title = title;
            this.doDate = doDate;
        }
        public ToDoItem(string title, DateTime doDate, string description)
        {
            this.title = title;
            this.doDate = doDate;
            this.description = description;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
    }
}
