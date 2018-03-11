using System;
using System.Collections.Generic;

namespace EmailFixer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> emailsDictionary = new Dictionary<string, string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0].ToLower()=="stop")
                {
                    break;
                }
                else
                {
                    string mail = Console.ReadLine();
                    if (!(mail.ToLower().EndsWith("us") || mail.ToLower().EndsWith("uk")))
                    {
                        emailsDictionary.Add(string.Join(" ", input), mail);
                    }              
                }
            }

            foreach (KeyValuePair<string,string> pair in emailsDictionary)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}