using System.Collections;

namespace DataStructures.Arrays
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] innerList;
        public int Count { get; private set; }
        public int Capacity => innerList.Length;
        public Array()
        {
            innerList = new T[2];
            Count = 0;
        }
        public Array(IEnumerable<T> collection)
        {
            innerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
                Add(item);
        }
        public void Add(T item)
        {
            if (Count == innerList.Length)
                DoubleList();
            innerList[Count] = item;
            Count++;
        }
        public void Remove(int index)
        {
            if (index >= Count)
                throw new Exception($"There is no item in index {index}");
            else
                Console.WriteLine($"Item {innerList[index]} is removed.");
            for (int i = index; i < innerList.Length - 1; i++)
                innerList[i] = innerList[i + 1];
            Count--;
            if (Count < innerList.Length / 2)
                HalvingList();
        }
        public void Print()
        {
            foreach (var item in innerList)
                Console.WriteLine(item);

        }
        public void Update(int index, T item)
        {
            if (index >= innerList.Length)
            {
                throw new IndexOutOfRangeException();
            }
            innerList[index] = item;
        }
        private void HalvingList()
        {
            if (innerList.Length > 2)
            {
                var temp = new T[innerList.Length / 2];
                Array.Copy(innerList, temp, innerList.Length / 2);
                innerList = temp;
            }
        }
        private void DoubleList()
        {
            var temp = new T[innerList.Length * 2];
            Array.Copy(innerList, temp, innerList.Length);
            innerList = temp;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return innerList.Take(Count).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}