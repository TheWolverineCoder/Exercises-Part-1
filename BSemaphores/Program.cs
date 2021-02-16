using System;
using System.Linq;
using System.Threading;

namespace BSemaphores
{
    class Program
    {
        static Semaphore semaphore;

        static void Worker(object tag)
        {
            Console.WriteLine(tag + " starts.");
            Console.WriteLine(tag + " waits on semaphore.");
            semaphore.WaitOne();
            Console.WriteLine(tag + " entered the semaphore.");
            Thread.Sleep(1000);
            semaphore.Release();
            Console.WriteLine(tag + " left the semaphore.");
            Console.WriteLine(tag + " ends.");
        }
        static void Main(string[] args)
        {
            semaphore = new Semaphore(3, 3);
            Thread[] threads = Enumerable.Range(1, 10).Select(i => new Thread(Worker)).ToArray();
            for(int k = 0; k < threads.Length; k++)
            {
                threads[k].Start(k.ToString());

            }
            
            foreach (var t in threads) t.Join();


            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
