using System;
using System.Collections.Generic;

namespace Anagram
{
    class MainClass
    {
        public static bool IsPrime(int number)
        {
            if (number == 1)
                return true;
            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;
            return true;
        }

        public static int[] GetPrimes(int n)
        {
            int[] primes = new int[n];
            int number = 2;
            int cnt = 0;
            while (cnt < n)
            {
                if (IsPrime(number))
                    primes[cnt++] = number;
                number++;
            }
            return primes;
        }

        // build dictionary mapping any alphabet character to a prime
        public static Dictionary<char, int> GetCharToPrime(int[] primes)
        {
            var d = new Dictionary<char, int>();
            int i = 0;
            for (char c = 'a'; c <= 'z'; c++)
                d.Add(c, primes[i++]);
            return d;
        }

        // represent a word as a multiplication of character primes (unique!)
        public static int WordToCode(Dictionary<char, int> dict, String s)
        {
            int code = 1;
            foreach (char c in s)
                code *= dict[c];
            return code;
        }

        public static bool CheckAnagram(Dictionary<char, int> dict, String s1, String s2)
        {
            if (s1.Length != s2.Length)
                return false;

            int code1 = WordToCode(dict, s1);
            int code2 = WordToCode(dict, s2);

            if (code1 == code2)
                return true;

            return false;
        }

        public static void Main(string[] args)
        {
            // generate 26 primes
            int[] primes = GetPrimes(26);

            // build char -> prime dictionary
            var dict = GetCharToPrime(primes);

            Console.Write("First word: ");
            String s1 = Console.ReadLine();

            Console.Write("Second word: ");
            String s2 = Console.ReadLine();

            if (CheckAnagram(dict, s1, s2))
                Console.WriteLine("\nSUCCESS: Anagram match detected!");
            else
                Console.WriteLine("\nFAIL: Anagram mismatch detected!");
        }
    }
}
