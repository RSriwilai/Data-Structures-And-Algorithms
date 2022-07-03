using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data_Structures_And_Algorithm.Helpers;

namespace Data_Structures_And_Algorithm.SortingAlgorithms
{
    public class Sorting : ConsoleReadKeyClearBehavior
    {
        public static void ShowSortingMenu()
        {
            Console.WriteLine("***SORTING ALGORITHMS***\n\nChoose an option from the menu below:\n");
            foreach (KeyValuePair<int, string> option in BasicExerciseMenuOptions)
                Console.WriteLine($"{option.Key}.) {option.Value}");
            Console.WriteLine();
            NavigateUsersRequest();
        }

        private static readonly Dictionary<int, string> BasicExerciseMenuOptions = new Dictionary<int, string>()
        {
            { 1, "Execute BubblerSort" },
            { 2, "Execute SelectionSort" },
            { 3, "Execute InsertionSort" },
            { 4, "Execute ShellSort" },
            { 5, "Execute MergeSort" },
            { 6, "Execute QuickSort" },
            { 7, "Go Back to Main Menu" }
        };

        private static void NavigateUsersRequest()
        {
            int[] array = { 9, 1, 8, 2, 7, 3, 6, 4, 5, 10 };
            int request = (int)GetUsersRequest(0);
            Console.Clear();
            switch (request)
            {
                case 1:
                    BubbleSort(array);
                    break;
                case 2:
                    SelectionSort(array);
                    break;
                case 3:
                    InsertionSort(array);
                    break;
                case 4:
                    ShellSort(array);
                    break;
                case 5:
                    MergeSort(array);
                    break;
                case 6:
                    QuickSort(array);
                    break;
                case 7:
                    Program.Main(new string[] { });
                    break;
                default:
                    Console.Clear();
                    ReadKeyAndClear();
                    ShowSortingMenu();
                    break;
            }
            if (Program.ReturnToMainMenu)
                Program.Main(new string[] { });
            else
                ShowSortingMenu();
        }

        private static object GetUsersRequest(int attempts)
        {
            if (attempts > 0)
            {
                Console.WriteLine("\nYour input is invalid. Try again.\n");
                ReadKeyAndClear();
                ShowSortingMenu();
            }
            int request = 0;
            if (int.TryParse(Console.ReadLine(), out request) && BasicExerciseMenuOptions.Keys.Contains(request))
                return request;
            return GetUsersRequest(++attempts);
        }

        private static void DisplayNumbers(int[] arr)
        {
            foreach (var i in arr)
            {
                Thread.Sleep(50);
                Console.Write(i);
            }
            ReadKeyAndClear();
        }

        private static void BubbleSort(int[] arr)
        {
            Console.WriteLine("BubbleSort");
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--) // Wall starts from the last index of array: If wall is larger than 0: decrease.
            {
                for (int i = 0; i < partIndex; i++) // Inner iterator starts from array index 0: If iterator is smaller than partIndex: increase.  
                {
                    if (arr[i] > arr[i + 1]) // If left hand element is larger than right hand element
                    {
                        Swap(arr, i, i + 1); // Swap
                    }
                }
            }
            DisplayNumbers(arr);
        }

        private static void SelectionSort(int[] arr)
        {
            Console.WriteLine("SelectionSort");
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--) // Wall starts fromm the last index of array: If wall is larger than 0: decrease.
            {
                int largestAt = 0; // Declear largestAt variable.
                for (int i = 1; i <= partIndex; i++) // Inner iterator starts array index 1: If array index is less or equal the wall: increase.
                {
                    if (arr[i] > arr[largestAt]) // If array element is larger than largestAt element on the left hand side if the wall.
                    {
                        largestAt = i; // Initialize i to largest at.
                    }
                }
                Swap(arr, largestAt, partIndex); // Swap.
            }
            DisplayNumbers(arr);
        }

        private static void InsertionSort(int[] arr)
        {
            Console.WriteLine("InsertionSort");
            // All the elements from the left side are considered sortet and the right side is unsorted.
            for (int partIndex = 1; partIndex < arr.Length; partIndex++) //Wall that start at index 1: If Wall is smaller than array length: Increase.
            {
                int curUnsorterd = arr[partIndex]; //Save the current Unsorted in a variable.
                int i = 0; //Iterator variable.
                //Starts from partIndex and progress until we reach the beginning of the array or facing an element at arr[i -1] which is less or equal to the curUnsorted.
                for (i = partIndex; i > 0 && arr[i - 1] > curUnsorterd; i--)
                {
                    arr[i] = arr[i - 1]; //Shift.
                }
                arr[i] = curUnsorterd; //Insert the curUnsorted into arr element.
            }
            DisplayNumbers(arr);
        }

        public static void ShellSort(int[] arr)
        {
            Console.WriteLine("ShellSort");

            int gap = 1;
            while (gap < arr.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    for (int j = i; j >= gap && arr[j] < arr[j - gap]; j -= gap)
                    {
                        Swap(arr, j, j - gap);
                    }
                }

                gap /= 3;
            }
            DisplayNumbers(arr);
        }

        public static void MergeSort(int[] arr)
        {
            Console.WriteLine("MergeSort");
            int[] aux = new int[arr.Length];
            Sort(0, arr.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;

                int mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid + 1, high);
                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                int i = low;
                int j = mid + 1;


                Array.Copy(arr, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if (i > mid) arr[k] = aux[j++];
                    else if (j > high) arr[k] = aux[i++];
                    else if (aux[j] < aux[i]) arr[k] = aux[j++];
                    else arr[k] = aux[i++];
                }
            }
            DisplayNumbers(arr);
        }

        public static void QuickSort(int[] arr)
        {
            Console.WriteLine("QuickSort");
            Sort(0, arr.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low) return;

                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;
                int pivot = arr[low];

                while (true)
                {
                    while (arr[++i] < pivot)
                    {
                        if (i == high) break;
                    }

                    while (pivot < arr[--j])
                    {
                        if (j == low) break;
                    }

                    if (i >= j) break;
                    Swap(arr, i, j);
                }
                Swap(arr, low, j);
                return j;
            }
            DisplayNumbers(arr);

        }

        private static void Swap(int[] arr, int i, int j)
        {
            if (arr[i] == arr[j])
                return;

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

    }
}
