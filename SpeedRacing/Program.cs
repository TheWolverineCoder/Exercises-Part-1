using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();
            Console.WriteLine("Enter the number of cars you are about to enter: ");
            int cars = int.Parse(Console.ReadLine());
            for(int i = 0; i < cars; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);
                carsList.Add(car);
            }
            string inputTwo;
            while((inputTwo = Console.ReadLine()) != "End")
            {
                string[] inputArr = inputTwo.Split(" ");
                string command = inputArr[0];
                if(command == "Drive")
                {
                    string mod = inputArr[1];
                    double distance = double.Parse(inputArr[2]);
                    Car curCar = carsList.Find(c => (c.Model == mod));
                    if(distance*curCar.FuelConsumptionPerKm <= curCar.FuelAmount)
                    {
                        curCar.TravelledDistance += distance;
                        curCar.FuelAmount -= distance * curCar.FuelConsumptionPerKm;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive!");
                    }
                }

            }

            foreach(Car car in carsList)
            {
                Console.WriteLine("{0} {1:F2} {2}",car.Model,car.FuelAmount,car.TravelledDistance);
            }

        }
    }

    class Car
    {
        public Car(string model,double fuelAmount,double consumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = consumption;
            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDistance { get; set; }

        public bool isTheFuelEnough(double kilometers,double FuelConsumptionPerKm)
        {
            double fuelUsed = kilometers * FuelConsumptionPerKm;
            if(fuelUsed <= FuelAmount)
            {
                TravelledDistance += kilometers;
                FuelAmount -= fuelUsed;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
