using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NEADatabase
{
    public abstract class DataStructure
    {
        public DataStructure()
        {

        }

        public virtual void SaveStructure(object MyStructure)
        {

        }

        public void Writer(string Text)
        {

        }
        //title = 3 
        //desc = 6
        public void SetupTaskWriter()
        {
            string writeText = "|TaskID| |   Title   | |Priority| |      Description      | |      DateDue      | |      DateSet      |";
            File.WriteAllText("Tasks.txt", writeText);
        }
    }
}
