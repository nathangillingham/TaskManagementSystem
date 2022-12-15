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

        
        /// <summary>
        /// Establishes connection with database, uses result to display in particualr data grid view
        /// </summary>
        /// <param name="sSqlString"></param>

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

        /// <summary>
        /// Returns all tasks done using query based on the user logged i
        /// </summary>
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

        /// <summary>
        /// Checks if specific task is completed based on existance in TasksDone() returned array
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Uses SqlDisplay to show task to user if it has been assigned and not completed
        /// </summary>
        /// <param name="TaskID"></param>
        private void DisplayTask(int TaskID)
        {
            string sSqlString = $"Select * FROM TaskID WHERE TaskID={TaskID};";
            ExecuteSqlDisplay(sSqlString);
        }


        /// <summary>
        /// Returns all the tasks which have been assigned individually, not from a group, this prevents dusplication in displaying tasks
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the tasks which have been assigned to usre through a group
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Adds previous two functions, so that there is only one of each task in the set
        /// </summary>
        /// <returns></returns>
        private List<int> AllTasks()
        {
            List<int> GroupTasks = new List<int>();
            GroupTasks = TasksFromGroups();

            List<int> IndividualTasks = new List<int>();
            IndividualTasks = PersonalTasks();

            List<int> AllTasks = GroupTasks.Concat(IndividualTasks).ToList();

            return AllTasks;
        }

        /// <summary>
        /// Uses tasks which have been completed to identify which dont exist int eh completed set
        /// </summary>
        /// <returns></returns>
        private List<int> IncompleteTasks()
        {
            List<int> EveryTask = AllTasks();
            List<int> IncompleteTasks = new List<int>();

            foreach (int Task in EveryTask)
            {
                if (!IsTaskCompleted(Task))
                {
                    IncompleteTasks.Add(Task);
                }
            }

            return IncompleteTasks;

        }

        /// <summary>
        /// Displays all the incomplete tasks when the form is loaded
        /// </summary>
        private void LoadTasks()
        {
            List<int> Tasks = IncompleteTasks();

            foreach (int Task in Tasks)
            {
                DisplayTask(Task);
            }

        }

        /// <summary>
        /// Instantiates the fields of the data grid view, corresponding to each field in the TaskID table
        /// </summary>
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

        /// <summary>
        /// When a task, in the form of a datatable, is passed, it matched the field(eg TaskID) with the colum in the data grid view, and assigns the value
        /// </summary>
        /// <param name="_dt"></param>
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

        /// <summary>
        /// Sorts the data grid view by DateSet, DateDue, Priority
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Determines whether the user has ever been set a task, completed or not
        /// </summary>
        /// <param name="TaskID"></param>
        /// <returns></returns>
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



        /// <summary>
        /// Decides whether the input task is valid, and if so, creates a new entry in the task_completed table corresponding to the task and user
        /// </summary>
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
            Object selectedItem = cmboAscDesc.SelectedItem;
        }

        /// <summary>
        /// Writes tasks to file, based on ascending or descending the data structure used is decided
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string OrderBy = cmboOrderBy.SelectedItem.ToString();
                string AscDesc = cmboAscDesc.SelectedItem.ToString();

                DataStructure Tasks = AscDescFunction(AscDesc, Order(OrderBy));
                Tasks.SaveStructure();
            }
            catch
            {
                MessageBox.Show("Select Order and Sort condition!");
            }

        }


        /// <summary>
        /// Determines the factor the tassk should be sorted by, sorts them accordingly, and returns the list
        /// </summary>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        private List<int> Order(string OrderBy)
        {

            List<int> UnsortedTasks = IncompleteTasks();
            List<int> SortedTasks;

            if(OrderBy == null)
            {
                MessageBox.Show("Order By not selected!");
            }
            else if (OrderBy == "Date Due")
            {
                DateDueSort Sort = new DateDueSort();
                SortedTasks = Sort.SortList(UnsortedTasks, 0, UnsortedTasks.Count - 1);
                return SortedTasks;
            }
            else if (OrderBy == "Date Set")
            {
                DateSetSort Sort = new DateSetSort();
                SortedTasks = Sort.SortList(UnsortedTasks, 0, UnsortedTasks.Count - 1);
                return SortedTasks;
            }
            else if (OrderBy == "Priority")
            {
                PrioritySort Sort = new PrioritySort();
                SortedTasks = Sort.SortList(UnsortedTasks, 0, UnsortedTasks.Count - 1);
                return SortedTasks;
            }

            return null;
        }

        /// <summary>
        /// Determines the order of sorting, and fills the appropriate data structure
        /// </summary>
        /// <param name="AscDesc"></param>
        /// <param name="SortedTasks"></param>
        /// <returns></returns>
        private DataStructure AscDescFunction(string AscDesc, List<int> SortedTasks)
        {
            if (AscDesc == null)
            {
                MessageBox.Show("Ascending or Descending not selected!");
            }
            else if (AscDesc == "Ascending")
            {
                MyQueue TaskQueue = new MyQueue(SortedTasks.Count);
                foreach(int i in SortedTasks)
                {
                    TaskQueue.Enqueue(i);
                }
                return TaskQueue;
            }
            else if (AscDesc == "Descending")
            {
                MyStack TaskStack = new MyStack(SortedTasks.Count);
                foreach (int i in SortedTasks)
                {
                    TaskStack.Push(i);
                }
                return TaskStack;
            }

            return null;
        }

        private void cmboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtParameter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SearchBy = cmboSearchBy.SelectedItem.ToString();
            string Parameter = txtParameter.Text;

            ShowParameterisedTasks(ParameterisedTasks(SearchBy, Parameter));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvTasks.Rows.Clear();

            LoadTasks();
        }

        private void ShowParameterisedTasks(List<int> ParameterisedTasks)
        {
            List<int> Tasks = IncompleteTasks();
            dgvTasks.Rows.Clear();

            foreach (int TaskID in ParameterisedTasks)
            {
                if (Tasks.Contains(TaskID))
                {
                    DisplayTask(TaskID);
                }
            }
        }
        
        /// <summary>
        /// returns the list of tasks that should be displayed based ona a search
        /// </summary>
        /// <param name="SearchBy"></param>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        private List<int> ParameterisedTasks(string SearchBy, string Parameter)
        {

            List<int> Tasks = new List<int>();

            try
            {

                try
                {
                    string sSqlString = $"SELECT TaskID FROM TaskID WHERE {SearchBy}='{Parameter}'";
                    var reader = Query.ExecuteSqlReturn(sSqlString);

                    while (reader.Read())
                    {
                        Tasks.Add(Convert.ToInt32(reader[0]));
                    }

                    return Tasks;

                }
                catch
                {
                    //Used if the parameter is a date and needs to be syntaxed differently for the query

                    string sSqlString = $"SELECT TaskID FROM TaskID WHERE {SearchBy}={Parameter}";
                    var reader = Query.ExecuteSqlReturn(sSqlString);

                    while (reader.Read())
                    {
                        Tasks.Add(Convert.ToInt32(reader[0]));
                    }

                    return Tasks;
                }
            }
            catch
            {
                MessageBox.Show("Input is not Valid!");
                return Tasks;   
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

        private void grpSearchTasks_Enter(object sender, EventArgs e)
        {

        }
    }
}
