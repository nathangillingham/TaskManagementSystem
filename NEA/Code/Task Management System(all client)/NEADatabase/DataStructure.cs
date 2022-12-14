using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Net.Http.Headers;

namespace NEADatabase
{
    public abstract class DataStructure
    {

        public string USER;
        public string CONNECTION_STRING;
        SQL Query = new SQL();
        public DataStructure()
        {

        }

        public virtual void SaveStructure()
        {

        }

        public StreamWriter SetupWriter()
        {

            StreamWriter sw = new StreamWriter("Tasks.txt");
            return sw;

        }

        public OleDbDataReader GetTaskInfo(int TaskID)
        {
            string _sSqlString = $"SELECT * FROM TaskID WHERE TaskID={TaskID}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            return reader;
        }

        public void WriteTask(OleDbDataReader Reader, StreamWriter sw)
        {
            while (Reader.Read())
            {
                string writeText = $"TaskID:{Reader[0]} | Title:{Reader[1]} | Priority:{Reader[2]} | Description:{Reader[3]} | DateDue:{Reader[4]} | DateSet:{Reader[5]}";

                sw.WriteLine(writeText);
            }
        }
    }
}
