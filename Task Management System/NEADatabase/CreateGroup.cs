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
    public partial class CreateGroup : Form
    {
        public string USER;
        public string CONNECTION_STRING;
        public string currentUsername;

        public CreateGroup(string currentUsername)
        {
            this.currentUsername = currentUsername;

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

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private int GetGroupID(string gName)
        {
            string _sSqlString4 = $"SELECT GroupID FROM GroupID WHERE GroupName='{gName}'";

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

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string sName = txtGroupName.Text;

            string _sSqlString = "INSERT INTO GroupID(GroupName, Owner) " + $"Values('{sName}', '{this.currentUsername}')";

            ExecuteSql(_sSqlString);




            string TempM = txtMembers.Text;
            string[] Members = TempM.Split(',');
            int GroupID = GetGroupID(sName);
            if (GroupID != 0)
            {
                foreach (string Member in Members)
                {

                    try
                    {
                        Member.Trim();

                        int MemberID = Convert.ToInt32(Member);

                        string _sSqlString2 = "INSERT INTO User_Groups(GroupID, UserID) " + "Values('" + GroupID + "', '" + MemberID + "')";

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

        private void txtMembers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
