using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    public class QuickSort
    {
        public string USER;
        public string CONNECTION_STRING;
        SQL Query = new SQL();
        public QuickSort()
        {

        } 

        public virtual List<int> SortList(List<int> list, int Lindex, int Rindex)
        {
            var n = Lindex;
            var m = Rindex;
            var fulcrum = list[Lindex];
            
            while(n <= m)
            {
                while(list[n] < fulcrum)
                {
                    n++;
                }

                while(list[m] > fulcrum)
                {
                    m--;
                }

                if(n <= m)
                {
                    int temp = list[n];
                    list[n] = list[m];
                    list[m] = temp;
                    n++;
                    m--;
                }
            }

            if(Lindex < m)
            {

                SortList(list, Lindex, m);

            }
            if(n < Rindex)
            {
                SortList(list, n, Rindex);
            }

            return list;
        }


        public int GetTaskPriority(int taskId)
        {
            string _sSqlString = $"SELECT Priority FROM TaskID WHERE TaskID={taskId}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if(!reader.Read())
            {
                return 0;
            }
            else
            {
                int ID = int.Parse(reader[0].ToString());
                return ID;
            }
        }

        public DateTime GetDateDue(int taskId)
        {
            string _sSqlString = $"SELECT DateDue FROM TaskID WHERE TaskID={taskId}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if (!reader.Read())
            {
                throw new Exception($"Date Due not found for task {taskId}");
            }
            else
            {
                DateTime dateset = Convert.ToDateTime(reader[0]);
                return dateset;
            }
        }

        public DateTime GetDateSet(int taskId)
        {
            string _sSqlString = $"SELECT DateSet FROM TaskID WHERE TaskID={taskId}";
            var reader = Query.ExecuteSqlReturn(_sSqlString);
            if (!reader.Read())
            {
                throw new Exception($"Date Set not found for task {taskId}");
            }
            else
            {
                DateTime dateset = Convert.ToDateTime(reader[0]);
                return dateset;
            }
        }

    }
}
