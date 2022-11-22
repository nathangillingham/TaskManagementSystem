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
    public partial class AddUser : Form
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
        public AddUser()
        {

            InitializeComponent();
            USER = "UserDatabase.mdb";
            CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = " + USER + ";";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sName = UserName.Text;
            string sHeirarchy = Heirarchy.Text;
            string sPassword = Encryptor.Hash(Password.Text);

            string _sSqlString = "INSERT INTO UserID(Name, Heirarchy, HashValue) " + "Values('" + sName + "', '" + sHeirarchy + "', '" + sPassword + "')";

            ExecuteSql(_sSqlString);

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var AddUser = new AddUser();
            AddUser.Close();
        }
    }
}
