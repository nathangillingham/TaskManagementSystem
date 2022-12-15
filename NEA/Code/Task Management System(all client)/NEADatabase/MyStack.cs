using System;
using System.Windows.Forms;
using System.IO;


namespace NEADatabase
{
    public class MyStack : DataStructure
    {
        //inheritance
        int topPointer;
        int[] StackArray;
        int size;

        public MyStack(int size)
        {
            topPointer = 0;
            StackArray = new int[size];
            this.size = size;
        }

        //polymorphiism
        //filehandling
        public override void SaveStructure()
        {
            StreamWriter WriteStream = SetupWriter();

            while(!IsEmpty())
            {
                WriteTask(GetTaskInfo(Pop()), WriteStream);
            }

            WriteStream.Close();
            MessageBox.Show("Tasks Saved!");
        }

        //checks if stack is empty
        public bool IsEmpty()
        {
            if(topPointer == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //puts integer on top of stack
        public void Push(int number)
        {
            if (topPointer == this.size)
            {
                throw new Exception("Stack Overflow");
            }
            else
            {
                StackArray[topPointer] = number;
                topPointer++;
            }
        }

        //takes integer off stack
        public int Pop()
        {
            if (topPointer == 0)
            {
                throw new Exception("Stack Underflow");
            }
            else
            {
                topPointer--;
                return StackArray[topPointer];
            }
        }

        //looks at top value, doesnt pop
        public int Peek()
        {
            if (topPointer == 0)
            {
                throw new Exception("Stack Underflow");
            }
            else
            {
                return StackArray[topPointer - 1];
            }
        }

    }
}
