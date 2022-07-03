using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm.SortingAlgorithms
{
    public class SortingExercise
    {
        public static void BubbleSorter(int[] arr)
        {
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                }
            }
        }

        public static void SelectionSorter(int[] arr)
        {
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (arr[i] > arr[largestAt])
                        largestAt = i;
                }
                Swap(arr, largestAt, partIndex);
            }
        }

        public static void InsertionSorter(int[] arr)
        {
            for (int partIndex = 1; partIndex < arr.Length; partIndex++)
            {
                int curUnsorted = arr[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && arr[i - 1] > curUnsorted; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[i] = curUnsorted;
            }
        }

        public static void ShellSorter(int[] arr)
        {

        }

        public static void MergeSorter(int[] arr)
        {

        }

        public static void QuickSorter(int[] arr)
        {

        }



        private static void Swap(int[] arr, int i, int j)
        {
            if (arr[i] == arr[j])
                return;

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}
