using System;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering vehicles in the following format({type}/{brand}/{model}/{horse power / weight}): ");
            string input;
            CatalogueVehicle catalogueVehicle = new CatalogueVehicle();
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputInfo = input.Split("/");
                string type = inputInfo[0];
                string brand = inputInfo[1];
                string model = inputInfo[2];
                int lastSpec = int.Parse(inputInfo[3]);
                if(type == "Car")
                {
                    Car car = new Car(brand,model,lastSpec);
                    catalogueVehicle.cars.Add(car);
                }
                else if(type == "Truck")
                {
                    Truck truck = new Truck(brand, model,lastSpec);
                    catalogueVehicle.trucks.Add(truck);
                }
            }
            Console.WriteLine("Cars: ");
            foreach(Car car in catalogueVehicle.cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp.");
            }
            Console.WriteLine();
            Console.WriteLine("Trucks: ");
            foreach(Truck truck in catalogueVehicle.trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kgs.");
            }
        }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }

    class CatalogueVehicle
    {
        public CatalogueVehicle()
        {
            cars = new List<Car>();
            trucks = new List<Truck>();
        }

        public List<Car> cars { get; set; }
        public List<Truck> trucks { get; set; }
    }
}
