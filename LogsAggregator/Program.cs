using System;
using System.Collections.Generic;

namespace LogsAggregator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int logs = Int32.Parse(Console.ReadLine());
            SortedDictionary<string, List<string>> users = new SortedDictionary<string, List<string>>();
            SortedDictionary<string, int> timeLogged = new SortedDictionary<string, int>();            
            for (int i = 0; i < logs; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (users.ContainsKey(input[1]))
                {
                    if (!users[input[1]].Contains(input[0]))
                    {
                        users[input[1]].Add(input[0]);
                    }
                    timeLogged[input[1]] += Int32.Parse(input[2]);
                }
                else
                {
                    users.Add(input[1], new List<string>(){input[0]});
                    timeLogged.Add(input[1], Int32.Parse(input[2]));
                }
            }

            foreach (KeyValuePair<string, List<string>> pair in users)
            {
                pair.Value.Sort();
                Console.WriteLine($"{pair.Key}: {timeLogged[pair.Key]} [{string.Join(", ", pair.Value)}]");
            }
        }
    }
}