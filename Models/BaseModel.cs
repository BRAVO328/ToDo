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

        protected void CheckRequired(string propertyName, string propertyValue, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                Errors[propertyName] = errorMessage;
            }
        }

        public abstract void Validate();
    }
}