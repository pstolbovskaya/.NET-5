using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class DynamicList<T> : IEnumerable<T>
    {
        T[] array;
        private int position;
        public int Count { get { return array.Count(); } }

        public T this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                array[index] = value;
            }
        }

        public DynamicList()
        {
            array = new T[0];
            position = 0;
        }

        public void Add(T value)
        {
            Array.Resize(ref array, position + 1);
            array[position] = value;

            position++;
            Array.Resize(ref array, position);
        }

        public void Remove(T obj)
        {
            int pos = Array.IndexOf(array, obj);
            if (pos != -1)
            {
                RemoveAt(pos);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                for (int a = index; a < array.Length - 1; a++)
                {
                    array[a] = array[a + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (DynamicListEnumerator<T>)GetEnumerator();
        }
    }


    public class DynamicListEnumerator<T> : IEnumerator<T>
    {
        DynamicList<T> _array;
        int position = -1;

        public DynamicListEnumerator(DynamicList<T> arr)
        {
            _array = arr;
        }

        public void Dispose()
        { }


        public bool MoveNext()
        {
            position++;
            return (position < _array.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}

