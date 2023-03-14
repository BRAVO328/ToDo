using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public abstract class BaseModel
    {
        private List<Error> _errors = new List<Error>();

        protected void AddError(string propertyName, string message)
        {
            Error error = new Error();
            error.PropertyName = propertyName;
            error.Message = message;
            _errors.Add(error);
        }

        protected void ClearErrors(string propertyName)
        {
            foreach (Error error in _errors.ToArray())
            {
                _errors.Remove(error);
            }
        }

        protected void CheckRequired(string propertyName, string message, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                AddError(propertyName, message);
            }
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Any();
            }
        }

        public bool PropertyHasErrors(string propertyName)
        {
            return _errors.Any(e => e.PropertyName == propertyName);
        }

        public string FirstPropertyErrorMessage(string propertyName)
        {
            Error error = _errors.First(e => e.PropertyName == propertyName);
            return error.Message;
        }
    }
}