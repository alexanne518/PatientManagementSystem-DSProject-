using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem_2332924
{
    public class PriorityQueue
    {
        private Patient[] array;
        private int front;
        private int back;
        private int count;

        public int Count { get => this.count; }
        public int Capacity { get => this.array.Length; } //the size of the array

        public PriorityQueue()
        {
            this.array = new Patient[10]; // default size of the array
            this.front = -1; // everything's emptyyy
            this.back = -1; 
            this.count = 0;
        }

        public PriorityQueue(int capacity)
        {
            this.array = new Patient[capacity]; // default size of the array
            this.front = -1; // queue is empty
            this.back = -1; // queue is empty
            this.count = 0;
        }

        
        public Patient Enqueue(Patient patient) // Register patients arriving at the ER  
        {
            if (this.IsFull()) // Resize the array if full  
            {
                Resize();
            }

            if (this.IsEmpty()) // if the queue is empty we need to set the front and back pointers
            {
                this.front = 0; 
                this.back = 0;
                this.array[this.back] = patient; // add the first patient
            }
            else
            {
                // Find the correct position to insert the patient based on urgency
                int i = back; // if we want to insert new patient, we need to start from the back
                while (i >= front && ComparePatients(array[i], patient) < 0)
                // the existing patient at i has lower priority (time or urgency) than the new patient
                // for example, Bao Anh has level 2 urgency and Annabella has level 3 urgency
                // ComparePatients will return -1, so we need to shift the existing patient to the right
                {
                    array[i + 1] = array[i]; // shift the existing patient to the right
                    i--; // move to the next patient
                }
                // if didn't match the condition, we need to insert the new patient at the right position (increment the queue)
                array[i + 1] = patient;
                this.back++;
            }
            this.count++;
            return patient; // return the patient that was added to the queue
        }

        
        public Patient Dequeue() // Allow doctors to call the next patient in line, based on urgency  
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("No more patients");
            }
            Patient patient = array[front];
            this.front++;
            this.count--;
            if (this.IsEmpty()) // Reset pointers if the queue becomes empty
            {
                this.front = -1;
                this.back = -1;
            }
            return patient;
            // Time complexity: O(1) for retrieving the patient
        }

        private int ComparePatients(Patient a, Patient b)
        {
            // higher urgency first
            if (a.urgencyLevel != b.urgencyLevel)
            {     
                return b.urgencyLevel.CompareTo(a.urgencyLevel);
            }

            // if same urgency, earlier arrival first
            return b.arrivalTime.CompareTo(a.arrivalTime);
        }

        // allow doctors to check the next patient in line without removing them from the queue
        public Patient Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("No more patients");
            }
            return this.array[this.front];
        }

        public bool RemovePatient(int id)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("No more patients");
            }
            // find the index of the patient with the given id
            int index = -1;
            for (int i = this.front; i <= this.back; i++)
            {
                if (array[i].id == id)
                {
                    index = i;
                    break;
                }
            }
            // edge case when the patientId is not found in the queue
            if (index == -1)
            {
                Console.WriteLine($"Patient with ID {id} not found in the queue.");
                return false;
            }
            for (int i = this.front; i <= this.back; i++) // iterate (scan) through the queue to find the patient with the given id
            {
                if (this.array[i].id == id)
                {
                    // shift elements to the left
                    for (int j = i; j < this.back; j++)
                    {
                        array[j] = array[j + 1]; // overwrite the current patient with the next one
                    }
                    this.back--;
                    this.count--;
                    Console.WriteLine($"Patient with ID {id} has left the queue.");
                    return true;
                }
            }
            return false; // patient not found
        }

        private bool IsEmpty()
        {
            return this.back == -1; // if back is -1, the queue is empty
        }

        private bool IsFull()
        {
            return this.back == this.array.Length - 1; // if back reaches the end of the array, the queue is full
        }

        // I created this to make it easier to control (Bao Anh)
        private void Resize()
        {
            Patient[] temp = new Patient[2 * Capacity]; // Temporary array to switch the patients

            for (int i = this.front, j = 0; i <= this.back; i++, j++)
            {
                temp[j] = array[i];
            }
            array = temp;
            this.front = 0; // in case we have to resize the array we need to reset the front and back pointers
            back = this.count - 1; // Reset back pointer based on current count
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
