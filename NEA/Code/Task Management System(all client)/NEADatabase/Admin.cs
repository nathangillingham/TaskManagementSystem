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
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace NEADatabase
{
    public partial class Admin : Form
    {

        public string USER;
        public string CONNECTION_STRING;

        public Admin()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var AddUser = new AddUser();
            AddUser.Show();

        }

        private void Login_Click(object sender, EventArgs e)
        {
            var Login = new Login();
            Login.Show();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
