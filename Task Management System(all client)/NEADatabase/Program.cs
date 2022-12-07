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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*            List<int> list = new List<int>();
                        list.Add(1);
                        list.Add(3);
                        list.Add(2);
                        list.Add(1);
                        list.Add(4);
                        list.Add(6);

                        DateDueSort quickSort = new DateDueSort();
                        List<int> Sorted = quickSort.SortList(list, 0, list.Count - 1);
                        foreach (int i in Sorted)
                        {
                            Console.WriteLine(i);
                        }*/
            string writeText = "|TaskID| |   Title   | |Priority| |      Description      | |      DateDue      | |      DateSet      |";
            File.WriteAllText("Tasks.txt", writeText);
        }

    }

}
