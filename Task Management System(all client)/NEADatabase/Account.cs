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
using System.Security.Cryptography;


namespace NEADatabase
{
    public partial class Account : Form
    {

        public string USER;
        public string CONNECTION_STRING= @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = UserDatabase.mdb;";
        public string username;
        public int UserID;
        SQL Query = new SQL();

        public void ExecuteSqlDisplay(String sSqlString)
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

                            DisplayData(dt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
        private List<int> TasksDone()
        {
            string sSqlstring = $"SELECT TaskID FROM Task_Completed WHERE EXISTS (SELECT TaskID FROM Task_Completed WHERE UserID={this.UserID})";
            var reader = Query.ExecuteSqlReturn(sSqlstring);

            List<int> TasksCompleted = new List<int>();

            while (reader.Read())
            {
                TasksCompleted.Add(Convert.ToInt32(reader[0]));
            }

            return TasksCompleted;
        } 

        private bool IsTaskCompleted(int TaskID)
        {
            List<int> TasksCompleted = new List<int>();
            TasksCompleted = TasksDone();
            if (TasksCompleted.Contains(TaskID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DisplayTask(int TaskID)
        {
            string sSqlString = $"Select * FROM TaskID WHERE TaskID={TaskID};";
            ExecuteSqlDisplay(sSqlString);
        }

        private List<int> PersonalTasks()
        {
            string sSqlstring = $"SELECT TaskID FROM HasTaskID WHERE UserID={UserID}";
            var reader = Query.ExecuteSqlReturn(sSqlstring);

            List<int> TempIndividualTasks = new List<int>();

            while (reader.Read())
            {
                TempIndividualTasks.Add(Convert.ToInt32(reader[0]));
            }

            List<int> IndividualTasks = new List<int>();
            List<int> GroupTasks = new List<int>();
            GroupTasks = TasksFromGroups();

            foreach (int Task in TempIndividualTasks)
            {
                if (!GroupTasks.Contains(Task))
                {
                    IndividualTasks.Add(Task);
                }
            }

            return IndividualTasks;
        }

        private List<int> TasksFromGroups()
        {
            string sSqlString = $"SELECT TaskID FROM Task_Groups INNER JOIN User_Groups ON Task_Groups.GroupID = User_Groups.GroupID WHERE UserID={UserID}";
            var reader = Query.ExecuteSqlReturn(sSqlString);

            List<int> GroupTasks = new List<int>();

            while (reader.Read())
            {
                GroupTasks.Add(Convert.ToInt32(reader[0]));
            }

            return GroupTasks;

        }
        private void LoadTasks()
        {
            List<int> GroupTasks = new List<int>();
            GroupTasks = TasksFromGroups();

            List<int> IndividualTasks = new List<int>();
            IndividualTasks = PersonalTasks();

            foreach (int GroupTask in GroupTasks)
            {
                if (!IsTaskCompleted(GroupTask))
                {
                    DisplayTask(GroupTask);
                }
            }

            foreach (int IndividualTask in IndividualTasks)
            {
                if (!IsTaskCompleted(IndividualTask))
                {
                    DisplayTask(IndividualTask);
                }
            }

        }

        private void SetupGrid()
        {
            // Define number of columns and set headers
            dgvTasks.ColumnCount = 6;
            dgvTasks.Columns[0].Name = "TaskID";
            dgvTasks.Columns[1].Name = "Title";
            dgvTasks.Columns[2].Name = "Date Due";
            dgvTasks.Columns[3].Name = "Date Set";
            dgvTasks.Columns[4].Name = "Priority";
            dgvTasks.Columns[5].Name = "Description";
            dgvTasks.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTasks.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void DisplayData(DataTable _dt)
        {

            // Loop around each row in the data retrieved from the query
            for (int i = 0; i <= _dt.Rows.Count - 1; i++)
            {
                // Add a new row to the grid
                int n = dgvTasks.Rows.Add();

                // Add fields to each row, if string fields are null, add blank
                dgvTasks.Rows[n].Cells[0].Value = _dt.Rows[i][0];
                dgvTasks.Rows[n].Cells[1].Value = _dt.Rows[i][1];
                dgvTasks.Rows[n].Cells[2].Value = (string)_dt.Rows[i][4].ToString();
                dgvTasks.Rows[n].Cells[2].Value = Convert.ToDateTime((string)_dt.Rows[i][4].ToString()).ToString("d");
                dgvTasks.Rows[n].Cells[3].Value = (string)_dt.Rows[i][5].ToString();
                dgvTasks.Rows[n].Cells[3].Value = Convert.ToDateTime((string)_dt.Rows[i][5].ToString()).ToString("d");
                dgvTasks.Rows[n].Cells[4].Value = String.IsNullOrEmpty((string)_dt.Rows[i][4].ToString()) ? "" : _dt.Rows[i][2];
                dgvTasks.Rows[n].Cells[5].Value = String.IsNullOrEmpty((string)_dt.Rows[i][5].ToString()) ? "" : _dt.Rows[i][3];
                

            }
        }
        public Account(string username)
        {
            InitializeComponent();
            this.username = username;
            this.UserID = GetUserID();
        }

        private int GetUserID()
        {
            string _sSqlString = $"SELECT UserID FROM UserID WHERE Name='{this.username}'";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if(reader.Read())
            {
                int ID = (int)reader[0];
                return ID;  
            }
            else
            {
                return 0;
            }
        }

        private void Account_Load(object sender, EventArgs e)
        {
            dgvTasks.Rows.Clear();

            SetupGrid();

            LoadTasks();
        }

        private void rdoDate_CheckedChanged(object sender, EventArgs e)
        {

            dgvTasks.Sort(dgvTasks.Columns[2], ListSortDirection.Ascending);
        }

        private void rdoPriority_CheckedChanged(object sender, EventArgs e)
        {
            dgvTasks.Sort(dgvTasks.Columns[4], ListSortDirection.Ascending);
        }

        private void btnSetTask_Click(object sender, EventArgs e)
        {
            var AddTask = new AddTask(UserID);
            AddTask.Show();
        }

        private void rdoDateSet_CheckedChanged(object sender, EventArgs e)
        {

            dgvTasks.Sort(dgvTasks.Columns[3], ListSortDirection.Descending);
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {

            var CreateGroup = new CreateGroup(UserID);
            CreateGroup.Show();
            Console.WriteLine(this.username);
        }

        private bool HasBeenSet(int TaskID)
        {
            List<int> GroupTasks = new List<int>();
            List<int> IndividualTasks = new List<int>();

            GroupTasks = TasksFromGroups();
            IndividualTasks = PersonalTasks();

            if((GroupTasks.Contains(TaskID)) || (IndividualTasks.Contains(TaskID)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CompleteTask()
        {
            try
            {
                int CompletedTaskID = Convert.ToInt32(txtCmpltdTaskID.Text);

                if (HasBeenSet(CompletedTaskID) == true)
                {
                    string _sSqlString = "INSERT INTO Task_Completed(TaskID, UserID) " + "Values('" + CompletedTaskID + "', '" + UserID + "')";

                    Query.ExecuteSql(_sSqlString);

                    MessageBox.Show("Task Completed!");

                    dgvTasks.Rows.Clear();

                    LoadTasks();
                }
                else
                {
                    MessageBox.Show("You haven't been set this task!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
        private void btnCmpltTask_Click(object sender, EventArgs e)
        {
            CompleteTask();
        }

        private void cmboOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderBy = cmboOrderBy.Items[cmboOrderBy.SelectedIndex].ToString();
        }

        private void cmboAscDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AscDesc = cmboAscDesc.Items[cmboAscDesc.SelectedIndex].ToString();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {

        }


        private int[] quicksort(int[] Tasks)
        {


        private void GetTasks()
        {
            List<int> GroupTasks = new List<int>();
            GroupTasks = TasksFromGroups();

            List<int> IndividualTasks = new List<int>();
            IndividualTasks = PersonalTasks();

            foreach (int GroupTask in GroupTasks)
            {
                if (!IsTaskCompleted(GroupTask))
                {
                    DisplayTask(GroupTask);
                }
            }

            foreach (int IndividualTask in IndividualTasks)
            {
                if (!IsTaskCompleted(IndividualTask))
                {
                    DisplayTask(IndividualTask);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void dgvTasks_CellContentClick(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void monthCalendar1_DateChanged(object sender, EventArgs e)
        {

        }
        private void txtCmpltdTaskID_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtGroups_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
