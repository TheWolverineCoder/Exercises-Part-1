using System;
using System.Threading;

namespace EHowToWait
{
    class Program
    {
        static volatile bool isRunning;
        static void Worker()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
            }
            isRunning = false;
            Console.WriteLine("Thread is done.");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(Worker);

            isRunning = true;
            t.Start();

            int i = 0;
            while (isRunning)
            {
                i++;
            }
            Console.WriteLine(i);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}