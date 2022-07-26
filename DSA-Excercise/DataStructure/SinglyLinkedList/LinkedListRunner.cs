using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Excercise.DataStructure.SinglyLinkedList
{
    public class LinkedListRunner
    {
        public static void Run()
        {
            var linkedlist = new SinglyLinkedList<int>();
            linkedlist.AddFirst(5);
            linkedlist.AddFirst(3);
            linkedlist.AddFirst(6);
            linkedlist.AddFirst(1);
            linkedlist.PrintLinkedList(linkedlist.Head);
        }
    }
}
