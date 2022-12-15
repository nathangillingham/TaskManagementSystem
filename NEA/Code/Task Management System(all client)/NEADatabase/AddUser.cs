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

        /// <summary>
        /// creates new user in the UserID table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidInput())
            {
                string sName = UserNametxt.Text;
                int sHeirarchy = Convert.ToInt32(Heirarchy.Text);
                string sPassword = Encryptor.Hash(Passwordtxt.Text);

                string _sSqlString = "INSERT INTO UserID(Name, Hierarchy, HashValue) " + "Values('" + sName + "', '" + sHeirarchy + "', '" + sPassword + "')";

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

        }


        /// <summary>
        /// Determines whether input exists, annd if it is of the correct data type
        /// </summary>
        /// <returns></returns>
        private bool ValidInput()
        {
            string sName = UserNametxt.Text;
            string sHeirarchy = Heirarchy.Text;

            if((sName.Length > 0) && (sHeirarchy.Length) > 0 && (Passwordtxt.Text.Length) > 0)
            {
                try
                {
                    int Heirarchy = int.Parse(sHeirarchy);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Input integer Hierarchy!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Input valid info!");
                return false;
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
