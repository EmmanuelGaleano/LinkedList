namespace LinkedList.Core;

public class SinglyLinkedList<T>
{
    private SimpleNode<T>? _head;

    public SinglyLinkedList()
    {
        _head = null;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new SimpleNode<T>(data);
        newNode.Next = _head;
        _head = newNode;
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new SimpleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void PrintList()
    {
        var current = _head;
        while (current != null)
        {
            Console.Write($"{current.Data} -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}