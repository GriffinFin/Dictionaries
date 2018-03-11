using System;
using System.Collections.Generic;

namespace DragonQuest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, int[]>> dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            int n = Int32.Parse(Console.ReadLine());
            int dmg = 0;
            int arm = 0;
            int hp = 0;
            for (int i = 0; i < n; i++)
            {
                string[] dragon = Console.ReadLine().Split(' ');
                string type = dragon[0];
                string name = dragon[1];
                try
                {
                    dmg = Int32.Parse(dragon[2]);
                }
                catch (Exception e)
                {
                    dmg = 45;
                }

                try
                {
                    hp = Int32.Parse(dragon[3]);
                }
                catch (Exception e)
                {
                    hp = 250;
                }

                try
                {
                    arm = Int32.Parse(dragon[4]);
                }
                catch (Exception e)
                {
                    arm = 10;
                }
                if (dragons.ContainsKey(type))
                {
                    if (dragons[type].ContainsKey(name))
                    {
                        dragons[type][name][0] = dmg;
                        dragons[type][name][1] = hp;
                        dragons[type][name][2] = arm;                        
                    }
                    else
                    {
                        dragons[type].Add(name, new []{dmg, hp, arm});
                    }
                }
                else
                {
                    dragons.Add(type, new SortedDictionary<string, int[]>()
                    {
                        {name, new []{dmg, hp, arm}}
                    });
                }
            }

            foreach (var type in dragons)
            {
                double hpAv = 0;
                double armAv = 0;
                double dmgAv = 0;
                int count = type.Value.Count;
                foreach (var stats in type.Value)
                {
                    dmgAv += stats.Value[0];
                    hpAv += stats.Value[1];
                    armAv += stats.Value[2];
                }

                Console.WriteLine($"{type.Key}::({(dmgAv/count):f2}/{(hpAv/count):f2}/{(armAv/count):f2})");
                foreach (KeyValuePair<string,int[]> dragonPair in type.Value)
                {
                    Console.WriteLine($"-{dragonPair.Key} -> damage: {dragonPair.Value[0]}, health: {dragonPair.Value[1]}, armor: {dragonPair.Value[2]}");
                }
            }
        }
    }
}