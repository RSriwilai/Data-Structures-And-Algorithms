using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Excercise.DataStructure.DoublyLinkedList
{
    public class DoublyLinkedListRunner
    {

        public static void Run()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            var rnd = new Random();
            
            for (int i = 1; i <= 10; i++)
            {
                var num = rnd.Next(10);
                doublyLinkedList.AddFirst(num);
            }

            doublyLinkedList.PrintDoublyLinkedList(doublyLinkedList.Head);


        }
    }
}
