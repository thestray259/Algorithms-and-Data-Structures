using System;
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

        private static void QuickSort(T[] arr, int left, int right)
        {
            int i = left;
            int j = right;

            var pivot = arr[left + (right - left) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                    i++;

                while (arr[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
                QuickSort(arr, left, j);

            if (i < right)
                QuickSort(arr, i, right);

            // MISSING STOP CASE 

            // split array 
            // keep going as long as start < end 
            // start -> (pivot - 1) gets left part
            // (pivot + 1) -> end gets right part 
        }

        public static int Partition(T[] arr, int start, int end) // needed for QuickSort 
        {
            T pivot = arr[start];
            int leftArrow = start;
            int rightArrow = end;
            T temp = default;

            while (leftArrow != rightArrow)
            {
                for (int i = arr.Length; i > arr.Length - 1; i--) // right arrow 
                {
                    // check if number is less than first arrow 
                    // swap numbers 
                    // pivot stays with original number 
                    // break out of loop 

                    //if (arr[i] < arr[pivot])
                    {

                    }

                    rightArrow--;
                }

                for (int j = 0; j < arr.Length - 1; j++) // left arrow 
                {
                    // check if number is greater than pivot 
                    // swap numbers 
                }
            }

            // find larger - left arrow - need seperate variable
            // find smaller - right arrow - need seperate variable
            // while arrows are not the same 
            // iterate right arrow -- 
            // check if number is less than first arrow 
            // swap numbers 
            // pivot stays with original number 
            // break out of loop 
            // iterate left arrow ++ 
            // check if number is greater than pivot 
            // swap numbers 

            // swap smaller and larger 
            //start == end ??? return start or end (they are pointing at the same thing)
            return start;
        }

        public static void MergeSort(T[] arr) // recursive
        {
            if (arr.Length > 1)
            {
                InternalMergeSort(arr); 
            } // else do not split array
        }

        private static T[] InternalMergeSort(T[] items)
        {
            int listLength = items.Length;

            if (listLength == 1)
            {
                return items;
            }

            int median = listLength / 2;

            T[] left = new T[median];
            T[] right = new T[listLength - median];
            Array.Copy(items, left, left.Length);
            Array.Copy(items, median, right, 0, right.Length);

            InternalMergeSort(left);
            InternalMergeSort(right);

            return Merge(items, left, right);
        }

        public static T[] Merge(T[] arr, T[] leftArr, T[] rightArr)
        {
            int leftIndex = 0;
            int rightIndex = 0;

            int leftLength = leftArr.Length;
            int rightLength = rightArr.Length;
            int totalItems = leftLength + rightLength;

            for (int targetIndex = 0; targetIndex < totalItems; targetIndex++)
            {
                if (leftIndex >= leftLength)
                {
                    arr[targetIndex] = rightArr[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= rightArr.Length)
                {
                    arr[targetIndex] = leftArr[leftIndex];
                    leftIndex++;
                }
                else if (leftArr[leftIndex].CompareTo(rightArr[rightIndex]) < 0)
                {
                    arr[targetIndex] = leftArr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[targetIndex] = rightArr[rightIndex];
                    rightIndex++;
                }
            }

            return arr;

            // iterate over left and right to find smallest 
            // place smallest in first available index in arr 
            // copy remaining non-empty array to original 
        }
    }
}
