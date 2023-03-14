using System;
using ToDoList.Models;
using System.Linq;
using Gtk;

namespace ToDoList.Forms
{
    public partial class EditToDoItem : Window
    {
        protected TodoItem Model
        {
            get;
            private set;
        }

        public EditToDoItem(TodoItem model) : base(WindowType.Toplevel)
        {
            Model = model;
            Build();
            Populate();
        }

        protected void Populate()
        {
            Description.Buffer.Text = Model.Description;
        }

        protected void OnDescriptionKeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            Model.Description = Description.Buffer.Text;
            if (Model.PropertyHasErrors("Description"))
            {
                DescriptionError.Text = Model.FirstPropertyErrorMessage("Description");
                DescriptionError.Visible = true;
            }
            else
            {
                DescriptionError.Visible = false;
            }
        }

        protected void OnEntry2KeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            Model.Subject = Subject.Text;
            if (Model.PropertyHasErrors("Subject"))
            {
                DescriptionError.Text = Model.FirstPropertyErrorMessage("Subject");
                DescriptionError.Visible = true;
            }
            else
            {
                DescriptionError.Visible = false;
            }
        }
    }
}
