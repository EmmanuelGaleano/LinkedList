namespace LinkedList.Core
{
    // Node class for a doubly linked list
    public class DoubleNode<T>
    {
        public T Data { get; set; }              // Data stored in the node
        public DoubleNode<T>? Next { get; set; } // Pointer to the next node
        public DoubleNode<T>? Prev { get; set; } // Pointer to the previous node

        // Constructor initializes node with given data
        public DoubleNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
