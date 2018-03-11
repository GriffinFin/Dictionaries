using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TheCancerOne
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> venues = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                Match m = Regex.Match(input, @"([A-Za-z ]+) (@[A-Za-z ]+) (\d+) (\d+)");
                    if (m.Success)
                    {
                        string performer = m.Groups[1].ToString();
                        string venue = m.Groups[2].ToString().Remove(0, 1);
                        int price = Int32.Parse(m.Groups[3].ToString());
                        int count = Int32.Parse(m.Groups[4].ToString());
                        if (venues.ContainsKey(venue))
                        {
                            if (venues[venue].ContainsKey(performer))
                            {
                                venues[venue][performer] += price * count;
                            }
                            else
                            {
                                venues[venue].Add(performer, price*count);
                            }
                        }
                        else
                        {
                            venues.Add(venue, new Dictionary<string, long>(){{performer, price*count}});
                        }
                    }

                input = Console.ReadLine();
            }
            
            foreach (var pair in venues)
            {
                Console.WriteLine(pair.Key);
                var ordered = venues[pair.Key].OrderByDescending(x => x.Value).Take(venues[pair.Key].Count);
                foreach (var singer in ordered)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}