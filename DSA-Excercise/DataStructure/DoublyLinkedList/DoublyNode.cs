using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Excercise.DataStructure.DoublyLinkedList
{
    public class DoublyNode<T>
    {
        public DoublyNode(T value)
        {
            Value = value;
        }

        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }

        public T Value { get; set; }

    }
}
