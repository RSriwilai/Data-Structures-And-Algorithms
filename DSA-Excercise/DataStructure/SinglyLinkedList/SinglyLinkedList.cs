namespace DSA_Excercise.DataStructure.SinglyLinkedList;

public class SinglyLinkedList<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public int Count { get; private set; }

    public void AddFirst(T value)
    {
        AddFirst(new Node<T>(value));
    }

    private void AddFirst(Node<T> node)
    {
        Node<T> tempNode = Head;

        Head = node;

        Head.Next = tempNode;

        Count++;

        if (Count == 1)
        {
            Tail = Head;
        }
    }

    public void AddLast(T value)
    {
        AddLast(new Node<T>(value));
    }

    private void AddLast(Node<T> node)
    {
        if (IsEmpty)
            Head = node;
        else
            Tail.Next = node;
        
        Tail = node;
        Count++;
    }

    public void RemoveFirst()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        Head = Head.Next;
        if (Count == 1)
            Tail = null;

        Count--;
    }

    public void RemoveLast()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        if (Count == 1)
        {
            Head = Tail = null;
        }
        else
        {
            //find the penultimate node
            var current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;
        }

        Count--;
    }


    public void PrintLinkedList(Node<T> head)
    {
        Node<T> node = head;

        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Next;
        }
    }

    private bool IsEmpty => Count == 0;
}