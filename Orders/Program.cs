using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering your products: ");
            string input;
            Dictionary<string, double> productPrices = new Dictionary<string, double>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArr = input.Split();
                string productName = inputArr[0];
                double productPrice = double.Parse(inputArr[1]);
                int quantity = int.Parse(inputArr[2]);
                if (productPrices.ContainsKey(productName))
                {
                    if(productPrices[productName] < productPrice)
                    {
                        productPrices[productName] = productPrice;
                        productQuantity[productName] += quantity;
                    }
                }
                else
                {
                    productPrices.Add(productName, productPrice);
                    productQuantity.Add(productName, quantity);
                }
            }

            foreach(var item in productPrices)
            {
                Console.WriteLine("{0} -> {1:F2}", item.Key,(item.Value*productQuantity[item.Key]));
            }
        }
    }
}
