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
        public string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = UserDatabase.mdb;";
        public int UserID;
        SQL Query = new SQL();

        public CreateGroup(int UserID)
        {
            this.UserID = UserID;

            InitializeComponent();
        }

        public void ExecuteSqlDisplay(String sSqlString, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                using (OleDbCommand command = new OleDbCommand(sSqlString))
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                    {
                        command.Connection = connection;

                        try
                        {
                            connection.Open();
                            dataAdapter.Fill(dt);

                            DisplayData(dt, dgv);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private void SetupGroupGrid()
        {
            dgvOwnedGroups.ColumnCount = 2;
            dgvOwnedGroups.Columns[0].Name = "GroupID";
            dgvOwnedGroups.Columns[1].Name = "Group Name";
        }

        private void SetupUserGrid()
        {
            // Define number of columns and set headers
            dgvUsersInGroup.ColumnCount = 3;
            dgvUsersInGroup.Columns[0].Name = "UserID";
            dgvUsersInGroup.Columns[1].Name = "Name";
            dgvUsersInGroup.Columns[2].Name = "Hierarchy";
        }

        private void SetupTaskGrid()
        {
            // Define number of columns and set headers
            dgvTasksInGroup.ColumnCount = 6;
            dgvTasksInGroup.Columns[0].Name = "TaskID";
            dgvTasksInGroup.Columns[1].Name = "Title";
            dgvTasksInGroup.Columns[4].Name = "Date Due";
            dgvTasksInGroup.Columns[5].Name = "Date Set";
            dgvTasksInGroup.Columns[2].Name = "Priority";
            dgvTasksInGroup.Columns[3].Name = "Description";
            dgvTasksInGroup.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTasksInGroup.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        /// <summary>
        /// Modified version of display data which doesnt need to know the type or size of the incoming data to display it
        /// </summary>
        /// <param name="_dt"></param>
        /// <param name="dgv"></param>
        private void DisplayData(DataTable _dt, DataGridView dgv)
        {
            for (int i = 0; i <= _dt.Rows.Count - 1; i++)
            {
                int n = dgv.Rows.Add();

                for (int j = 0; j <= dgv.Columns.Count - 1; j++)
                {
                    try
                    {
                        dgv.Rows[n].Cells[j].Value = _dt.Rows[i][j];
                    }
                    catch
                    {
                        dgv.Rows[n].Cells[j].Value = (string)_dt.Rows[i][j].ToString();
                        dgv.Rows[n].Cells[j].Value = Convert.ToDateTime((string)_dt.Rows[i][j].ToString()).ToString("d");
                    }
                }

            }
        }

        private int GetGroupID(string GroupName)
        {
            string _sSqlString = $"SELECT GroupID FROM GroupID WHERE GroupName='{GroupName}'";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if(reader.Read())
            {
                return (int)reader[0];
            }
            else
            {
                return 0;
            }

        }

        private int GetGroupOwnerID(int GroupID)
        {
            string _sSqlString = $"SELECT OwnerID FROM GroupID WHERE GroupID={GroupID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if (reader.Read())
            {
                return (int)reader[0];
            }
            else
            {
                return 0;
            }

        }

        private int GetHierarchy(int UserID)
        {
            string _sSqlString = $"SELECT Hierarchy FROM UserID WHERE UserID={UserID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if (reader.Read())
            {
                return int.Parse(reader[0].ToString());
            }
            else
            {
                return 0;
            }

        }

        private bool CanAddToGroup(int UserID, int TargetID)
        {
            int UserHierarchy = GetHierarchy(UserID);
            int TargetHierarchy = GetHierarchy(TargetID);

            if ((UserHierarchy != 0) && (TargetHierarchy != 0))
            {
                if (UserHierarchy <= TargetHierarchy)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        /// <summary>
        /// Creates new group entry in GroupID using current userID as OwnerID
        /// </summary>
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

        private void AddTaskGroup(int GroupID, int TaskID)
        {
            string _sSqlString = "INSERT INTO Task_Groups(GroupID, TaskID) " + "Values('" + GroupID + "', '" + TaskID + "')";
            try
            {
                Query.ExecuteSql(_sSqlString);
            }
            catch
            {
                MessageBox.Show("Values Inputted are incorrect!");
            }
        }

        /// <summary>
        /// String Handling to seperate each user into different index
        /// </summary>
        /// <param name="Member"></param>
        /// <returns></returns>
        private int TrimUserID(string Member)
        {
            try
            {
                Member.Trim();
                int MemberID = Convert.ToInt32(Member);

                return MemberID;
            }
            catch
            {
                return 0;
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
                    int MemberID = TrimUserID(Member);
                    if (CanAddToGroup(this.UserID,MemberID ))
                    {

                        AddUserGroup(GroupID, MemberID);

                    }
                    else
                    {
                        MessageBox.Show("Some users couldn’t be added");
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

        public void DisplayOwnedGroups()
        {
            string _sSqlString = $"SELECT * FROM GroupID WHERE OwnerID={this.UserID}";
            ExecuteSqlDisplay(_sSqlString, dgvOwnedGroups);

        }

        public void DisplayGroupUsers(int GroupID)
        {
            string _sSqlString = $"SELECT UserID.UserID,Name,Hierarchy FROM UserID INNER JOIN User_Groups ON UserID.UserID = User_Groups.UserID WHERE GroupID={GroupID}";
            ExecuteSqlDisplay(_sSqlString, dgvUsersInGroup);
        }

        public void DisplayGroupTasks(int GroupID)
        {
            string sSqlString = $"SELECT * FROM TaskID INNER JOIN Task_Groups ON TaskID.TaskID = Task_Groups.TaskID WHERE GroupID={GroupID}";
            ExecuteSqlDisplay(sSqlString, dgvTasksInGroup);
        }

        //aggregate function
        public int CountGroupTasks(int GroupID)
        {
            string sSqlString = $"SELECT COUNT(TaskID.TaskID) FROM TaskID INNER JOIN Task_Groups ON TaskID.TaskID = Task_Groups.TaskID WHERE GroupID={GroupID}";
            var reader = Query.ExecuteSqlReturn(sSqlString);
            if (!reader.Read())
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(reader[0]);
            }
        }

        //aggregate function
        public int CountGroupUsers(int GroupID)
        {
            string sSqlString = $"SELECT COUNT(UserID.UserID) FROM UserID INNER JOIN User_Groups ON UserID.UserID = User_Groups.UserID WHERE GroupID={GroupID}";
            var reader = Query.ExecuteSqlReturn(sSqlString);
            if (!reader.Read())
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(reader[0]);
            }
        }


        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CreateGroup_Load(object sender, EventArgs e)
        {
            dgvOwnedGroups.Rows.Clear();

            SetupGroupGrid();

            DisplayOwnedGroups();   
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMembers_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Displays the properties of the selcted group, the tasks and users that belong to it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayGroupProps_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupID = Convert.ToInt32(txtGroupID.Text);
                SetupUserGrid();
                SetupTaskGrid();
                if (UserID == GetGroupOwnerID(GroupID))
                {
                    DisplayGroupUsers(GroupID);
                    DisplayGroupTasks(GroupID);
                    valuetasksingroups.Text = CountGroupTasks(GroupID).ToString();
                    valueusersingroups.Text = CountGroupUsers(GroupID).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Input GroupID!");
            }
        }

        private void txtGroupID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupID = Convert.ToInt32(txtGroupID2.Text);
                int TaskID = Convert.ToInt32(txtTaskID.Text);
                if(UserID == GetGroupOwnerID(GroupID))
                {
                    AddTaskGroup(GroupID, TaskID);
                    MessageBox.Show("Task Added!");
                }
                else
                {
                    MessageBox.Show("You do not own this group!");
                }
            }
            catch
            {
                MessageBox.Show("Input Valid GroupID and TaskID!");
            }
        }

        private void txtGroupID2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaskID_TextChanged(object sender, EventArgs e)
        {

        }

        private void valueusersingroups_Click(object sender, EventArgs e)
        {

        }

        private void valuetasksingroups_Click(object sender, EventArgs e)
        {

        }
    }
}
