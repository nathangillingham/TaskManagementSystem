using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    internal class DateSetSort : QuickSort
    {
        public DateSetSort()
        {

        }

        public override List<int> SortList(List<int> list, int Lindex, int Rindex)
        {
            var n = Lindex;
            var m = Rindex;
            var fulcrum = list[Lindex];

            while (n <= m)
            {
                while (GetDateSet(list[n]) < GetDateSet(fulcrum))
                {
                    n++;
                }

                while (GetDateSet(list[m]) > GetDateSet(fulcrum))
                {
                    m--;
                }

                if (n <= m)
                {
                    int temp = list[n];
                    list[n] = list[m];
                    list[m] = temp;
                    n++;
                    m--;
                }
            }

            if (Lindex < m)
            {

                SortList(list, Lindex, m);

            }
            if (n < Rindex)
            {
                SortList(list, n, Rindex);
            }

            return list;
        }

    }
}
