using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using ADOX;
using System.Drawing.Text;
using System.Security.Cryptography;

namespace NEADatabase
{
    public partial class Login : Form
    {
        public string USER;
        public string CONNECTION_STRING;
        SQL Query = new SQL();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private string GetHash(string Username)
        {
            string _sSqlString = $"SELECT HashValue FROM UserID WHERE Name='{Username}'";

            var reader = Query.ExecuteSqlReturn(_sSqlString);

            string Hash = "null";

            while (reader.Read())
            {
                Hash = (String)reader[0];
            }

            return Hash;
        }

        private void LoginAttempt()
        {
            string Username = UsernameText.Text;
            string Password = Encryptor.Hash(PasswordText.Text);
            string Hash = GetHash(Username); 

            if ((Hash == Password) && (Hash != "null"))
            {
                if (Username == "Admin")
                {
                    var Admin = new Admin();
                    Admin.Show();
                }
                else
                {
                    var Account = new Account(Username);
                    Account.Show();
                    MessageBox.Show("Login Successful!");
                }
            }
            else if (Hash == "null")
            {
                MessageBox.Show("Username not found!");
            }
            else if ((Hash != Password) && (Hash != "null"))
            {
                MessageBox.Show("Username and Password do not match!");
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginAttempt();
          
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
