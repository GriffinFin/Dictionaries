using System;
using System.Linq;

namespace ShortWordsSorted
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[] delims = new[] {'.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '/', '\\', '!', '?', ' '};
            string[] array = Console.ReadLine().ToLower().Split(delims);
            var result = array.Where(w => w != "").Where(w => w.Length < 5).OrderBy(w => w).Distinct();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}