using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_1_List
{
    public class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private const int DoubleCapacity = 2;
        private T[] _list;
        private int _count = 0;
        private int _capacity;
        private int _position = -1;

        public MyList(int initialCapacity = 4)
        {
            if (initialCapacity < 1)
            {
                initialCapacity = 1;
            }

            _capacity = initialCapacity;
            _list = new T[initialCapacity];
        }

        public int Count
        {
            get { return _count; }
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _list.Length)
                {
                    throw new InvalidOperationException();
                }

                return _list[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public T this[int index]
        {
            get
            {
                CheckBoundaries(index);
                return _list[index];
            }
            set
            {
                CheckBoundaries(index);
                _list[index] = value;
            }
        }

        public void Resize()
        {
            T[] doubleList = new T[_capacity * DoubleCapacity];
            for (int i = 0; i < _capacity; i++)
            {
                doubleList[i] = _list[i];
            }

            _list = doubleList;
            _capacity = _capacity * DoubleCapacity;
        }

        public void Add(T newItem)
        {
            if (_count == _capacity)
            {
                Resize();
            }

            _list[_count] = newItem;
            _count++;
        }

        public void GetCapacity()
        {
            foreach (T item in _list)
            {
                _count++;
            }

            if (_count <= 4)
            {
                _capacity = 4;
            }
            else if (_count % 4 == 0)
            {
                _capacity = _count;
            }
            else if (_count % 4 > 0)
            {
                _capacity = ((int)(_count / 4) * 4) + 4;
            }
        }

        public void AddRange(T[] newArray)
        {
            var combinedArray = new T[_list.Length + newArray.Length];
            _list.CopyTo(combinedArray, 0);
            newArray.CopyTo(combinedArray, _list.Length);

            _list = combinedArray;
            GetCapacity();
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_list, item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _list[i] = _list[i + 1];
            }

            _list[_count - 1] = default(T);
            _count--;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_list, comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = _count - 1; index >= 0; index--)
            {
                yield return _list[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_position < _list.Length - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }

        private void CheckBoundaries(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
