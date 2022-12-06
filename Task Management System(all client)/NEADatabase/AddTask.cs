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
        public int UserID;
        SQL Query = new SQL();
        public AddTask(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }
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
                return Convert.ToInt32(reader[0]);

            }


        }

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
            string _sSqlString = $"SELECT Heirarchy FROM UserID WHERE UserID={UserID}";
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
                        int TargetID = Convert.ToInt32(User);
                        if(CanSetTask(UserID,TargetID))
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

        private void txtGroups_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
