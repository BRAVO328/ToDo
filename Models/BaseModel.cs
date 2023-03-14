using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public abstract class BaseModel
    {
        public Dictionary<string, string> Errors
        {
            get;
            private set;
        } = new Dictionary<string, string>();

        protected void CheckRequired(string propertyName, string message, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Errors[propertyName] = message;
            }
        }

        public abstract void Validate();
    }
}