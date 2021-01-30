using System;
using System.Collections.Generic;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] {
                "Excellent product. ",
                "Such a great product. " ,
                "I always use that product. ",
                "Best product of its category. ",
                "Exceptional product. ",
                "I can’t live without this product. "
            };

            string[] events = new string[] {
                "Now I feel good. ",
                "I have succeeded with this product. ",
                "Makes miracles.I am happy of the results! ",
                "I cannot believe but now I feel awesome. ",
                "Try it yourself, I am very satisfied. ",
                "I feel great. "
                
            };
            string[] authors = new string[] {
                "Diana - ",
                "Petya - ",
                "Stella - ",
                "Elena - ",
                "Katya - ",
                "Iva - ",
                "Annie - ",
                "Eva - ",
            };
            string[] cities = new string[] {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse",
            };

            Random rand = new Random();
            Console.WriteLine("Enter the number of advertisement message you want to generate: ");
            int number = int.Parse(Console.ReadLine());
            for(int i = 0; i < number; i++)
            {
                int randomPhr = rand.Next(0, phrases.Length);
                int randomEve = rand.Next(0, events.Length);
                int randomAut = rand.Next(0, authors.Length);
                int randomCity = rand.Next(0, cities.Length);
                Console.WriteLine(phrases[randomPhr] + events[randomEve] + authors[randomAut] + cities[randomCity]);
            }
        }
    
        
    }
}
