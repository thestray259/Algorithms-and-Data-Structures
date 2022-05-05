using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public int count;
        Node<T> firstNode = new Node<T>();
        Node<T> lastNode = new Node<T>();

        public Node<T> Head { get; set; }
        public int Count { get { return count; } } // done?

        public void Add(T v) // done? 
        {
            Node<T> first = Head; 
            while (first.Next != null)
            {
                first = first.Next; 
            }

            first.Next = new Node<T>(v); 
        }

        public void Insert(T val, int index) // done? 
        { 
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(); 
            }

            if (firstNode == null)
            {
                firstNode = lastNode = new Node<T>(val);
            }

            if (index == 0)
            {
                firstNode = new Node<T>(val, firstNode); 
            }
            else if (index == (count - 1))
            {
                lastNode = lastNode.Next = new Node<T>(val); 
            }
            else
            {
                Node<T> currentNode = firstNode; 

                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next; 
                }

                Node<T> newNode = new Node<T>(val, currentNode.Next);
                currentNode.Next = newNode; 
            }

            // N.Next = 1.Next; 
            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            // return list[index] 
            throw new NotImplementedException(); 
        } // do this 

        public object Remove() // do this 
        {
            throw new NotImplementedException(); 
        }

        public object RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (firstNode == null) Console.WriteLine("List cannot be empty. ");

            object removedItem = default; 
            if (index == 0) // remove from front 
            {
                removedItem = RemoveFromFront(); 
            }
            else if (index == (count - 1)) // remove from back
            {
                removedItem = RemoveFromBack(); 
            }
            else // remove stuff
            {
                Node<T> currentnode = firstNode; 

                for (int i = 0; i < index; i++)
                {
                    currentnode = currentnode.Next; 
                }
                removedItem = currentnode.Data;
                currentnode.Next = currentnode.Next.Next;
                count--;
            }

            return removedItem; 
        } // done?

        public object RemoveLast() // done? 
        {
            if (firstNode == null) Console.WriteLine("List is empty. ");

            object removedItem = lastNode.Data;
            if (firstNode == lastNode) firstNode = lastNode = null; 
            else
            {
                Node<T> currentNode = firstNode; 
                while (currentNode.Next != lastNode)
                {
                    currentNode = currentNode.Next; 
                }
                lastNode = currentNode;
                currentNode.Next = null; 
            }

            count--;
            return removedItem; 
        }

        public override string ToString()
        {
            if (firstNode == null) return string.Empty;

            StringBuilder returnString = new StringBuilder(); 
            foreach (T item in this)
            {
                if (returnString.Length > 0) returnString.Append(", ");
                returnString.Append(item); 
            }

            return returnString.ToString(); 
        } // done? 

        public void Clear() // done? 
        {
            firstNode = lastNode = null;
            count = 0; 
        }

        public object Search(T val)
        {
            SingleLinkedList<T> list = new SingleLinkedList<T>(); 
            Node<T> currentNode = firstNode; 

            for (int i = 0; i < count - 1; i++)
            {
                // if index at i == val, return i 
            }

            return -1; 
        } // do this 

        // helper guys 

        public object RemoveFromFront()
        {
            object removedItem = firstNode.Data;
            if (firstNode == lastNode) firstNode = lastNode = null;
            else firstNode = firstNode.Next;

            count--;
            return removedItem; 
        }

        public object RemoveFromBack()
        {
            object removedItem = lastNode.Data;

            if (firstNode == lastNode) firstNode = lastNode = null; 
            else
            {
                Node<T> currentNode = firstNode; 

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next; 
                }

                lastNode = currentNode;
                currentNode.Next = null; 
            }

            count--;
            return removedItem; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = firstNode; 

            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next; 
            }
        }
    }
}
