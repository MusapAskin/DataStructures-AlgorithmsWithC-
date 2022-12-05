using DataStructures.LinkedList.OneWay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoubleWay
{
    public class DoubleWayLinkedList<T> : IEnumerable<T>
    {
        public DoubleWayLinkedListNode<T> Head { get; set; }
        public DoubleWayLinkedListNode<T> Tail { get; set; }
        public DoubleWayLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddBack(item);
        }
        public DoubleWayLinkedList()
        {

        }
        private bool isHeadNull => Head == null;
        public void AddFront(T item)
        {
            var newNode = new DoubleWayLinkedListNode<T>(item);
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            else
            {
                newNode.Next = Head;
                Head.Previus = newNode;
                Head = newNode;
            }
        }
        public void AddBack(T item)
        {
            var newNode = new DoubleWayLinkedListNode<T>(item);
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previus = Tail;
                Tail = newNode;
            }
        }
        public void AddAfter(T node, T item)
        {
            var newNode = new DoubleWayLinkedListNode<T>(item);
            var Node = new DoubleWayLinkedListNode<T>(node);
            var prev = Head;
            if (isHeadNull)
            {
                AddFront(item);
                return;
            }
            else
            {
                while (prev != null)
                {
                    if (prev.Value.Equals(Node.Value))
                    {
                        newNode.Next = prev.Next;
                        newNode.Previus = prev;
                        prev.Next.Previus = newNode;
                        prev.Next = newNode;
                        return;
                    }
                    prev = prev.Next;
                }
                throw new ArgumentException("The reference node is not in linkedlist.");
            }
        }
        public void AddBefore(T node, T item)
        {
            var newNode = new DoubleWayLinkedListNode<T>(item);
            var Node = new DoubleWayLinkedListNode<T>(node);
            var prev = Head;
            if (isHeadNull && Head.Value.Equals(Node.Value))
                AddFront(item);
            else
            {
                while (prev.Next != null)
                {
                    if (prev.Next.Value.Equals(Node.Value))
                    {
                        newNode.Next = prev.Next;
                        newNode.Previus = prev;
                        prev.Next = newNode;
                        newNode.Next.Previus = newNode;
                        return;
                    }
                    prev = prev.Next;
                }
                throw new ArgumentException("The reference node is not in linkedlist.");
            }
        }
        public T RemoveFirst()
        {
            var value = Head.Value;
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            else if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return value;
            }
            else
            {
                Head = Head.Next;
                Head.Previus = null;
                return value;
            }
        }
        public T RemoveLast()
        {
            var value = Head.Value;
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            else if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return value;
            }
            else
            {
                Tail = Tail.Previus;
                Tail.Next = null;
                return value;
            }
        }
        public void Remove(T item)
        {
            var Node = new DoubleWayLinkedListNode<T>(item);
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            else if (Head.Value.Equals(Node.Value))
                RemoveFirst();
            else if (Tail.Value.Equals(Node.Value))
                RemoveLast();
            else
            {
                var prev = Head;
                while (prev.Next != null)
                {
                    if (prev.Next.Value.Equals(Node.Value))
                    {
                        prev.Next.Previus = null;
                        prev.Next = prev.Next.Next;
                        prev.Next.Previus.Next = null;
                        prev.Next.Previus = prev;
                    }
                    prev = prev.Next;
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleWayLinkedListEnumerator<T>(Head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
