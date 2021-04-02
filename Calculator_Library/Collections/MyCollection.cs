using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class MyCollection<T>
    {
        private T[] list;
        public int Count { get; private set; }
        public MyCollection()
        {
            Count = 1;
            list = new T[20];

        }
        public T this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list[i] = value;

            }
        }
        public void Add(T value)
        {
            if (Count == list.Length)
            {
                Array.Resize<T>(ref list, list.Length + 10);
            }

            list[Count] = value;
            Count++;
        }
        
        public void RemoveAt(int index) 
        {
            T[] newList = new T[list.Length - 1];

            for (int i = 0; i < index; i++)
                newList[i] = list[i];

            for(int i = index + 1; i < list.Length; i++)
                newList[i-1] = list[i];

            list = newList;
            Count--;
        }
    }
}
