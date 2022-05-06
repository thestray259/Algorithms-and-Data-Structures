using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public int count;
        Node<T> firstNode = null;
        Node<T> lastNode = null;

        public Node<T> Head { get; set; }
        public int Count { get { return count; } } // done?

        public void Add(T v) // sorts 
        {
            InsertBack(v); // work to be done in here I think 

            if (Head == null && firstNode != null) Head = firstNode;  
        }

        public void Insert(T val, int index) // needs work  
        {
            if (Head == null && firstNode != null) Head = firstNode;

            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (index == 0) InsertFront(val);
            else if (index == (count - 1)) InsertBack(val); 
            else
            {
                Node<T> currentNode = firstNode;

                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }

                Node<T> newNode = new Node<T>(val, currentNode.Next);
                currentNode.Next = newNode;
                count++; 
            }
        }

        public T Get(int index)
        {
            Node<T> current = Head;
            int nodeIndex = 0;
            T doesNotExist = default;

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            while (current != null)
            {
                if (nodeIndex == index) return current.Data;
                nodeIndex++;
                current = current.Next; 
            }

            Debug.Assert(false);
            return doesNotExist; 
        } // works

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
                removedItem = RemoveFront(); 
            }
            else if (index == (count - 1)) // remove from back
            {
                removedItem = RemoveBack(); 
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
        } // needs work 

        public object RemoveLast() // needs work 
        {
            if (firstNode == null) Console.WriteLine("List is empty. ");

            return RemoveBack(); 
        }

        public override string ToString()
        {
            if (Count == 0) return "";
            Node<T> current = Head; 

            string returnString = "";

            //if (Count == 1) returnString += current.Data; 

            while (current != null)
            {
                if (returnString.Length > 0) returnString += ", ";
                returnString += current.Data;

                current = current.Next; 
            }

            return returnString.ToString(); 
        } // should work now, definitely works for adding numbers 

        public void Clear() // done? 
        {
            firstNode = lastNode = null;
            count = 0; 
        }

        public int Search(T val)
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

        public void InsertFront(T value)
        {
            if (firstNode == null) firstNode = lastNode = new Node<T>(value);
            else firstNode = new Node<T>(value, firstNode);
            count++; 
        }

        public void InsertBack(T value) // works now 
        {
            if (firstNode == null) firstNode = lastNode = new Node<T>(value);
            else if (lastNode == null) lastNode = lastNode.Next = new Node<T>(value);
            else
            {
                Node<T> newNode = new Node<T>(value); 
                Node<T> currentNode = Head;

                newNode.Next = null; 

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode; 
                lastNode = lastNode.Next = newNode;
            }
            count++;
        }

        public object RemoveFront()
        {
            object removedItem = firstNode.Data;
            if (firstNode == lastNode) firstNode = lastNode = null;
            else firstNode = firstNode.Next;

            count--;
            return removedItem; 
        }

        public object RemoveBack()
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
            return lastNode; 
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
