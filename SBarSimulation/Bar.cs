using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SBarSimulation
{
    class Bar
    {
        const int maxSeats = 20;
        Semaphore semaphore;

        List<Student> customers;
        public Bar()
        {
            semaphore = new Semaphore(maxSeats, maxSeats);
            customers = new List<Student>();
        }

        public void Enter(Student student)
        {
            semaphore.WaitOne();
            lock (customers)
            {
                customers.Add(student);
            }
            
        }

        public void Leave(Student student)
        {
            semaphore.Release();
            lock (customers)
            {
                customers.Remove(student);
            }
        }
    }
}
