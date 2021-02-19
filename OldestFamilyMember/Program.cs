using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of members you want to enter: ");
            int numberOfMembers = int.Parse(Console.ReadLine());
            Family newFamily = new Family();
            for (int i = 0; i < numberOfMembers; i++)
            {
                string[] personInput = Console.ReadLine().Split(" ");
                string name = personInput[0];
                int age = int.Parse(personInput[1]);
                Person newPerson = new Person(name, age);
                newFamily.AddMember(newPerson);

            }
            Person oldestPerson= newFamily.GetOldestMember(newFamily.FamilyMembers);
            string oldestPersonName = oldestPerson.Name;
            int oldestPersonAge = oldestPerson.Age;
            Console.WriteLine("The oldest person is: {0} and is {1} years old.",oldestPersonName,oldestPersonAge);
        }
    }

    class Person
    {
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Family
    {
        public Family()
        {
            FamilyMembers = new List<Person>();
        }
        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember(List<Person> familyMembers)
        {
            Person oldestMember = familyMembers.OrderByDescending(f => f.Age).First();
            return oldestMember;
        }
    }
}
