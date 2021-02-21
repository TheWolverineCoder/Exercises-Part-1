using System;
using System.Linq;

namespace SBarSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            var students = Enumerable.Range(1,51).Select(i=> new Student { Name = i.ToString(), Bar = bar }).ToList();
            foreach(var student in students)
            {
                student.PaintTheTownRed();
            }
        }
    }
}
