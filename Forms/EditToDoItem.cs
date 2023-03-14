using System;
using Gtk;
using ToDoList.Models;
using static Gtk.Box;

namespace ToDoList.Forms
{
    public class EditTodoItem : Window
    {
        private TodoItem Model;

        private VBox Layout;

        private Label SubjectLabel;
        private BoxChild SubjectLabelBoxChild;

        private Label SubjectError;
        private BoxChild SubjectErrorBoxChild;

        private Entry Subject;
        private BoxChild SubjectBoxChild;

        private Label DescriptionLabel;
        private Label DescriptionError;
        private ScrolledWindow DescriptionScroll;
        private TextView Description;

        public EditTodoItem(TodoItem model) : base(WindowType.Toplevel)
        {
            Model = model;

            Layout = new VBox();
            Add(Layout);

            SubjectLabel = new Label { }


        }
    }
}
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
