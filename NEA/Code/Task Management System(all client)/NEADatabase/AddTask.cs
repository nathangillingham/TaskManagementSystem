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
        public string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = UserDatabase.mdb;";
        public int UserID;
        SQL Query = new SQL();
        public AddTask(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        /// <summary>
        /// Returns the Id of the desired task based on its name, only one output as name is unique
        /// </summary>
        /// <param name="tName"></param>
        /// <returns></returns>
        private int GetTaskID(string tName)
        {

            string _sSqlString = $"SELECT TaskID FROM TaskID WHERE Title='{tName}'";

            var reader = Query.ExecuteSqlReturn(_sSqlString);

            if (!reader.Read())
            {
                return 0;
            }
            else
            {

                int tt = Convert.ToInt32(reader[0]);

                return tt;

            }


        }

        /// <summary>
        /// Creates an entry in the task table with input values, ignoring users and groups until after the entry is created
        /// </summary>
        private void SetTask()
        {
            string Title = txtTitle.Text;
            int Priority = int.Parse(txtPriority.Text);
            string Desc = txtDescription.Text;
            DateTime dateTimeDue = dateTimePicker.Value;
            DateTime dateTimeSet = DateTime.Now;

            string _sSqlString = "INSERT INTO TaskID(Title, Priority, Description, DateDue, DateSet) " + "Values('" + Title + "', '" + Priority + "', '" + Desc + "', '" + dateTimeDue + "', '" + dateTimeSet + "')";

            try
            {
                Query.ExecuteSql(_sSqlString);
                MessageBox.Show("Task Created!");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Returns the owner of the group based on the groupID
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        private int GetGroupOwner(int GroupID)
        {

            string _sSqlString = $"SELECT OwnerID FROM GroupID WHERE GroupID={GroupID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            int OwnerID = 0;
            while (reader.Read())
            {
                OwnerID = (int)reader[0];
            }

            return OwnerID;
        }

        private string GetGroupName(int GroupID)
        {
            string _sSqlString = $"SELECT GroupName FROM GroupID WHERE GroupID={GroupID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            string GroupName = "null";
            while (reader.Read())
            {
                GroupName = (reader[0].ToString());
            }
            return GroupName;
        }

        /// <summary>
        /// Creates the relationship betweeen a task and the group it is set to in the database
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="TaskID"></param>

        private void AddTaskGroup(int GroupID, int TaskID)
        {
            string _sSqlString2 = "INSERT INTO Task_Groups(GroupID, TaskID) " + "Values('" + GroupID + "', '" + TaskID + "')";
            try
            {
                Query.ExecuteSql(_sSqlString2);
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Checks whether each group is owned by the current user, and then calls the method to enter this in the database if true
        /// </summary>
        private void GroupTask()
        {
            string TempG = txtGroups.Text;
            string[] Groups = TempG.Split(',');
            int TaskID = GetTaskID(txtTitle.Text);
            if (ValidRecord(TaskID))
            {
                foreach (string Group in Groups)
                {

                    try
                    {
                        Group.Trim();
                        int GroupID = Convert.ToInt32(Group);
                        int OwnerID = GetGroupOwner(GroupID);

                        if (ValidRecord(OwnerID) && ValidRecord(GroupID))
                        {

                            if (OwnerID == UserID)
                            {
                                AddTaskGroup(GroupID, TaskID);
                            }
                            else
                            {
                                string GroupName = GetGroupName(GroupID);
                                if (GroupName == "null")
                                {
                                    MessageBox.Show($"A group entered has not been found");

                                }
                                else
                                {
                                    MessageBox.Show($"You are not the owner of \"{GroupName}\"");
                                }
                            }
                        }
                    }
                    catch
                    {

                    }


                }
            }
        }

        /// <summary>
        /// Checks if an Id exists, returns false if zero because IDs are indexed at one
        /// </summary>
        /// <param name="Record"></param>
        /// <returns></returns>
        private bool ValidRecord(int Record)
        {
            if(Record > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int GetHierarchy(int UserID)
        {
            string _sSqlString = $"SELECT Hierarchy FROM UserID WHERE UserID={UserID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if(reader.Read())
            {
                return int.Parse(reader[0].ToString());
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// Compares the hierarchies of two users two see if one has a greater access level than another
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="TargetID"></param>
        /// <returns></returns>
        private bool CanSetTask(int UserID, int TargetID)
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

        /// <summary>
        /// Creates relationship between a task and the user it is individually set to
        /// </summary>
        /// <param name="TargetID"></param>
        /// <param name="TaskID"></param>
        private void AddTaskUser(int TargetID, int TaskID)
        {
            string _sSqlString = "INSERT INTO HasTaskID(UserID, TaskID) " + "Values('" + TargetID + "', '" + TaskID + "')";

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
        /// Checks is the current user is able to set selected users tasks, then calls the function to create the relationship
        /// </summary>
        private void IndividualTask()
        {
            string Users = txtUser.Text;
            string[] UsersArray = Users.Split(',');
            int TaskID = GetTaskID(txtTitle.Text);
            if(ValidRecord(TaskID))
            {
                foreach (string User in UsersArray)
                {
                    try
                    {

                        User.Trim();
                        int TargetID = int.Parse(User);
                        if (CanSetTask(UserID,TargetID))
                        {
                            AddTaskUser(TargetID, TaskID);
                        }
                        else
                        {
                            MessageBox.Show($"You cannot set an entered user a task");
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }
        private void btnSetTask_Click(object sender, EventArgs e)
        {
            SetTask();

            GroupTask();

           IndividualTask();


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

        private void SetupUsersGrid()
        {
            dgvUsers.ColumnCount = 3;
            dgvUsers.Columns[0].Name = "UserID";
            dgvUsers.Columns[1].Name = "Name";
            dgvUsers.Columns[2].Name = "Hierarchy";
        }

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

        public void DisplayUsers()
        {
            string _sSqlString = $"SELECT UserID,Name,Hierarchy FROM UserID";
            ExecuteSqlDisplay(_sSqlString, dgvUsers);
        }


        private void txtGroups_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            dgvUsers.Rows.Clear();

            SetupUsersGrid();

            DisplayUsers();
        }
    }
}
