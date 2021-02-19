using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start entering information in the format Name ID Age: ");
            string input;
            List<Person> people = new List<Person>();
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputInfo = input.Split(" ");
                string personName = inputInfo[0];
                int personID = int.Parse(inputInfo[1]);
                int personAge = int.Parse(inputInfo[2]);
                Person person = new Person(personName, personID, personAge);
                people.Add(person);
            }

            var byAge = people.OrderByDescending(x => x.Age);
            foreach (Person person in byAge)
            {
                Console.WriteLine(person.Name + " with ID " + person.ID + " is " + person.Age + " years old.");
            }
        }
    }

    class Person
    {

        public Person(string name,int id,int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }

    }
}
