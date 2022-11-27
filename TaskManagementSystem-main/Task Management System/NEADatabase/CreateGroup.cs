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
        public int UserID;
        SQL Query = new SQL();

        public CreateGroup(int UserID)
        {
            this.UserID = UserID;

            InitializeComponent();
        }

        private int GetGroupID(string GroupName)
        {
            string _sSqlString = $"SELECT GroupID FROM GroupID WHERE GroupName='{GroupName}'";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            int GroupID = 0;

            while(reader.Read())
            {
                GroupID = (int)reader[0];
            }

            return GroupID;

        }

        private void AddUserGroup(int GroupID, int MemberID)
        {
            string _sSqlString = "INSERT INTO User_Groups(GroupID, UserID) " + "Values('" + GroupID + "', '" + MemberID + "')";

            try
            {
                Query.ExecuteSql(_sSqlString);
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
        private void AddGroup()
        {
            string GroupName = txtGroupName.Text;

            string _sSqlString = "INSERT INTO GroupID(GroupName, OwnerID) " + $"Values('{GroupName}', '{this.UserID}')";

            try
            {
                Query.ExecuteSql(_sSqlString);
                MessageBox.Show("Group created!");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void AddUsers()
        {
            string TempM = txtMembers.Text;
            string[] Members = TempM.Split(',');
            int GroupID = GetGroupID(txtGroupName.Text);
            if (GroupID != 0)
            {
                foreach (string Member in Members)
                {

                    try
                    {
                        Member.Trim();
                        int MemberID = Convert.ToInt32(Member);

                        AddUserGroup(GroupID, MemberID);
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
        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            AddGroup();

            AddUsers();

        }
        private void CreateGroup_Load(object sender, EventArgs e)
        {

        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMembers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
