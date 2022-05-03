using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{
    public class Node<T>
    {
        // add constructor, 1 variable of type T 

        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public override string ToString() // do this 
        {
            return Data.ToString();
        }
    }
}
