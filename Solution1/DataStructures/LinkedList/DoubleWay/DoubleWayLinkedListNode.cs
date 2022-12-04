using DataStructures.LinkedList.OneWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoubleWay
{
    public class DoubleWayLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleWayLinkedListNode<T> Next { get; set; }
        public DoubleWayLinkedListNode<T> Previus { get; set; }
        public DoubleWayLinkedListNode(T Value) => this.Value = Value;
        public override string ToString() => $"{Value}";
    }
}
