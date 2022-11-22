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
    public partial class AddTask : Form
    {

        public string USER;
        public string CONNECTION_STRING;
        public AddTask()
        {
            InitializeComponent();
            USER = "UserDatabase.mdb";
            CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = " + USER + ";";

        }

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

        private int GetTaskID(string tName)
        {
            string _sSqlString4 = $"SELECT TaskID FROM TaskID WHERE Title='{tName}'";

            var reader = new Form1().ExecuteQuerySql(_sSqlString4);

            if (!reader.Read())
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(reader[0]);

            }


        }

        private void btnSetTask_Click(object sender, EventArgs e)
        {
            string Title = txtTitle.Text;
            string user = txtUser.Text;
            int Priority = int.Parse(txtPriority.Text);
            string Desc = txtDescription.Text;
            DateTime dateTimeDue = dateTimePicker.Value;
            DateTime dateTimeSet = DateTime.Now;

            string _sSqlString = "INSERT INTO TaskID(Title, Priority, Description, DateDue, DateSet) " + "Values('" + Title + "', '" + Priority + "', '" + Desc + "', '" + dateTimeDue + "', '" + dateTimeSet + "')";

            ExecuteSql(_sSqlString);

            string TempG = txtGroups.Text;
            string[] Groups = TempG.Split(',');
            int TaskID = GetTaskID(Title);
            if (TaskID != 0)
            {
                foreach (string Group in Groups)
                {

                    try
                    {
                        Group.Trim();

                        int GroupID = Convert.ToInt32(Group);

                        string _sSqlString2 = "INSERT INTO Task_Groups(GroupID, TaskID) " + "Values('" + GroupID + "', '" + TaskID + "')";

                        ExecuteSql(_sSqlString2);
                    }
                    catch
                    {

                    }

                }
            }
            else
            {

            }



        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGroups_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
