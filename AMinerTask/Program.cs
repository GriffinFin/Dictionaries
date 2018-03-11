using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower()== "stop")
                {
                    break;
                }
                else
                {
                    int ammount = int.Parse(Console.ReadLine());
                    if (resources.ContainsKey(command))
                    {
                        resources[command] += ammount;
                    }
                    else
                    {
                        resources.Add(command, ammount);
                    }
                }
            }

            foreach (KeyValuePair<string,int> pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}