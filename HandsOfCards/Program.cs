using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandsOfCards
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> cardValues = new Dictionary<string, int>()
            {
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
                {"10", 10},
                {"J", 11},
                {"Q", 12},
                {"K", 13},
                {"A", 14}
            };
            Dictionary<char, int> cardColors = new Dictionary<char, int>()
            {
                {'S', 4}, {'H', 3}, {'D', 2}, {'C', 1}
            };            
            Dictionary<string, List<string>> playerCards = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(':');
            char[] delims = new[] {',', ' '};
            while (input[0]!="JOKER")
            {
                string[] cardDraw = input[1].Split(delims, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();                
                if (playerCards.ContainsKey(input[0]))
                {
                    playerCards[input[0]].Concat(cardDraw.ToList());
                }
                else
                {
                    playerCards.Add(input[0], cardDraw.ToList());
                }

                input = Console.ReadLine().Split(':');
            }

            foreach (KeyValuePair<string,List<string>> pair in playerCards)
            {
                int sumCards = 0;
                foreach (var card in pair.Value)
                {
                    char color = card[card.Length - 1];
                    string value = card.Remove(card.Length - 1, 1);
                    sumCards += cardColors[color] * cardValues[value];
                }

                Console.WriteLine($"{pair.Key}: {sumCards}");
            }
        }
    }
}