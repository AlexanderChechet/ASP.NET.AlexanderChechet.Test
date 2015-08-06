using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    public class List<T> : IEnumerable<T>
    {
        private struct Storage
        {
            public T Data { get; private set; }
            public bool Flag { get; private set; }

            public Storage(T data, bool flag) : this()
            {
                Data = data;
                Flag = flag;
            }

            public void ChangeFlag()
            {
                Flag = false;
            }
        }

        private Storage[] array;
        private int currentSize;
        private int realCount;
        private int count;

        public List()
        {
            count = 0;
            currentSize = 20;
            array = new Storage[currentSize];
        }

        public List(int length)
        {
            count = 0;
            currentSize = length;
            array = new Storage[currentSize];
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            if (realCount == currentSize)
                IncreaseSize();
            array[realCount] = new Storage(item, true);
            count++;
            realCount++;
        }

        public void Remove(T item)
        {
            if (!Contains(item))
            {
                throw new InvalidOperationException();
            }
            bool flag = true;
            int index = 0;
            while (flag)
            {
                if (array[index].Flag)
                    if (array[index].Data.Equals(item))
                    {
                        array[index].ChangeFlag();
                        count--;
                        flag = false;
                    }
                index++;
            }
        }

        public bool Contains(T item)
        {
            int i = 0;
            int index = 0;
            while (i != count)
            {
                if (array[index].Flag)
                {
                    if (array[index].Data.Equals(item))
                        return true;
                    i++;
                }
                index++;
            }
            return false;
        }

        public T[] ToArray()
        {
            var tempArray = new T[count];
            int i = 0;
            int index = 0;
            while (i != count)
            {
                if (array[index].Flag)
                {
                    tempArray[i] = array[index].Data;
                    i++;
                }
                index++;
            }
            return tempArray;
        }

        private void IncreaseSize()
        {
            var tempArray = new Storage[currentSize*2];
            int index = 0;
            for (int i = 0; i < currentSize; i++)
            {
                if (array[i].Flag)
                {
                    tempArray[index] = array[i];
                    index++;
                }
            }
            array = tempArray;
            realCount = count;
            currentSize *= 2;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            int index = 0;
            while (i != count)
            {
                if (array[index].Flag)
                {
                    i++;
                    yield return array[index].Data;
                }
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
