using System;
using System.Linq;
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
        private BoxChild SubjectLabelBox;
        private Label SubjectError;
        private BoxChild SubjectErrorBox;
        private Entry Subject;
        private BoxChild SubjectBox;

        private Label DescriptionLabel;
        private BoxChild DescriptionLabelBox;
        private Label DescriptionError;
        private BoxChild DescriptionErrorBox;
        private TextView Description;
        private ScrolledWindow DescriptionScroll;
        private BoxChild DescriptionScrollBox;

        private Button Submit;
        private BoxChild SubmitBox;

        public EditTodoItem(TodoItem model) : base(WindowType.Toplevel)
        {
            Model = model;

            Layout = new VBox();

            SubjectLabel = new Label();
            SubjectLabel.Text = "Subject";
            Layout.Add(SubjectLabel);
            SubjectLabelBox = (BoxChild)Layout[SubjectLabel];
            SubjectLabelBox.Expand = false;
            SubjectLabelBox.Fill = false;

            SubjectError = new Label();
            Layout.Add(SubjectError);
            SubjectErrorBox = (BoxChild)Layout[SubjectError];
            SubjectErrorBox.Expand = false;
            SubjectErrorBox.Fill = false;

            Subject = new Entry();
            Layout.Add(Subject);
            SubjectBox = (BoxChild)Layout[Subject];
            SubjectBox.Expand = false;
            SubjectBox.Fill = false;

            DescriptionLabel = new Label();
            DescriptionLabel.Text = "Description";
            Layout.Add(DescriptionLabel);
            DescriptionLabelBox = (BoxChild)Layout[DescriptionLabel];
            DescriptionLabelBox.Expand = false;
            DescriptionLabelBox.Fill = false;

            DescriptionError = new Label();
            Layout.Add(DescriptionError);
            DescriptionErrorBox = (BoxChild)Layout[DescriptionError];
            DescriptionErrorBox.Expand = false;
            DescriptionErrorBox.Fill = false;

            DescriptionScroll = new ScrolledWindow();
            Layout.Add(DescriptionScroll);
            DescriptionScrollBox = (BoxChild)Layout[DescriptionScroll];
            DescriptionScrollBox.Expand = true;
            DescriptionScrollBox.Fill = true;
            Description = new TextView();
            Description.WrapMode = WrapMode.Char;
            DescriptionScroll.Add(Description);

            Submit = new Button();
            Submit.Label = "Save";
            Layout.Add(Submit);
            SubmitBox = (BoxChild)Layout[Submit];
            SubmitBox.Expand = false;
            SubmitBox.Fill = false;

            Add(Layout);
            Child.ShowAll();

            Submit.Clicked += new EventHandler(OnSubmitClick);
        }

        private void OnSubmitClick(object obj, EventArgs args)
        {
            Model.Subject = Subject.Text;
            Model.Description = Description.Buffer.Text;

            Model.Validate();

            if (Model.Errors.ContainsKey("Subject"))
            {
                SubjectError.Text = Model.Errors["Subject"];
                SubjectError.Visible = true;
            }
            else
            {
                SubjectError.Visible = false;
            }

            if (Model.Errors.ContainsKey("Description"))
            {
                DescriptionError.Text = Model.Errors["Description"];
                DescriptionError.Visible = true;
            }
            else
            {
                DescriptionError.Visible = false;
            }

            if (!Model.Errors.Any())
            {
                Destroy();
            }
        }
    }
}
