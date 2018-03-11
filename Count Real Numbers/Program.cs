using System;
using System.Collections.Generic;

namespace Count_Real_Numbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double[] input = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            SortedDictionary<double, int> counter = new SortedDictionary<double, int>();
            foreach (var num in input)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num]++;
                }
                else
                {
                    counter[num] = 1;
                }
            }

            foreach (var pair in counter.Keys)
            {
                Console.WriteLine($"{pair} -> {counter[pair]}");
            }
        }
    }
}