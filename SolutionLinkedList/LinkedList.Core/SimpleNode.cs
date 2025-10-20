namespace LinkedList.Core;

public class SimpleNode<T>
{
    public SimpleNode(T data)
    {
        Data = data;
        Next = null;
    }

    public T? Data { get; set; }

    public SimpleNode<T>? Next { get; set; }
}