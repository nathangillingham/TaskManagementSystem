using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    internal class DateDueSort : QuickSort
    {
        public DateDueSort()
        {

        }

        public override List<int> SortList(List<int> list, int Lindex, int Rindex)
        {
            var n = Lindex;
            var m = Rindex;
            var fulcrum = list[Lindex];
            //identifies which value will be compared with all others

            while (n <= m)
            {
                while (GetDateDue(list[n]) < GetDateDue(fulcrum))
                {
                    //compares values left
                    n++;
                }

                while (GetDateDue(list[m]) > GetDateDue(fulcrum))
                {
                    //compares right
                    m--;
                }

                if (n <= m)
                {
                    //swaps values
                    int temp = list[n];
                    list[n] = list[m];
                    list[m] = temp;
                    n++;
                    m--;
                }
            }

            if (Lindex < m)
            {
                //recursion
                SortList(list, Lindex, m);

            }
            if (n < Rindex)
            {
                //recursion
                SortList(list, n, Rindex);
            }

            return list;
        }

    }
}
