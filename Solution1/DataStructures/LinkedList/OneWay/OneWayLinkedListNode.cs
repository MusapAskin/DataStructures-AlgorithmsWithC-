using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.OneWay
{
    public class OneWayLinkedListNode<T>
    {
        public T Value { get; set; }
        public OneWayLinkedListNode<T> Next { get; set; }
        public object Previus { get; internal set; }

        public OneWayLinkedListNode(T Value) => this.Value = Value;
        public override string ToString() => $"{Value}";

    }
}
