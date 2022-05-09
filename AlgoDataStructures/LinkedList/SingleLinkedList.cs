﻿using System;
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
        public int Count { get { return count; } } // works

        public void Add(T v) // works 
        {
            InsertBack(v); 

            if (Head == null && firstNode != null) Head = firstNode;  
        }

        public void Insert(T val, int index) // works  
        {
            if (Head == null && firstNode != null) Head = firstNode;

            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (index == 0) InsertFront(val);
            else if (index == (count)) InsertBack(val); 
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

        public T Remove() // works 
        {
            return RemoveFront(); 
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (firstNode == null) Console.WriteLine("List cannot be empty. ");

            object removedItem = default;
            Node<T> currentnode = Head;
            if (index == 0) // remove from front 
            {
                removedItem = RemoveFront();
                return (T)removedItem;
            }
            else if (index == (count - 1)) // remove from back
            {
                removedItem = RemoveBack();
                return (T)removedItem;
            }
            else // remove stuff
            {
                for (int i = 0; i < index - 1; i++)
                {
                    currentnode = currentnode.Next; 
                }
                removedItem = currentnode.Next;
                currentnode.Next = currentnode.Next.Next;

                Node<T> node = new Node<T>();
                node = (Node<T>)removedItem; 

                count--;
                return node.Data;
            }            
        } // works

        public object RemoveLast() // works 
        {
            if (firstNode == null) Console.WriteLine("List is empty. ");

            return RemoveBack(); 
        }

        public override string ToString()
        {
            if (Count == 0) return "";
            Node<T> current = Head; 

            string returnString = "";

            while (current != null)
            {
                if (returnString.Length > 0) returnString += ", ";
                returnString += current.Data;

                current = current.Next; 
            }

            return returnString.ToString(); 
        } // works 

        public void Clear() // done? 
        {
            firstNode = lastNode = null;
            count = 0; 
        }

        public int Search(T val)
        {
            SingleLinkedList<T> list = new SingleLinkedList<T>(); 
            Node<T> currentNode = Head;

            int found = 0;
            int index = 0; 
            while (currentNode != null)
            {
                index++; 
                if (currentNode.Data.ToString().Equals(val.ToString()))
                {
                    found++;
                    break; 
                }
                currentNode = currentNode.Next; 
            }

            if (found == 1) return index - 1;
            else return -1; 
        } // works 

        // helper guys 

        public void InsertFront(T value) // works now 
        {
            if (firstNode == null) firstNode = lastNode = new Node<T>(value);
            else
            {
                //firstNode = new Node<T>(value, firstNode);
                Node<T> newNode = new Node<T>();
                newNode.Data = value;
                newNode.Next = Head;
                Head = newNode; 
            }
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

        public T RemoveFront() // works now 
        {
            Node<T> node = this.Head;

            if (firstNode == lastNode) firstNode = lastNode = null;
            else
            {
                firstNode = firstNode.Next;                
                this.Head = this.Head.Next;
                node = null; 
            }

            count--;

            if (firstNode == null)
            {
                Node<T> node1 = new Node<T>(0);
                return node1.Data; 
            }
            else return firstNode.Data;
        }

        public T RemoveBack()
        {
            Node<T> currentNode = this.Head; 
            if (firstNode == lastNode) firstNode = lastNode = null; 
            else
            {

                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next; 
                }

                Node<T> node = currentNode.Next;
                currentNode.Next = null;
                node = null; 
            }

            count--;
            return currentNode.Data; 
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
