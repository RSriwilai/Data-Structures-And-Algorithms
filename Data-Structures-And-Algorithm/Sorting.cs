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
            for (int partIndex = arr.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                    }
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
                    {
                        largestAt = i;
                    }
                }
                Swap(arr, largestAt, partIndex);
            }
        }

        public static void InsertionSort(int[] arr)
        {
            //all the elements from the left side are considered sortet and the right side is unsorted
            for (int partIndex = 1; partIndex < arr.Length; partIndex++)
            {
                int curUnsorterd = arr[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && arr[i - 1] > curUnsorterd; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[i] = curUnsorterd;
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

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
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
