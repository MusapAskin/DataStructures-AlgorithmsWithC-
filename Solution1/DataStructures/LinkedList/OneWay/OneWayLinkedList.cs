using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.LinkedList.OneWay
{
    public class OneWayLinkedList<T> : IEnumerable<T>
    {
        public OneWayLinkedListNode<T> Head { get; set; }
        public OneWayLinkedListNode<T> Tail { get; set; }
        public OneWayLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddBack(item);
        }
        public OneWayLinkedList()
        {

        }
        private bool isHeadNull => Head == null;
        public void AddFront(T value)
        {
            var newNode = new OneWayLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }
        public void AddBack(T value)
        {
            var newNode = new OneWayLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }
        public void AddAfter(T node, T value)
        {
            var newNode = new OneWayLinkedListNode<T>(value);
            var Node = new OneWayLinkedListNode<T>(node);
            var Prev = Head;
            if (isHeadNull)
            {
                AddFront(value);
                return;
            }
            while (Prev != null)
            {
                if (Prev.Value.Equals(Node.Value))
                {
                    newNode.Next = Prev.Next;
                    Prev.Next = newNode;
                    return;
                }
                Prev = Prev.Next;
            }
            throw new ArgumentException("The reference node is not in linkedlist.");
        }
        public T RemoveFirst()
        {
            var value = Head.Value;
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            Head = Head.Next;
            Head.Previus = null;
            return value;
        }
        public T RemoveLast()
        {
            var value = Tail.Value;
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            var Prev = Head;
            while (Prev.Next != Tail)
            {
                if (Head == Tail)
                {
                    Head = null;
                    return value;
                }
                Prev = Prev.Next;
            }
            Tail = Prev;
            Prev.Next = null;
            return value;
        }
        public void Remove(T value)
        {
            var current = Head;
            var Node = new OneWayLinkedListNode<T>(value);
            if (isHeadNull)
                throw new Exception("Nothing to remove! List is null.");
            else if (Head.Value.Equals(Node.Value)){ 
                RemoveFirst();
                return; 
            }
            else if (Tail.Value.Equals(Node.Value))
            {
                RemoveLast();
                return;
            }
            else
            {
                while (!(current.Next.Value.Equals(Node.Value)))
                    current = current.Next;
                current.Next = current.Next.Next;
                return;
            }
            throw new ArgumentException("The value could not be found in the list!");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new OneWayLinkedListEnumerator<T>(Head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
