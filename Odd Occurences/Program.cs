using System;
using System.Collections.Generic;

namespace Odd_Occurences
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (var word in input)
            {
                if (counter.ContainsKey(word.ToLower()))
                {
                    counter[word.ToLower()]++;
                }
                else
                {
                    counter[word.ToLower()] = 1;
                }
            }

            List<string> keys = new List<string>();
            foreach (var key in counter.Keys)
            {
                if (counter[key]%2!=0)
                {
                    keys.Add(key);
                }
            }

            Console.WriteLine(string.Join(", ", keys));
        }
    }
}