using System;
using System.Collections.Generic;

namespace Phonebook
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(' ');
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
            while (true)
            {
                if (command[0].ToLower() == "end")
                {
                    break;
                }
                
                switch (command[0].ToLower())
                {
                        case "a":
                            if (phonebook.ContainsKey(command[1]))
                            {
                                phonebook[command[1]] = command[2];
                            }
                            else
                            {
                                phonebook.Add(command[1], command[2]);
                            }
                            break;
                        case "s":
                            string number;
                            if (phonebook.TryGetValue(command[1], out number))
                            {
                                Console.WriteLine($"{command[1]} -> {number}");
                            }
                            else
                            {
                                Console.WriteLine($"Contact {command[1]} does not exist.");
                            }
                            break;
                        case "listall":
                            foreach (KeyValuePair<string,string> pair in phonebook)
                            {
                                Console.WriteLine($"{pair.Key} -> {pair.Value}");
                            }
                            break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}