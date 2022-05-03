using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public int Count { get; set; } // do this 

        public void Add(T v)
        {
            //

            //Node<T> first = Head; 
            //while (first.Next != null)
            //{
            //    first = first.Next; 
            //}

            //first.Next = new Node<T>(v); 
        } // do this

/*        public T Get(int v)
        {
            if (v < 0 || v >= Count)
            {
                throw new IndexOutOfRangeException(); 
            }
        }*/ // do this 

        public void Insert(T val, int index) // do this 
        {
            // N.Next = 1.Next; 

        }

        public override string ToString()
        {
            return base.ToString();
        } // do this 
    }
}
