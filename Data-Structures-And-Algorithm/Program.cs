using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Data_Structures_And_Algorithm
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 9, 1, 8, 2, 7, 3, 6, 4, 5, 10 };

            Sorting.MergeSorter(array);
            foreach (int i in array)
            {
                Thread.Sleep(50);
                Console.Write(i);
            }
            
        }
    }
}
