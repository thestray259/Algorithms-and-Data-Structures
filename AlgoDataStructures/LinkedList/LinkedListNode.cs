using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class LinkedListNode<T>
    {
        public LinkedListNode() { }
        public LinkedListNode(int v) { } 
        public LinkedListNode(T data)
        {
            this.Data = data;  
        }

        public LinkedListNode(T data, LinkedListNode<T> next)
        {
            this.Data = data;
            this.Next = next; 
        }

        public LinkedListNode(T data, LinkedListNode<T> next, LinkedListNode<T> prev)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev; 
        }

        public T Data { get; set; }

        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }

        public override string ToString() // do this 
        {
            return Data.ToString();
        }
    }
}
