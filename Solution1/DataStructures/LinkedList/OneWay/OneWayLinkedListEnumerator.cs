using System.Collections;

namespace DataStructures.LinkedList.OneWay
{
    internal class OneWayLinkedListEnumerator<T> : IEnumerator<T>
    {
        private OneWayLinkedListNode<T> Head;
        private OneWayLinkedListNode<T> current;
        public OneWayLinkedListEnumerator(OneWayLinkedListNode<T> Head)
        {
           this.Head = Head;
        }
        public T Current => current.Value;
        object IEnumerator.Current => Current;
        public void Dispose()
        {
            Head=null;
        }
        public bool MoveNext()
        {
            if (current==null)
            {
                current = Head;
                return true;
            }
            else { 
                current= current.Next;
                return current!=null? true: false;  
            }
        }
        public void Reset()
        {
            current = null;
        }
    }
}