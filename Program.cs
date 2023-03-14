using System;
using Gtk;
using ToDoList.Forms;
using ToDoList.Models;

namespace ToDoList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            TodoItem model = new TodoItem();
            EditToDoItem window = new EditToDoItem(model);
            window.Show();
            Application.Run();
        }
    }
}
