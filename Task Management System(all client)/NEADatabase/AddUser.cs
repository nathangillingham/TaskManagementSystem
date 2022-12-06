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
        SQL Query = new SQL();
 
        public AddUser()
        {
            InitializeComponent();
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
            string sName = UserNametxt.Text;
            string sHeirarchy = Heirarchy.Text;
            string sPassword = Encryptor.Hash(Passwordtxt.Text);

            string _sSqlString = "INSERT INTO UserID(Name, Heirarchy, HashValue) " + "Values('" + sName + "', '" + sHeirarchy + "', '" + sPassword + "')";

            try
            {
                Query.ExecuteSql(_sSqlString);
                MessageBox.Show("User Created!");
            }
            catch
            {
                MessageBox.Show("Error!");
            }



        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
