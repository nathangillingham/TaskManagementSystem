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
        public void ExecuteSql(String sSqlString)
        {

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                using (OleDbCommand command = new OleDbCommand(sSqlString))
                {

                    command.Connection = connection;


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
           

            string sName = UsernameText.Text;
            string sPassword = Encryptor.Hash(PasswordText.Text);

            User user1 = new User(sName);

            string _sSqlString = $"SELECT HashValue FROM UserID WHERE Name='{sName}'";

            var reader = new Form1().ExecuteQuerySql(_sSqlString);


            // If value can't be found then deal with exception - remove throw or wrap in try catch
            if (!reader.Read())
                throw new ArgumentException("Value couldn't be found");

            // Get value from reader and store
            string result = reader[0].ToString();

            // Compare value to sPassword
            if (result == sPassword)
            {
                var Account = new Account(sName);
                Account.Show();
            }

            // reader.Close(); <- try this

        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            // Closes the current form
            this.Close();
        }
        
    }
}
