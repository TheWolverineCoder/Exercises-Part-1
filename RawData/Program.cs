using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Console.WriteLine("Enter the number of cars you are about to enter: ");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ");
                cars.Add(new Car(carInfo));
            }
            Console.WriteLine("Enter type of cargo: ");
            string type = Console.ReadLine();
            if(type == "flamable")
            {
                foreach(var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if(type == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Cargo.Weight<1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engine{ get; set; }
        public Cargo Cargo { get; set; }
        
        public Car(string[] carInfo)
        {
            this.Model = carInfo[0];
            this.Engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
            this.Cargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
        }

    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power{ get; set; }

        public Engine(int speed,int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }
        public Cargo(int weight,string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
