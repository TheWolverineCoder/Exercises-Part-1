using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your directory: ");
            string directory = Console.ReadLine();
            string[] separated = directory.Split("\\");
            string file = separated[separated.Length - 1];
            string[] fileConc = file.Split(".");
            Console.WriteLine("File name: " + fileConc[0]);
            Console.WriteLine("File extension: " + fileConc[1]);

        }
    }
}
