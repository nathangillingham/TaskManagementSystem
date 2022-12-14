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

namespace NEADatabase
{
    internal static class Program
    {
        [STAThread]
        
        public static void Main()
        {
            string USER = "UserDatabase.mdb";
            string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = " + USER + ";";

            Console.WriteLine(Encryptor.Hash("test"));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CatalogClass cat = new CatalogClass();

            if (!File.Exists(USER))
            {
                cat.Create(CONNECTION_STRING);
                MessageBox.Show("Database Created!");
                CreateTables();
                Application.Run(new InitializeAdmin());


            }
            else
            {
                Application.Run(new Login());
            }
            cat = null;


            void CreateTables()
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
                                                    + "Hierarchy NUMERIC(2),"
                                                    + "HashValue VARCHAR(60),"
                                                    + "PRIMARY KEY(UserID)"
                                                    + ")";
                    Query.ExecuteSql(_sSqlString);

                    _sSqlString2 = "CREATE TABLE TaskID("
                                                    + "TaskID INT IDENTITY(1,1),"
                                                    + "Title VARCHAR(30) UNIQUE,"
                                                    + "Priority NUMERIC(1),"
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



        }



    }

}
