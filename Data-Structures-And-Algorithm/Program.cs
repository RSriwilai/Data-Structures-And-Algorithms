using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Data_Structures_And_Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 9, 1, 8, 2, 7, 3, 6, 4, 5, 10 };

            Sorting.Insertion(array);
            foreach (int i in array)
            {
                Thread.Sleep(250);
                Console.Write(i);
            }

            //Console.WriteLine(Sorting.IterativeFactorial(5));
            //Console.WriteLine(Sorting.RecursionFactorial(55));
        }

        public static bool IsPalindrome(string input)
        {
            string str = RemoveNonAlphanumericCharacter(input.ToLower());
            if (str == "")
                return true;

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }

        private static string RemoveNonAlphanumericCharacter(string str)
        {
            str = Regex.Replace(str, "[^a-zA-Z0-9]", String.Empty);
            Console.WriteLine(str);
            return str;
        }
    }
}
