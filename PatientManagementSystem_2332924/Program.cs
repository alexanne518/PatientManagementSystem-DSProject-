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

// display the queue
Console.WriteLine("Patients in the queue (prioritized):");
queue.Display();
