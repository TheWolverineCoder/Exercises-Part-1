using System;
using System.Threading;
using System.Threading.Tasks;

namespace ATaskCancellation
{
    class Program
    {
        static CancellationTokenSource cts = new System.Threading.CancellationTokenSource();
        static CancellationToken token = cts.Token;
        static void Main(string[] args)
        {

            Task t = Task.Run(
                () =>
                {
                    Console.WriteLine("Task 1 started. ");
                    for (int i = 0; i < 10; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            //Do all the needed cleanup
                            token.ThrowIfCancellationRequested();
                        }
                        Task.Delay(400).Wait();
                    }
                    Console.WriteLine("Task 1 completed.");
                }).ContinueWith(p => 
                {
                    Console.WriteLine("Task 2 here.");
                },token);
            
            cts.CancelAfter(2000);

            try
            {
                t.Wait();
            }
            catch (AggregateException ex)
            {
                if(ex.InnerException is OperationCanceledException)
                {
                    Console.WriteLine("Task is cancelled.");
                }
            }
            
            Console.WriteLine("Task t completion status: " + t.Status.ToString());
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
