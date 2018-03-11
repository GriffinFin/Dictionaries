using System;
using System.Collections.Generic;
using System.Linq;

namespace Population
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> population = new Dictionary<string, long>();
            string[] input = Console.ReadLine().Split('|');
            while (input[0]!= "report")
            {
                if (countries.ContainsKey(input[1]))
                {
                    if (countries[input[1]].ContainsKey(input[0]))
                    {
                        countries[input[1]][input[0]] += Int64.Parse(input[2]);
                    }
                    else
                    {
                        countries[input[1]].Add(input[0], Int64.Parse(input[2]));
                    }
                    population[input[1]] += Int64.Parse(input[2]);
                }
                else
                {
                    countries.Add(input[1], new Dictionary<string, long>(){{input[0], Int64.Parse(input[2])}});
                    population.Add(input[1], Int64.Parse(input[2]));
                }

                input = Console.ReadLine().Split('|');
            }

            var sortedPopulation = population.OrderByDescending(x => x.Value).Take(population.Count);
            foreach (KeyValuePair<string,long> pair in sortedPopulation)
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value})");
                var sortedCountry = countries[pair.Key].OrderByDescending(x => x.Value).Take(countries[pair.Key].Count);
                foreach (KeyValuePair<string,long> town in sortedCountry)
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }
        }
    }
}