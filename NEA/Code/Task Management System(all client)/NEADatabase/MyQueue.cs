using System;
using System.Windows.Forms;
using System.IO;

namespace NEADatabase
{
    public class MyQueue : DataStructure
    {
        //inheritance
        int[] QueueArray;
        int tail = 0;
        int head = 0;
        public int length;

        public MyQueue(int length)
        {
            this.QueueArray = new int[length];
            this.length = length;
        }

        //file handling
        public override void SaveStructure()
        {
            StreamWriter WriteStream = SetupWriter();

            while(!IsEmpty())
            {
                WriteTask(GetTaskInfo(Dequeue()), WriteStream);
            }

            WriteStream.Close();
            MessageBox.Show("Tasks Saved!");
        }

        //adds integer to queue
        public void Enqueue(int number)
        {
            if(tail > length)
            {
                throw new Exception("Queue Overflow");
            }
            else
            {
                this.QueueArray[tail] = number;
                tail++;
            }
        }

        //removes integer from queue
        public int Dequeue()
        {
            Console.WriteLine(head);
            int value = this.QueueArray[head];
            if(head == length)
            {
                head = 1;
            }
            else
            {
                head++;
            }
            return value;
        }

        //checks if structure is empty
        public bool IsEmpty()
        {
            if (tail==head)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
