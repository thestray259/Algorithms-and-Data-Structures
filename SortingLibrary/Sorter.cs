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
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        //swap the values 

                    }
                }                
            }
        }

        public static void InsertionSort(T[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                // need to pull out number that is being compared to others and track it 
                // if switches, the number it switched with overwrites the original number 
                // stable swap, means if number is equal to number it's being compared to, don't swap 
                for (int j = 0; j < arr.Length; j++)
                {

                }
            }
        }

        public static void SelectionSort(T[] arr)
        {

        }
    }
}
