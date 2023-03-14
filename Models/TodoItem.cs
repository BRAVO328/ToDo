using System;
using System.Linq;

namespace ToDoList.Models
{
    public class TodoItem : BaseModel
    {
        public string Description { get; set; }
        public string Subject { get; set; }

        public override void Validate()
        {
            Errors.Clear();
            CheckRequired("Description", "Description is required.", Description);
            CheckRequired("Subject", "Subject is required.", Subject);
        }
    }
}
