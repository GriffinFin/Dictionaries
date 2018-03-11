using System;
using System.Linq;

namespace MinMaxSumAverage
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(Console.ReadLine());
            }

            Console.WriteLine("Sum = " + array.Sum());
            Console.WriteLine("Min = " + array.Min());
            Console.WriteLine("Max = " + array.Max());
            Console.WriteLine("Average = " + array.Average());
            
        }
    }
}