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
        Node<T> firstNode = null;
        Node<T> lastNode = null;

        public Node<T> Head { get; set; }
        public int Count { get { return count; } } // done?

        public void Add(T v) // done? 
        {
            InsertBack(v); 

            if (Head == null && firstNode != null) Head = firstNode;  
            /*Node<T> first = Head; 
            while (first.Next != null)
            {
                first = first.Next; 
            }

            first.Next = new Node<T>(v); */
        }

        public void Insert(T val, int index) // done? 
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
        } // done?

        public object RemoveLast() // done? 
        {
            if (firstNode == null) Console.WriteLine("List is empty. ");

            return RemoveBack(); 
        }

        public override string ToString()
        {
            if (Count == 0) return "";
            Node<T> current = Head; 

            string returnString = "";
            /*            foreach (T item in this) // only returns 0
                        {
                            if (returnString.Length > 0) returnString.Append(", ");
                            returnString.Append(item); 
                        }*/

            /*            for (int i = 0; i < this.Count; i++) // cannot index linked list, so only prints the indexes and not the values 
                        {
                            if (returnString.Length > 0) returnString.Append(", ");
                            returnString.Append(i);
                        }*/

            if (Count == 1) returnString += current.Data; 

            while (current.Next != null)
            {
                if (returnString.Length > 0) returnString += ", ";
                returnString += current.Data;

                current = current.Next; 
            }

            return returnString.ToString(); 
        } // item isn't the value, so string is printing wrong 

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

        public void InsertFront(T value)
        {
            if (firstNode == null) firstNode = lastNode = new Node<T>(value);
            else firstNode = new Node<T>(value, firstNode);
            count++; 
        }

        public void InsertBack(T value)
        {
            if (firstNode == null) firstNode = lastNode = new Node<T>(value);
            else if (lastNode == null) lastNode = lastNode.Next = new Node<T>(value);
            else
            {
                Node<T> currentNode = firstNode;

                for (int i = 0; i < count - 2; i++)
                {
                    currentNode = currentNode.Next;
                }

                Node<T> newNode = new Node<T>(value, currentNode.Next);
                currentNode.Next = newNode;

                lastNode = lastNode.Next = new Node<T>(value);
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

/*        public void Insert(Node<T> node, T val, int index) // done? 
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
        }*/
    }
}
