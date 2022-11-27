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
    public partial class Form1 : Form
    {

        public string USER;
        public string CONNECTION_STRING;

        public Form1()
        {

            InitializeComponent();
            USER = "UserDatabase.mdb";
            CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = " + USER + ";";
        }

        public void button1_Click(object sender, EventArgs e)
        {

            CatalogClass cat = new CatalogClass();

            if (!File.Exists(USER))
            {
                cat.Create(CONNECTION_STRING);
                MessageBox.Show("Database Created!");

            }
            else
            {
                MessageBox.Show("The database already exists", "Database Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cat = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            CreateTables();

        }

        private void CreateTables()
        {
            try
            {
                string _sSqlString;
                string _sSqlString2;
                string _sSqlString3;
                string _sSqlString4;
                string _sSqlString5;
                string _sSqlString6;
                string _sSqlString7;

                SQL Query = new SQL();

                _sSqlString = "CREATE TABLE UserID("
                                                + "UserID INT IDENTITY(1,1),"
                                                + "Name VARCHAR(30) UNIQUE,"
                                                + "Heirarchy NUMERIC(2),"
                                                + "HashValue VARCHAR(60),"
                                                + "PRIMARY KEY(UserID)"
                                                + ")";
                Query.ExecuteSql(_sSqlString);

                _sSqlString2 = "CREATE TABLE TaskID("
                                                + "TaskID INT IDENTITY(1,1),"
                                                + "Title VARCHAR(30) UNIQUE,"
                                                + "Priority NUMERIC(2),"
                                                + "Description VARCHAR(60),"
                                                + "DateDue DATE,"
                                                + "DateSet DATE,"
                                                + "PRIMARY KEY(TaskID)"
                                                + ")";
                Query.ExecuteSql(_sSqlString2);

                _sSqlString3 = "CREATE TABLE GroupID("
                                                + "GroupID INT IDENTITY(1,1),"
                                                + "GroupName CHAR(30) UNIQUE,"
                                                + "OwnerID INT,"
                                                + "PRIMARY KEY(GroupID),"
                                                + "CONSTRAINT OwnerID FOREIGN KEY (OwnerID) REFERENCES UserID (UserID)"
                                                + ")";

                Query.ExecuteSql(_sSqlString3)
    ;

                _sSqlString4 = "CREATE TABLE HasTaskID("
                                                + "UserID INT,"
                                                + "TaskID INT,"
                                                + "CONSTRAINT FKUser FOREIGN KEY (UserID) REFERENCES UserID (UserID),"
                                                + "CONSTRAINT FKTask FOREIGN KEY (TaskID) REFERENCES TaskID (TaskID),"
                                                + "PRIMARY KEY(UserID,TaskID)"
                                                + ")";
                Query.ExecuteSql(_sSqlString4);

                _sSqlString5 = "CREATE TABLE User_Groups("
                                                + "GroupID INT,"
                                                + "UserID INT,"
                                                + "CONSTRAINT UserID FOREIGN KEY (UserID) REFERENCES UserID (UserID),"
                                                + "CONSTRAINT GroupID FOREIGN KEY (GroupID) REFERENCES GroupID (GroupID),"
                                                + "PRIMARY KEY(UserID,GroupID)"
                                                + ")";

                Query.ExecuteSql(_sSqlString5);

                _sSqlString6 = "CREATE TABLE Task_Groups("
                                                + "GroupID INT,"
                                                + "TaskID INT,"
                                                + "CONSTRAINT TaskID FOREIGN KEY (TaskID) REFERENCES TaskID (TaskID),"
                                                + "CONSTRAINT FK_Group FOREIGN KEY (GroupID) REFERENCES GroupID (GroupID),"
                                                + "PRIMARY KEY(TaskID,GroupID)"
                                                + ")";

                Query.ExecuteSql(_sSqlString6);

                _sSqlString7 = "CREATE TABLE Task_Completed("
                                               + "TaskID INT,"
                                               + "UserID INT,"
                                               + "CONSTRAINT FK_User FOREIGN KEY (UserID) REFERENCES UserID (UserID),"
                                               + "CONSTRAINT FK_Task FOREIGN KEY (TaskID) REFERENCES TaskID (TaskID),"
                                               + "PRIMARY KEY(UserID,TaskID)"
                                               + ")";

                Query.ExecuteSql(_sSqlString7);

                MessageBox.Show("Tables Created!");

            }
            catch
            {
                MessageBox.Show("Error!");
            }

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
