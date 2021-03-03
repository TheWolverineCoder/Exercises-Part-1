using System;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double noTaxPrice = 0;
            string input;
            while((input = Console.ReadLine()) != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if(price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    noTaxPrice += price;
                }

            }
            double taxes = 0.2 * noTaxPrice;
            double afterTaxPrices = noTaxPrice + taxes;
            if(noTaxPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                if(input == "special")
                {
                    afterTaxPrices = afterTaxPrices - (0.1 * afterTaxPrices);
                }
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine("Price without taxes: {0:F2}$",noTaxPrice);
                Console.WriteLine("Taxes: {0:F2}$",taxes);
                Console.WriteLine("-----------");
                Console.WriteLine("Total price: {0:F2}",afterTaxPrices);
            }
        }
    }
}
