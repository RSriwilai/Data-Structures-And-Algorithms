using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm.SortingAlgorithms
{
    public class SortingExercise
    {
        public static void BubbleSort(int[] arr)
        {
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (arr[i] > arr[i + 1]) Swap(arr, i, i + 1);
                }
            }
        }

        public static void SelectionSort(int[] arr)
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

        public static void InsertionSort(int[] arr)
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

        public static void ShellSort(int[] arr)
        {
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
        }

        public static void MergeSort(int[] arr)
        {
            int[] aux = new int[arr.Length];
            Sort(0, arr.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low) return;

                int mid = (low + high) / 2;
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
        }

        public static void QuickSort(int[] arr)
        {
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
                        if(i == high) break;
                    }

                    while (pivot < arr[--j])
                    {
                        if(j == low) break;
                    }

                    if(i >= j) break;
                    Swap(arr, i, j);
                }
                Swap(arr, low, j);
                return j;
            }
        }

        public static void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}
