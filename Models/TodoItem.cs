using System;

namespace ToDoList.Models
{
    public class TodoItem : BaseModel
    {
        public string Subject { get; set; }
        public string Description { get; set; }

        public override void Validate()
        {
            Errors.Clear();
            CheckRequired("Subject", Subject, "Subject is required.");
            CheckRequired("Description", Description, "Description is required.");
        }
    }
}
