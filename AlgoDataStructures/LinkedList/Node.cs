﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class Node<T>
    {
        public Node() { }
        public Node(int v) { } 
        public Node(T data)
        {
            this.Data = data;  
        }

        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next; 
        }

        public Node(T data, Node<T> next, Node<T> prev)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev; 
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public override string ToString() // do this 
        {
            return Data.ToString();
        }
    }
}
