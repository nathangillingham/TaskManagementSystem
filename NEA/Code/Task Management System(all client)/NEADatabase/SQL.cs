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
    public class SQL
    {

        /// <summary>
        /// Ammends database, used for creating fields, entires, doesnt return a value from database
        /// </summary>
        private string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider; Data Source = UserDatabase.mdb;";
        public void ExecuteSql(string Query)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                using (OleDbCommand command = new OleDbCommand(Query))
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

        /// <summary>
        /// Returns values when doing a query, used to retrieve values, not put them in the database
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public OleDbDataReader ExecuteSqlReturn(string Query)
        {
            OleDbConnection connection = new OleDbConnection(CONNECTION_STRING);

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;
            command.CommandText = Query;

            OleDbDataReader reader = command.ExecuteReader();

            return reader;

        }
    }
}

