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

            while (true)
            {
                Console.Write("-Good Day,Please choose between the following numbers for your Sorting options - \n" +
                "1 : Bubble Sort \n" +
                "2 : Quick Sort \n" +
                "3 : Merge Sort \n" +
                "\n" +
                "-Or choose one of the folowing numbers for your Searching options - \n" +
                "4 :Linear Search \n" +
                "5 :Binary Search \n" +
                "\n" +
                "6 :Exit \n" +
                "\n" +
                "Please enter your choice:");
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
                        Console.WriteLine("PLEASE ENTER THE VALUE YOU ARE SEARCHING FOR ");
                        int z = Convert.ToInt32(Console.ReadLine());
                        bool answer = linearSearch(array, z);
                        if (answer)
                        {
                            Console.WriteLine("The value entered is found \n");
                        }
                        else
                        {
                            Console.WriteLine("The value entered is not found \n");
                        }
                        break;
                    case 5:
                        Console.WriteLine("PLEASE ENTER THE VALUE YOU ARE SEARCHING FOR ");
                        int v = Convert.ToInt32(Console.ReadLine());
                        if (BinarySearch(arr, 0, arr.Length, v) != -1)
                        {
                            Console.WriteLine("The value entered is found \n");
                        }
                        else
                        {
                            Console.WriteLine("The value entered is not found \n");
                        }


                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input,Number out of scope \n");
                        break;
                }

            }
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
        public static bool linearSearch(int[] a, int k)//START LINEAR SEARCH METHOD 
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == k)
                {
                    return true;
                }
            }
            return false;
        }//END OF LINEAR SEARCH METHOD
        public static int BinarySearch(int[] a, int l, int r, int itofind)//START OF BINARY SEARCH METHOD
        {
            if (l<= r)
            {
                int m = (l + r) / 2;
            if (a[m] == itofind) 
            {
                return itofind;
            }
 
            if (a[m] > itofind)
            {
            return BinarySearch(a, l, m - 1, itofind);
            }
                else
                {
    return BinarySearch(a, m + 1, r, itofind);
                }
 }
 return -1;
 }//END OF BINARY SEARCH METHOD
    }
}
