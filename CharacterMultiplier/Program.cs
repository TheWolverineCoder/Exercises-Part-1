using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two strings separated with space: ");
            string[] twoStrings = Console.ReadLine().Split(" ");
            string stringOne = twoStrings[0];
            string stringTwo = twoStrings[1];
            int sum = 0;
            if (stringOne.Length > stringTwo.Length)
            {
                sum += multiply(stringOne, stringTwo);
                for(int i = stringTwo.Length; i < stringOne.Length; i++)
                {
                    sum += (int)stringOne[i];
                }
            }
            else if(stringTwo.Length > stringOne.Length)
            {
                sum += multiply(stringTwo, stringOne);
                for (int i = stringOne.Length; i < stringTwo.Length; i++)
                {
                    sum += (int)stringTwo[i];
                }
            }
            else
            {
                sum += multiply(stringTwo, stringOne);
            }

            Console.WriteLine(sum);
        }

        static int multiply(string one, string two)
        {
            int sum = 0;
            for(int i = 0; i < two.Length; i++)
            {
                int result = (int)one[i] * (int)two[i];
                sum += result;
            }
            return sum;
        }

    }
}
