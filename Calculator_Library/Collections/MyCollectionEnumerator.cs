using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class MyCollectionEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] list;

        private int position = 0;
        public MyCollectionEnumerator(T[] list)
        {
            this.list = list;
        }

        public T Current
        {
            get
            {
                if (position == 0 || position > list.Length - 1)
                    throw new InvalidOperationException();
                return list[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (position == 0 || position > list.Length - 1)
                    throw new InvalidOperationException();
                return list[position];
            }
        }

        public bool MoveNext()
        {
            if (position < list.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = 0;
        }
        public void Dispose() { }

    }
}
