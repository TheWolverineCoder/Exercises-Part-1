using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering: ");
            List<Box> boxes = new List<Box>();
            string input;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputInfo = input.Split(" ");
                string serialNumber = inputInfo[0];
                string itemName = inputInfo[1];
                int quantity = int.Parse(inputInfo[2]);
                decimal itemPrice = decimal.Parse(inputInfo[3]);

                Item item = new Item();
                item.Name = itemName;
                item.Price = itemPrice;


                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.Quantity = quantity;
                box.Item = item;
                boxes.Add(box);
                
            }

            foreach  (var currentBox in boxes.OrderByDescending(x => x.PriceBox))
            {
                Console.WriteLine(currentBox.SerialNumber);
                Console.WriteLine($"--{currentBox.Item.Name} - {currentBox.Item.Price:F2}: {currentBox.Quantity} \n-- {currentBox.PriceBox}");
            }
        }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox
            => Item.Price * Quantity;

    }

    class Item
    {

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
