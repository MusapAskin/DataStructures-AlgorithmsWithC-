using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoubleWay
{
    internal class DoubleWayLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoubleWayLinkedListNode<T> Head;
        private DoubleWayLinkedListNode<T> current;
        public DoubleWayLinkedListEnumerator(DoubleWayLinkedListNode<T> Head)
        {
            this.Head= Head;
        }
        public T Current => current.Value;
        object IEnumerator.Current => Current;
        public void Dispose()
        {
            Head = null;
        }
        public bool MoveNext()
        {
            if (current == null)
            {
                current = Head;
                return true;
            }
            else
            {
                current = current.Next;
                return current != null ? true : false;
            }
        }
        public void Reset()
        {
            current = null;
        }
    }
}
