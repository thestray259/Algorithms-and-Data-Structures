﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        //"A".CompareTo("B")   -1 PROCEEDS 
        //"B".CompareTo("A")   +1 FOLLOWS 
        //"B".CompareTo("B")    0 SAME 

        public static void BubbleSort(T[] arr)
        {
            T temp; 
            //arr[0].CompareTo(arr[1]) > 0 //this is how to compare 2 indexes when you don't know the data type 
            for (int i = arr.Length; i >= 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        //swap the values 
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp; 
                    }
                }                
            }
        }

        public static void InsertionSort(T[] arr)
        {
            T temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {                
                // need to pull out number that is being compared to others and track it 
                // if switches, the number it switched with overwrites the original number 
                // stable swap, means if number is equal to number it's being compared to, don't swap 
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp; 
                    }
                }
            }
        }

        public static void SelectionSort(T[] arr)
        {
            T temp;            
            for (int i = 0; i < arr.Length; i++)
            {
                T lowestValue = arr[i];
                int minLocation = i; 
                for (int j = i + 1; j < arr.Length; j++)
                {
                    // loops through and finds the smallest number 
                    // swaps the smallest number with the number of the index it's on (arr[i]) 

                    if (arr[j].CompareTo(lowestValue) < 0)
                    {
                        lowestValue = arr[j];
                        minLocation = j; 
                    }                    
                }

                if (minLocation != i)
                {
                    temp = arr[minLocation];
                    arr[minLocation] = arr[i];
                    arr[i] = temp; 
                }
            }
        }

        public static void QuickSort(T[] arr) // recursive 
        {
            QuickSort(arr, 0, arr.Length - 1); 
        }

        private static void QuickSort(T[] arr, int start, int end)
        {
            int pivotIndex = Partition(arr, start, end); 

            // MISSING STOP CASE 

            // split array 
            // keep going as long as start < end 
            // start -> (pivot - 1) gets left part
            // (pivot + 1) -> end gets right part 
        }

        public static int Partition(T[] arr, int start, int end) // needed for QuickSort 
        {
            T pivot = arr[start];

            // find larger 
            // find smaller 
            // swap smaller and larger 
            //start == end ??? return start or end (they are pointing at the same thing)

            return 0; 
        }

        public static void MergeSort(T[] arr) // recursive
        {
            if (arr.Length > 1)
            {
                // split (recursive) 
                // arrLeft = arr.Length / 2 
                // arrRight arr.Length - (arr.Length / 2) 
                // copy data from arr to split arrays 

                //MergeSort(arrLeft); 
                //MergeSort(arrRight); 

                //Merge(arr, arrLeft, arrRight); 
            } // else do not split array

        }

        public static void Merge(T[] arr, T[] leftArr, T[] rightArr)
        {
            // iterate over left and right to find smallest 
            // place smallest in first available index in arr 
            // copy remaining non-empty array to original 
        }
    }
}
