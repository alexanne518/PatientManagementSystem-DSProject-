using System;

using PatientManagementSystem_2332924;

PriorityQueue queue = new PriorityQueue();

// register patients arriving at the ER
queue.Enqueue(new Patient(4, "Annabella", 3, DateTime.Now.AddMinutes(-15)));
queue.Display();
Console.WriteLine("==========================");
queue.Enqueue(new Patient(2, "Alexanne", 3, DateTime.Now.AddMinutes(-5)));
queue.Display();
Console.WriteLine("==========================");
queue.Enqueue(new Patient(3, "Bao Anh", 2, DateTime.Now.AddMinutes(-8))); 
queue.Display();
Console.WriteLine("==========================");
queue.Enqueue(new Patient(1, "Cong Huy Kieu", 1, DateTime.Now.AddMinutes(0)));
queue.Display();
Console.WriteLine("==========================");
// Simulate doctor calling patients
Console.WriteLine("Doctor is now calling patients: ");
while (queue.Count > 0)
{
    // Doctors can see who is next
    Patient nextPatient = queue.Peek();
    Console.WriteLine($"Next patient: {nextPatient}");

    // Doctor decides to call the patient
    Patient calledPatient = queue.Dequeue();
    Console.WriteLine($"Calling patient: {calledPatient}\n");
}

// display the queue
Console.WriteLine("Patients in the queue (prioritized):");
// register patients arriving at the ER
queue.Enqueue(new Patient(4, "Annabella", 3, DateTime.Now.AddMinutes(-15)));
queue.Enqueue(new Patient(2, "Alexanne", 3, DateTime.Now.AddMinutes(-5)));
queue.Enqueue(new Patient(3, "Bao Anh", 2, DateTime.Now.AddMinutes(-8)));
queue.Enqueue(new Patient(1, "Cong Huy Kieu", 1, DateTime.Now.AddMinutes(0)));
queue.Display();

Console.WriteLine("==========================");
// Patient with ID 3 decides to leave
queue.RemovePatient(3); // Remove patient with ID 3
Console.WriteLine("==========================");

// Display the queue after removal
Console.WriteLine("Patients in the queue after patient leaves:");
queue.Display();
Console.WriteLine("==========================");
