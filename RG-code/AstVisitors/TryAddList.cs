using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RG_code.AstVisitors
{
    public class TryAddList<T> : IList<T>
    {
        private List<T> _list = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get => _list.Count();
        }

        public bool IsReadOnly { get => false; }
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public bool TryAdd(T item)
        {
            if (_list.Contains(item))
            {
                return false;
            }
            
            Add(item);
            return true;
        }
    }
}