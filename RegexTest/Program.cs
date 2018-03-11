using System;
using System.Text.RegularExpressions;

namespace RegexTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = "Lepa Brena @Sunny Beach 25 3500";
            Match m = Regex.Match(input, @"([A-Za-z ]+) (@[A-Za-z ]+) (\d+) (\d+)");
            if (m.Success)
            {
                Console.WriteLine("Success!");
                string performer = m.Groups[1].ToString();
                string venue = m.Groups[2].ToString().Remove(0, 1);
                int price = Int32.Parse(m.Groups[3].ToString());
                int count = Int32.Parse(m.Groups[4].ToString());
                Console.WriteLine(performer);
                Console.WriteLine(venue);
                Console.WriteLine(price);
                Console.WriteLine(count);
                Console.WriteLine(price*count);
            }
        }
    }
}