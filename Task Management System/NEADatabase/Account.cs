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
        public string CONNECTION_STRING;
        public string username;
        public int UserID;

        private List<int> TasksDone()
        {
            string sSqlstring = $"SELECT TaskID FROM Task_Completed WHERE EXISTS (SELECT TaskID FROM Task_Completed WHERE UserID={this.UserID})";
            var reader = new Form1().ExecuteQuerySql(sSqlstring);

            List<int> TasksCompleted = new List<int>();

            while (reader.Read())
            {
                TasksCompleted.Add(Convert.ToInt32(reader[0]));
                Console.WriteLine("completed task ");
                Console.WriteLine(reader[0].ToString());
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
            ExecuteSql(sSqlString);
        }

        private List<int> PersonalTasks()
        {
            string sSqlstring = $"SELECT TaskID FROM HasTaskID WHERE UserID={UserID}";
            var reader = new Form1().ExecuteQuerySql(sSqlstring);

            List<int> TempIndividualTasks = new List<int>();

            while (reader.Read())
            {
                TempIndividualTasks.Add(Convert.ToInt32(reader[0]));
                Console.WriteLine("IndividualTasks ");
                Console.WriteLine(reader[0].ToString());
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
            var reader = new Form1().ExecuteQuerySql(sSqlString);

            List<int> GroupTasks = new List<int>();

            while (reader.Read())
            {
                GroupTasks.Add(Convert.ToInt32(reader[0]));
                Console.WriteLine("GroupTasks ");
                Console.WriteLine(reader[0].ToString());
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

        public void ExecuteSql(String sSqlString)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING)) // Create a new connection to the database
            {
                // The sSqlString string contains a SQL statement to run on the database
                using (OleDbCommand command = new OleDbCommand(sSqlString))
                {
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                    {
                        // Set the Connection to the new OleDbConnection.
                        command.Connection = connection;

                        // Open the connection and execute the command.
                        try
                        {
                            connection.Open();
                            dataAdapter.Fill(dt);

                            // Display the data retrieved by the query
                            DisplayData(dt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                } // The command is automatically closed when the code exits the using block.
            } // The connection is automatically closed when the code exits the using block.
        }
        public Account(string Username)
        {
            InitializeComponent();
            USER = "UserDatabase.mdb";
            CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = " + USER + ";";
            username = Username;

            string _sSqlString = $"SELECT UserID FROM UserID WHERE Name='{Username}'";
            var reader = new Form1().ExecuteQuerySql(_sSqlString);
            while (reader.Read())
            {
                UserID = (int)reader[0];
                // use vlads slq function to compare heirarchy of user setting task, and user being set, to validate - lol :)
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Account_Load(object sender, EventArgs e)
        {
            dgvTasks.Rows.Clear();

            SetupGrid();

            LoadTasks();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void rdoDate_CheckedChanged(object sender, EventArgs e)
        {

            dgvTasks.Sort(dgvTasks.Columns[2], ListSortDirection.Ascending);
        }

        private void rdoPriority_CheckedChanged(object sender, EventArgs e)
        {
            dgvTasks.Sort(dgvTasks.Columns[4], ListSortDirection.Descending);
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

        private void txtCmpltdTaskID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCmpltTask_Click(object sender, EventArgs e)
        {

            int CompletedTaskID = Convert.ToInt32(txtCmpltdTaskID.Text);

            string _sSqlString = "INSERT INTO Task_Completed(TaskID, UserID) " + "Values('" + CompletedTaskID + "', '" + UserID + "')";

            ExecuteSql(_sSqlString);

            dgvTasks.Rows.Clear();

            LoadTasks();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
