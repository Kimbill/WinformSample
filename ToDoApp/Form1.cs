namespace ToDoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm();
            userForm.ShowDialog();

            this.Hide();
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            //TODO: Add a score form
        }
    }
}