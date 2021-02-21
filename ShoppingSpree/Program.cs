using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();
            Console.WriteLine("Enter the people and their money in the format person=money and separate them with ;   :");
            string[] people= Console.ReadLine().Split(";");
            Console.WriteLine("Enter the products and their price in the format product=price and separate them with ;   :");
            string[] products = Console.ReadLine().Split(";");
            foreach(string person in people)
            {
                string[] personInfo = person.Split("=");
                string personName = personInfo[0];
                int personMoney = int.Parse(personInfo[1]);
                Person newPerson = new Person(personName, personMoney);
                peopleList.Add(newPerson);
            }
            foreach (string product in products)
            {
                string[] productInfo = product.Split("=");
                string productName = productInfo[0];
                int productPrice = int.Parse(productInfo[1]);
                Product newProduct = new Product(productName, productPrice);
                productsList.Add(newProduct);
            }
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputInfo = input.Split(" ");
                Person selectedPerson = peopleList.Find(p => p.Name == inputInfo[0]);
                Product selectedProduct = productsList.Find(pr => pr.ProductName == inputInfo[1]);
                if(selectedPerson.Money >= selectedProduct.Price)
                {
                    selectedPerson.Money -= selectedProduct.Price;
                    selectedPerson.ProductsBag.Add(selectedProduct.ProductName);
                    Console.WriteLine($"{selectedPerson.Name} bought {selectedProduct.ProductName}");
                }
                else
                {
                    Console.WriteLine($"{selectedPerson.Name} can't afford {selectedProduct.ProductName}");
                }
            }

            foreach(Person person1 in peopleList)
            {
                if(person1.ProductsBag.Count > 0)
                {
                    Console.Write($"{person1.Name} - {string.Join(",", person1.ProductsBag)}");
                }
                else
                {
                    Console.WriteLine($"{person1.Name} - Nothing bought");
                }
                
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public List<string> ProductsBag { get; set; }

        public Person(string name,int money)
        {
            Name = name;
            Money = money;
            ProductsBag = new List<string>();
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Product(string name,int price)
        {
            ProductName = name;
            Price = price;
        }
    }
}
