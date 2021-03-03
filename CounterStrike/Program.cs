using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int count = 0;
            bool isOk = true;
            string distance;
            while((distance = Console.ReadLine()) != "End of battle")
            {
                int energyNeeded = int.Parse(distance);
                if(initialEnergy >= energyNeeded)
                {
                    initialEnergy -= energyNeeded;
                    count++;
                }
                else
                {
                    isOk = false;
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
                    break;
                }

                if(count % 3 == 0)
                {
                    initialEnergy += count;
                }
            }

            if(initialEnergy > 0 && isOk == true)
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
            }
            
        }
    }
}
