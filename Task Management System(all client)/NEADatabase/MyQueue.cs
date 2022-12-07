using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    public class MyQueue : DataStructure
    {
        int[] QueueArray;
        int tail = 0;
        int head = 0;
        public int length;

        public MyQueue(int length)
        {
            this.QueueArray = new int[length];
            this.length = length;
        }

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

        public int Dequeue()
        {
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

        public bool IsEmpty()
        {
            if (tail==0)
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
