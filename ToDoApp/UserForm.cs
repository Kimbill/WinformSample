using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApp
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //var userForm = new UserForm();
            var id = this.txtID.Text;
            var name = this.txtName.Text;
            var email = this.txtEmail.Text;

            //do validations for the text boxes here

            var sql = @$" 
                        INSERT INTO DotNetUser (ID, Name, Email)
                        VALUES({id}, '{name}', '{email}' )
                        ";

            //DbClient dbClient = new DbClient();
            var result = DbClient.ExecuteQuery(sql);
            if (result)
                MessageBox.Show("User Added");
        }

        private void LoadData()
        {
            var sql = @"SELECT = FROM DotNetUser";
            var users = new List<string>();
            
            var data = DbClient.ReadData(sql);

            if (data.HasRows)
            {
                users.Add($"{data["ID"]}, {data["Name"]}, {data["IEmailD"]} ");
                MessageBox.Show(users.ToString());
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }
    }
}
