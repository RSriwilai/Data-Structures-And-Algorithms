using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm
{
    public class RandomCodingProblems
    {

        public static void NASARocketCounterRecursion(int num)
        {
            if (num == 0)
                return;

            Console.Write(num);
            NASARocketCounterRecursion(num - 1);
        }

        public static void NASARocketCounter(int num)
        {
            for (int i = num; i > 0; i--)
            {
                Console.Write(i);
            }
        }

        public static bool SubsetChecker<T>(T[] arr1, T[] arr2) where T : IComparable
        {
            T[] smallestArray;
            T[] largestArray;

            if (arr1.Length.CompareTo(arr2.Length) >= 0)
            {
                largestArray = arr1;
                smallestArray = arr2;
            }
            else
            {
                largestArray = arr2;
                smallestArray = arr1;
            }

            var dic = new Dictionary<T, bool>();
            foreach (var b in largestArray)
            {
                dic.Add(b, true);
            }

            foreach (var b in smallestArray)
            {
                if (!dic.ContainsKey(b)) return false;
            }

            return true;
        }

        public static void SumOfEvenNums(int[] arr)
        {
            if (arr == null)
                return;

            int sumEvenNumbers = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    sumEvenNumbers += arr[i];
                }
            }
            Console.WriteLine(sumEvenNumbers);
        }

        public static bool IsPalindromeInt(int x)
        {
            if (x < 0)
                return false;

            int[] arr = x.ToString().Select(x => Convert.ToInt32(x) - 48).ToArray();
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                    return false;
            }
            return true;
        }

        public static bool IsPalindromeString(string input)
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

        public static int IterativeFactorial(int num)
        {
            if (num == 0)
                return 1;

            int factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static long RecursionFactorial(long n)
        {
            if (n == 0)
                return 1;

            return n * RecursionFactorial(n - 1);
        }
    }
}
