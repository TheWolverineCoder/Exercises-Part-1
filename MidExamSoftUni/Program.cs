using System;

namespace MidExamSoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of biscuits a worker produces per day: ");
            int biscuitsPerDay = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of workers in the factory: ");
            int workersCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of biscuits that the \n competing factory produces for 30 days: ");
            int competingFactoryBiscuits = int.Parse(Console.ReadLine());
            int producedFirstDay = biscuitsPerDay * workersCount;
            double producedForAMonth = 0;
            for(int i = 0; i < 10; i++)
            {
                producedForAMonth += producedFirstDay + producedFirstDay + (int)(0.75*biscuitsPerDay*workersCount);
                
            }

            Console.WriteLine("You have produced " + producedForAMonth + " biscuits for the past month.");
            double percent = 0;
            if(producedForAMonth > competingFactoryBiscuits)
            {
                percent = (producedForAMonth - competingFactoryBiscuits) / competingFactoryBiscuits * 100;
                Console.WriteLine("You produced {0:F2} percent more biscuits.",percent);
            }
            else
            {
                percent = (competingFactoryBiscuits - producedForAMonth) / producedForAMonth * 100;
                Console.WriteLine("You produced {0:F2} percent less biscuits.",percent);
            }
        }
    }
}
