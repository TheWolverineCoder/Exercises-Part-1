using System;
using System.Collections.Generic;

namespace VehicleCatalogue2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            //{typeOfVehicle} {model} {color} {horsepower}
            Console.WriteLine("Start entering specifications: ");
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split(" ");
                string type = inputInfo[0];
                string brand = inputInfo[1];
                string color = inputInfo[2];
                int hp = int.Parse(inputInfo[3]);

                if (type == "car")
                {
                    Car car = new Car(brand, color, hp);
                    cars.Add(car);
                }
                else if (type == "truck")
                {
                    Truck truck = new Truck(brand, color, hp);
                    trucks.Add(truck);
                }

            }

            Console.WriteLine("Enter a car/truck brand: ");
            while ((input = Console.ReadLine()) != "Close The Catalogue")
            {
                string brand = input;
                foreach (Car car in cars)
                {
                    if (car.Brand == brand)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine("Model: " + car.Brand);
                        Console.WriteLine("Color: " + car.Color);
                        Console.WriteLine("Horse Power: " + car.HorsePower);
                    }
                }

                foreach (Truck truck in trucks)
                {
                    if (truck.Brand == brand)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine("Model: " + truck.Brand);
                        Console.WriteLine("Color: " + truck.Color);
                        Console.WriteLine("Horse Power: " + truck.HorsePower);
                    }
                }
            }
        }

        class Car
        {
            public Car(string brand, string color, int horsePower)
            {
                Brand = brand;
                Color = color;
                HorsePower = horsePower;
            }

            public string Brand { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

        }

        class Truck
        {
            public Truck(string brand, string color, int horsePower)
            {
                Brand = brand;
                Color = color;
                HorsePower = horsePower;
            }

            public string Brand { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

        }
    }
}