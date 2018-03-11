using System;
using System.Collections.Generic;

namespace UserLogs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> userLog = new SortedDictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "end")
            {
                string[] ip = input[0].Split('=');
                string[] user = input[2].Split('=');
                if (userLog.ContainsKey(user[1]))
                {
                    if (userLog[user[1]].ContainsKey(ip[1]))
                    {
                        userLog[user[1]][ip[1]] += 1;
                    }
                    else
                    {
                        userLog[user[1]].Add(ip[1], 1);
                    }
                }
                else
                {
                    userLog.Add(user[1], new Dictionary<string, int>());
                    if (userLog[user[1]].ContainsKey(ip[1]))
                    {
                        userLog[user[1]][ip[1]] += 1;
                    }
                    else
                    {
                        userLog[user[1]].Add(ip[1], 1);
                    }
                }

                input = Console.ReadLine().Split(' ');
            }
            foreach (KeyValuePair<string,Dictionary<string,int>> pair in userLog)
            {
                Console.WriteLine(pair.Key+": ");
                bool first = true;
                foreach (KeyValuePair<string,int> ipAdress in pair.Value)
                {
                    if (first)
                    {
                        Console.Write($"{ipAdress.Key} => {ipAdress.Value}");
                        first = false;
                    }
                    else
                    {
                        Console.Write($", {ipAdress.Key} => {ipAdress.Value}");
                    }
                }
                Console.WriteLine(".");
            }
        }
    }
}