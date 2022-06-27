using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_And_Algorithm
{
    public class Sorting
    {
        public static void BubbleSort(int[] arr)
        {
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
        }

        public static void SelectionSort(int[] arr)
        {
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
        }

        public static void InsertionSort(int[] arr)
        {
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
        }

        public static void ShellSort(int[] arr)
        {
            int gap = 1;
            while (gap < arr.Length / 3)
                gap = 3 * gap + 1;

            while(gap >= 1)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    for (int j = i; j >= gap && arr[j] < arr[j -gap]; j -= gap)
                    {
                        Swap(arr, j, j - gap);
                    }
                }

                gap /= 3;
            }
        }


        public static void BubbleSorter(int[] arr)
        {
            for (int partIndex = arr.Length-1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i+1);
                    }
                }
            }
        }

        public static void SelectionSorter(int[] arr)
        {
            for (int partIndex = arr.Length-1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (arr[i] > arr[largestAt])
                    {
                        largestAt = i;
                    }
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
                for (i = partIndex; i > 0 && arr[i -1] > curUnsorted; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[i] = curUnsorted;
            }
        }

        public static void ShellSorter(int[] arr)
        {
            int gap = 1;
            while(gap < arr.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    for (int j = i; j >= gap && arr[j] < arr[j-gap]; j-=gap)
                    {
                        Swap(arr, j, j-gap);
                    }
                }
                gap /= 3;
            }
        }

        public static void MergeSorter(int[] arr)
        {
            int[] aux = new int[arr.Length];
            Sort(0, arr.Length - 1);

            void Sort(int low, int high)
            {
                if(high <= low)
                    return;

                int mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid+1, high);
                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                int i = low;
                int j = mid + 1;


                Array.Copy(arr, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if(i > mid) arr[k] = aux[j++];
                    else if(j > high) arr[k] = aux[i++];
                    else if (aux[j] < aux[i]) arr[k] = aux[j++];
                    else arr[k] = aux[i++];
                }
            }
        }


        public static void Swap(int[] arr, int i, int j)
        {
            if(arr[i] == arr[j])
                return;

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

    }
}
