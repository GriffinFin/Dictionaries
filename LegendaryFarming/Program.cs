using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>()
            {
                {"fragments", 0},
                {"shards", 0},
                {"motes", 0}
            };
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            bool poorBastard = true;
            while (poorBastard)
            {
                string[] currentFarm = Console.ReadLine().Split(' ');
                for (int i = 1; i <=currentFarm.Length; i+=2)
                {
                    if (keyMaterials.ContainsKey(currentFarm[i].ToLower()))
                    {
                        keyMaterials[currentFarm[i].ToLower()] += Int32.Parse(currentFarm[i-1]);
                        if (keyMaterials["fragments"] >= 250)
                        {
                            keyMaterials["fragments"] -= 250;
                            Console.WriteLine("Valanyr obtained!");
                            poorBastard = false;
                            break;
                        }
                        else if (keyMaterials["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keyMaterials["shards"] -= 250;
                            poorBastard = false;
                            break;
                        }
                        else if(keyMaterials["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keyMaterials["motes"] -= 250;
                            poorBastard = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(currentFarm[i].ToLower()))
                        {
                            junk[currentFarm[i].ToLower()] += Int32.Parse(currentFarm[i-1]);
                        }
                        else
                        {
                            junk.Add(currentFarm[i].ToLower(), Int32.Parse(currentFarm[i-1]));
                        }
                    }
                }
            }

            var sortedItems = keyMaterials.OrderByDescending(x => x.Value).Take(3);
            foreach (KeyValuePair<string,int> item in sortedItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");               
            }
        }
    }
}