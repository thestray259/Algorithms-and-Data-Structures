using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        public static void BubbleSort(T[] arr)
        {
            //arr[0].CompareTo(arr[1]) > 0 //this is how to compare 2 indexes when you don't know the data type 
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    //swap the values 
                    
                }
            }
        }

        public static void InsertionSort(T[] arr)
        {

        }

        public static void SelectionSort(T[] arr)
        {

        }
    }
}
