using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEADatabase
{
    public partial class InitializeAdmin : Form
    {

        public string USER;
        public string CONNECTION_STRING;
        SQL Query = new SQL();

        public InitializeAdmin()
        {
            InitializeComponent();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Text;
                AddUser(password);
            }
            catch
            {
                MessageBox.Show("Enter Password!");
            }
        }

        /// <summary>
        /// Inserts new user as the admin, has the most permissions so always hierarchy of 1, username Admin always used, identified at login
        /// </summary>
        /// <param name="password"></param>
        private void AddUser(string password)
        {
            string sName = "Admin";
            int sHeirarchy = 1;
            string sPassword = Encryptor.Hash(password);

            string _sSqlString = "INSERT INTO UserID(Name, Hierarchy, HashValue) " + "Values('" + sName + "', '" + sHeirarchy + "', '" + sPassword + "')";

            if (password.Length > 0)
            {
                try
                {
                    Query.ExecuteSql(_sSqlString);
                    MessageBox.Show("Admin Created");
                    var Login = new Login();
                    this.Hide();
                    Login.Show();


                }
                catch
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                MessageBox.Show("Input valid password!");
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void InitializeAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
