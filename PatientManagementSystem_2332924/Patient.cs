using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem_2332924
{
    public class Patient
    {
        public int id { get; set; } // unique identifier for each patient
        public string name { get; set; }
        public int urgencyLevel { get; set; } // 1 = highest, 2 = medium, 3 = lowest
        public DateTime arrivalTime { get; set; } // time of arrival


        // Constructor
        public Patient(int id, string name, int urgencyLevel, DateTime arrivalTime)
        {
            this.id = id;
            this.name = name;
            this.urgencyLevel = urgencyLevel;
            this.arrivalTime = arrivalTime;
        }

        // Override method for better readability
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Urgency Level: {urgencyLevel}, Arrival Time: {arrivalTime}";
        }
    }
}
