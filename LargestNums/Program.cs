using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestNums
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var updated = nums.OrderByDescending(num => num);
            var largest = updated.Take(3);
            Console.WriteLine(string.Join(" ", largest));
        }
    }
}