using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Excercise.DataStructure.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyNode<T> Head { get; private set; }
        public DoublyNode<T> Tail { get; private set; }
        public int Count { get; set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyNode<T>(value));
        }

        private void AddFirst(DoublyNode<T> node)
        {
            //save off the Head
            DoublyNode<T> temp = Head;

            Head = node;

            //insert the rest of the list behind the head
            Head.Next = temp;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                //before: 1(head) <----> 5 <-> 7 -> null
                //after: 3(head) <----> 1 <-> 5 -> null
                temp.Previous = Head;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyNode<T>(value));
        }

        private void AddLast(DoublyNode<T> node)
        {
            if (IsEmpty)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            //shift head
            Head = Head.Next;
            Count--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Previous = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null; //null the last node
                Tail = Tail.Previous; //shift the tail
            }

            Count--;
        }

        public void PrintDoublyLinkedList(DoublyNode<T> head)
        {
            DoublyNode<T> doublyNode = head;

            while (doublyNode != null)
            {
                Console.WriteLine(doublyNode.Value);
                doublyNode = doublyNode.Next;
            }
        }

        private bool IsEmpty => Count == 0;
    }
}
