using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;

namespace SBarSimulation
{
    enum StudentActionOutdoors { Walk,Bar,Home};
    enum StudentActionBar { Drink,Dance,Leave};
    class Student
    {
        public string Name { get; set; }

        public Bar Bar { get; set; }

        Random rand = new Random();

        ManualResetEvent eventAtHome = new ManualResetEvent(false);
        private StudentActionOutdoors GetRandomOutdoorAction()
        {
            int val = rand.Next(10);
            if (val < 7) return StudentActionOutdoors.Bar;
            else return StudentActionOutdoors.Home;
        }

        private StudentActionBar GetRandomBarAction()
        {
            int val = rand.Next(10);
            if (val < 4) return StudentActionBar.Dance;
            else if (val < 8) return StudentActionBar.Drink;
            else return StudentActionBar.Leave;
        }

        private void GoForAWalk()
        {
            Console.WriteLine(Name + " goes for a walk.");
            Thread.Sleep(200);
        }

        private void EnterBar()
        {
            Console.WriteLine(Name + " waits in line for the bar.");
            Bar.Enter(this);
            Console.WriteLine(Name + " entered the bar.");

            while (true)
            {
                var barAction = GetRandomBarAction();
                switch (barAction)
                {
                    case StudentActionBar.Dance:
                        Console.WriteLine(Name + " is dancing");
                        break;
                    case StudentActionBar.Drink:
                        Console.WriteLine(Name + " is drinking");
                        break;
                    case StudentActionBar.Leave:
                        Bar.Leave(this);
                        
                        return;
                    default:
                        throw new ArgumentException(barAction + " action is not supported!");
                }
            }
        }
        private void PaintTheTownRedInternal()
        {
            
            while (true)
            {
                GoForAWalk();
                var outdoorAction = GetRandomOutdoorAction();
                switch (outdoorAction)
                {
                    case StudentActionOutdoors.Bar:
                        EnterBar();
                        
                        break;
                    case StudentActionOutdoors.Home:
                        Console.WriteLine(Name + " goes home.");
                        eventAtHome.WaitOne(0);
                        return;
                    default:
                        throw new ArgumentException(outdoorAction + " action is not supported!");

                }
               
                
            }
        }

        public void PaintTheTownRed()
        {
            Thread t = new Thread(PaintTheTownRedInternal);
            t.Start();
        }
        /*
        public bool AtHome
        {
            get
            {
                return 
            }
        }
        */
    }
}
