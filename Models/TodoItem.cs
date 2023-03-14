using System;

namespace ToDoList.Models
{
    public class TodoItem : BaseModel
    {
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                ClearErrors("Description");
                CheckRequired("Description", "Description is required.", value);
                _description = value;
            }
        }

        private string _subject;
        public string Subject
        {
            get
            {
                return _subject; 
            }

            set
            {
                ClearErrors("Subject");
                CheckRequired("Subject", "Subject is required.", value);
                _subject = value;
            }
        }
    }
}
