
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace SoftuniExercisesWithVariables
{
    
    public class SoftUni
    {
        public static void Main()
        {
            var arr = new int[] { 1, 2, 3, 4, 5 };
            Increment(arr);
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

        }

        static void Increment(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]++;
            }
        }


    }
}