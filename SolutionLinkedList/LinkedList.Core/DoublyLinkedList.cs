using System;
using System.Collections.Generic;

namespace LinkedList.Core
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
        }

        // -------------------------------
        // 1. Add element in ascending order
        // -------------------------------
        public void AddInOrder(T data)
        {
            var newNode = new DoubleNode<T>(data);

            // Empty list
            if (_head == null)
            {
                _head = _tail = newNode;
                return;
            }

            // Insert before head
            if (data.CompareTo(_head.Data) < 0)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                return;
            }

            // Traverse to find correct position
            var current = _head;
            while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
                current = current.Next;

            // Insert at the end
            if (current.Next == null)
            {
                current.Next = newNode;
                newNode.Prev = current;
                _tail = newNode;
            }
            else
            {
                // Insert between nodes
                newNode.Next = current.Next;
                newNode.Prev = current;
                current.Next!.Prev = newNode;
                current.Next = newNode;
            }
        }

        // -------------------------------
        // 2. Display forward
        // -------------------------------
        public void DisplayForward()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // -------------------------------
        // 3. Display backward
        // -------------------------------
        public void DisplayBackward()
        {
            if (_tail == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var current = _tail;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Prev;
            }
            Console.WriteLine("null");
        }

        // -------------------------------
        // 4. Sort list in descending order
        // -------------------------------
        public void SortDescending()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var values = new List<T>();
            var current = _head;

            // Extract all values
            while (current != null)
            {
                values.Add(current.Data);
                current = current.Next;
            }

            // Sort and reverse
            values.Sort();
            values.Reverse();

            // Rebuild list manually (append to tail)
            Clear();
            foreach (var val in values)
            {
                var node = new DoubleNode<T>(val);
                if (_head == null)
                {
                    _head = _tail = node;
                }
                else
                {
                    _tail!.Next = node;
                    node.Prev = _tail;
                    _tail = node;
                }
            }

            Console.WriteLine("List sorted in descending order.");
        }

        // -------------------------------
        // 5. Find and display mode(s)
        // -------------------------------
        public void FindMode()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var counts = new Dictionary<T, int>();
            var current = _head;

            while (current != null)
            {
                if (counts.ContainsKey(current.Data))
                    counts[current.Data]++;
                else
                    counts[current.Data] = 1;
                current = current.Next;
            }

            int max = 0;
            foreach (var c in counts.Values)
                if (c > max) max = c;

            Console.Write("Mode(s): ");
            foreach (var kv in counts)
                if (kv.Value == max)
                    Console.Write($"{kv.Key} ");
            Console.WriteLine();
        }

        // -------------------------------
        // 6. Display frequency graph
        // -------------------------------
        public void DisplayGraph()
        {
            if (_head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var counts = new Dictionary<T, int>();
            var current = _head;

            while (current != null)
            {
                if (counts.ContainsKey(current.Data))
                    counts[current.Data]++;
                else
                    counts[current.Data] = 1;
                current = current.Next;
            }

            foreach (var kv in counts)
            {
                Console.Write($"{kv.Key} ");
                for (int i = 0; i < kv.Value; i++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        // -------------------------------
        // 7. Check if value exists
        // -------------------------------
        public bool Exists(T value)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data!.CompareTo(value) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // -------------------------------
        // 8. Remove first occurrence
        // -------------------------------
        public void RemoveOne(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data!.CompareTo(value) == 0)
                {
                    if (current == _head)
                    {
                        _head = current.Next;
                        if (_head != null) _head.Prev = null;
                        else _tail = null;
                    }
                    else if (current == _tail)
                    {
                        _tail = current.Prev;
                        if (_tail != null) _tail.Next = null;
                        else _head = null;
                    }
                    else
                    {
                        current.Prev!.Next = current.Next;
                        current.Next!.Prev = current.Prev;
                    }

                    Console.WriteLine($"Removed one occurrence of {value}");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"{value} not found.");
        }

        // -------------------------------
        // 9. Remove all occurrences
        // -------------------------------
        public void RemoveAll(T value)
        {
            bool removed = false;
            var current = _head;

            while (current != null)
            {
                if (current.Data!.CompareTo(value) == 0)
                {
                    var nextNode = current.Next;

                    if (current == _head)
                    {
                        _head = current.Next;
                        if (_head != null) _head.Prev = null;
                        else _tail = null;
                    }
                    else if (current == _tail)
                    {
                        _tail = current.Prev;
                        if (_tail != null) _tail.Next = null;
                        else _head = null;
                    }
                    else
                    {
                        current.Prev!.Next = current.Next;
                        current.Next!.Prev = current.Prev;
                    }

                    removed = true;
                    current = nextNode;
                }
                else
                {
                    current = current.Next;
                }
            }

            if (removed)
                Console.WriteLine($"All occurrences of {value} removed.");
            else
                Console.WriteLine($"{value} not found.");
        }

        // -------------------------------
        // Utility: clear the list
        // -------------------------------
        private void Clear()
        {
            _head = null;
            _tail = null;
        }
    }
}
