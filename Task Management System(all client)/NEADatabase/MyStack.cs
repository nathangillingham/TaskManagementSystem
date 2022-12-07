using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    public class MyStack : DataStructure
    {

        int topPointer;
        int[] StackArray;
        int size;

        public MyStack(int size)
        {
            topPointer = 0;
            StackArray = new int[size];
            this.size = size;
        }

        public override void SaveStructure(object MyStructure)
        {

        }


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
