using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 9, 2, 7, 4, 3, 1, 5, 10, 6, 8 };
            int[] arr = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };


            Console.WriteLine("-Good Day,Please choose between the following numbers for your Sorting options - ");
            Console.WriteLine("1 : Bubble Sort");
            Console.WriteLine("2 : Quick Sort");
            Console.WriteLine("3 : Merge Sort");
            Console.WriteLine(" ");

            Console.WriteLine("-Or choose one of the folowing numbers for your Searching options - ");
           
            Console.WriteLine("4 :Linear Search");
            Console.WriteLine("5 :Binary Search");
            Console.WriteLine(" ");
            Console.WriteLine("Please enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    bubblesort(array);
                    break;
                case 2:
                    quicksort(array, 0, array.Length - 1);
                    displayArray(array);
                    break;
                case 3:
                    MergeSort(array, 0, array.Length - 1);
                    displayArray(array);
                    break;
                case 4:
                    
                    break;
                case 5:
                   
                    break;
                default:
                    Console.WriteLine("Invalid input,Number out of scope");
                    break;
            }
            Console.ReadKey();
        }
        public static void displayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}" + " ");
            }
        }
        public static void bubblesort(int[] array)// START BUBBLESORT METHOD
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int k = 0; k < array.Length - (1 + i); k++)
                {
                    if (array[k] > array[k + 1])
                    {
                        int holder = array[k + 1];
                        array[k + 1] = array[k];
                        array[k] = holder;
                    }
                }
            }
            displayArray(array);
        }//END OF BUBBLESORT METHOD

        public static void Swap(int[] array, int i, int k)//START QUICKSORT METHOD(S) 
        {
            int holder = array[i];
            array[i] = array[k];
            array[k] = holder;
        }
        private static int partition(int[] array, int l, int r)
        {
            int pivotposition = l;
            int pivot = array[l];
            for (int i = l + 1; i <= r; i++)
            {
                if (array[i] < pivot)
                {
                    pivotposition++;
                    Swap(array, pivotposition, i);
                }
            }
            Swap(array, pivotposition, l);
            return pivotposition;
        }
        private static void quicksort(int[] array, int l, int r)
        {
            if (l < r)
            {
                var pi = partition(array, l, r);
                quicksort(array, l, pi - 1);
                quicksort(array, pi + 1, r);
            }
        }//END OF QUICKSORT METHOD(S)
        private static void Merge(int[] a, int l, int m, int r)//START OF MERGE SORT METHOD
        {
            int i, j, k;
            int larraylength = m - l, rarraylength = r - m + 1;
            int[] left = new int[larraylength];
            int[] right = new int[rarraylength];
            for (i = 0; i<larraylength; i++)
            {
                left[i] = a[l + i];
            }
            for (i = 0; i<rarraylength; i++)
            {
            right[i] = a[m + i];
            }
            i = 0; j = 0; k = l;
            while (i < larraylength && j < rarraylength)
            {
                if (left[i] <= right[j])
                {
                    a[k++] = left[i++];
                }
                else
                {
                    a[k++] = right[j++];
                }
            }
            if (i == larraylength)
            {
                for (int ii = j; ii < rarraylength; ii++)
                {
                    a[k++] = right[ii];
                }
            }
            if (j == rarraylength)
            {
                for (int ii = i; ii < larraylength; ii++)
                {
                    a[k++] = left[ii];
                }
            }
        }
        private static void MergeSort(int[] a, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2 + 1;
                MergeSort(a, l, m - 1);
                MergeSort(a, m, r);
                Merge(a, l, m, r);
            }
        }//END OF MERGE SORT METHOD
    }
}
