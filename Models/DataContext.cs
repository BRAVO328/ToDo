using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class DataContext
    {
        public List<TodoItem> TodoItems
        {
            get;
            private set;
        } = new List<TodoItem>();


    }
}
