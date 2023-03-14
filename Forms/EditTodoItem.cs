using System;
using System.Linq;
using Gtk;
using ToDoList.Models;
using static Gtk.Box;

namespace ToDoList.Forms
{
    public class EditTodoItem : Window
    {
        private TodoItem TodoItem;

        private VBox Layout;

        private Label SubjectLabel;
        private BoxChild SubjectLabelBoxChild;

        private Label SubjectError;
        private BoxChild SubjectErrorBoxChild;

        private Entry Subject;
        private BoxChild SubjectBoxChild;

        private Label DescriptionLabel;
        private BoxChild DescriptionLabelBoxChild;

        private Label DescriptionError;
        private BoxChild DescriptionErrorBoxChild;

        private ScrolledWindow DescriptionScroll;
        private BoxChild DescriptionScrollBoxChild;

        private TextView Description;

        private Button Submit;

        public EditTodoItem(TodoItem todoItem) : base(WindowType.Toplevel)
        {
            TodoItem = todoItem;

            Layout = new VBox();
            Add(Layout);

            // Subject Label

            SubjectLabel = new Label { Text = "Subject" };
            Layout.Add(SubjectLabel);

            SubjectLabelBoxChild = (BoxChild)Layout[SubjectError];
            SubjectLabelBoxChild.Expand = false;
            SubjectLabelBoxChild.Fill = false;

            // Subject Error

            SubjectError = new Label();
            Layout.Add(SubjectError);

            SubjectErrorBoxChild = (BoxChild)Layout[SubjectError];
            SubjectErrorBoxChild.Expand = false;
            SubjectErrorBoxChild.Fill = false;

            // Subject

            Subject = new Entry { Text = todoItem.Subject };
            Layout.Add(Subject);

            SubjectBoxChild = (BoxChild)Layout[Subject];
            SubjectBoxChild.Expand = false;
            SubjectBoxChild.Fill = false;

            // Description Label

            DescriptionLabel = new Label { Text = "Description" };
            Layout.Add(DescriptionLabel);

            DescriptionLabelBoxChild = (BoxChild)Layout[DescriptionError];
            DescriptionLabelBoxChild.Expand = false;
            DescriptionLabelBoxChild.Fill = false;

            // Description Error

            DescriptionError = new Label();
            Layout.Add(DescriptionError);

            DescriptionErrorBoxChild = (BoxChild)Layout[DescriptionError];
            DescriptionErrorBoxChild.Expand = false;
            DescriptionErrorBoxChild.Fill = false;

            // Description

            DescriptionScroll = new ScrolledWindow();
            Layout.Add(DescriptionScroll);

            DescriptionScrollBoxChild = (BoxChild)Layout[DescriptionScroll];
            DescriptionScrollBoxChild.Expand = false;
            DescriptionScrollBoxChild.Fill = false;

            Description = new TextView();
            Description.Buffer.Text = todoItem.Description;
            DescriptionScroll.Add(Description);

            // Button

            Submit = new Button { Label = "Submit" };
            Submit.Clicked += Submit_Clicked;
            Layout.Add(Submit);

            Child.ShowAll();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            TodoItem.Subject = Subject.Text;
            TodoItem.Description = Description.Buffer.Text;
            TodoItem.Validate();

            if (TodoItem.Errors.ContainsKey("Subject"))
            {
                SubjectError.Text = TodoItem.Errors["Subject"];
                SubjectError.Show();
            }
            else
            {
                SubjectError.Hide();
            }

            if (TodoItem.Errors.ContainsKey("Description"))
            {
                DescriptionError.Text = TodoItem.Errors["Description"];
                DescriptionError.Show();
            }
            else
            {
                DescriptionError.Hide();
            }

            if (!TodoItem.Errors.Any())
            {
                Destroy();
            }
        }
    }
}
