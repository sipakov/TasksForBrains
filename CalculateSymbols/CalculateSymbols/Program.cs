using System;
using System.Collections.Generic;

namespace CalculateSymbols
{
    class Program
    {
      
        static Dictionary<char, int> getCount(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]]++;
                }

            }
            return dict;
        }
        static void Main(string[] args)
        {
            string s = "abcddcaaa";
           var result = getCount(s);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
                
            }
            Console.ReadLine();
        }
    }
}
