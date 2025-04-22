using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem_2332924
{
    public class PriorityQueue
    {
        private int[] array;
        private int front;
        private int back;
        private int count;

        public int Count { get => this.count; }
        public int Capacity { get => this.array.Length; } //the size of the array

        public PriorityQueue()
        {
            this.array = new int[Capacity];
            this.front = -1; //everyhtings emptyyy
            this.back = -1; 
            this.count = 0;
        }


        public void Enqueue(int queue, int priority) //Register patients arriving at the ER (didnt do the priority)
        {
            if (this.IsFull()) //hace to resize the array
            { 
                int[] temp = new int[2 * Capacity]; //temp array to switch the patients

                for(int i = this.front, j = 0; i <= this.back; i++, j++)
                {
                    temp[j] = array[i]; 
                }
                array = temp;
                this.front = 0; //incase it wasdnt ar 0 ?? idfk
                this.back = this.count;
            }

            if (this.IsEmpty()) //fuken why??
            {
                this.front = 0;
                this.back = -1;
            }

            array[++back] = queue;
            this.count++;
        }

        public int Dequeue() //Allow doctors to call to the next patient in line, based on urgency (guessing that means the first one who knows)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("No more patients");
            }
            this.count--;
            return this.array[this.front++]; //like she says based on urgency but theyre already in order from most urgent to lest so...
        }


        private bool Contains(int patient)
        {
            for (int i  = 0; i < this.back; i++)
            {
                if (array[i] == patient)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsEmpty()
        {
            if (this.back == 0)
            {
                return true;
            }
            return false;
        }

        private bool IsFull()
        {
            if ( this.front == -1 || this.front > this.back) //if front is -1 then it means we just stared, when the back is less then the front we dequeue all of the elements
            { 
                return true;
            }
            return false;
        }


        public void Display()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("no patients to display");
            }
            else
            {
                for (int i = this.front; i <= this.back; i++)//make sure its <= cause last points to an element
                {
                    Console.WriteLine(array[i]+", ");
                }
            }
        }
    }
}
