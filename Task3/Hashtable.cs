using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3
{
    public class Hashtable<K, T> : IEnumerable<T>
    {
        
        private List<KeyValuePair<K, T>>[] container;
        private const int containerLength = 10;
        private Func<K, int> hashFunc;
        private IEqualityComparer<K> comparer; 

        public Hashtable()
        {
            hashFunc = x => (x.GetHashCode());
            comparer = EqualityComparer<K>.Default;
            container = new List<KeyValuePair<K, T>>[containerLength];
        }

        public Hashtable(Func<K, int> hashFunc, IEqualityComparer<K> comparer)
        {
            this.hashFunc = hashFunc;
            this.comparer = comparer;
            container = new List<KeyValuePair<K, T>>[containerLength];
        }

        public void Add(K key, T value)
        {
            var pair = new KeyValuePair<K, T>(key, value);
            int hash = hashFunc(pair.Key);
            int index = hash%containerLength;
            if (container[index] == null)
                container[index] = new List<KeyValuePair<K, T>>();
            if (Contains(container[index], pair.Key) != null)
                throw new ArgumentException("Key already exist");
            container[index].Add(pair);
        }

        public T Get(K key)
        {
            int hash = hashFunc(key);
            int index = hash % containerLength;
            if (container[index] != null)
            {
                var result = Contains(container[index], key);
                if (result != null)
                    return result.Value;
            }
            throw new InvalidOperationException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < container.Length; i++)
                if (container[i] != null)
                {
                    foreach (var item in container[i])
                    {
                        yield return item.Value;
                    }
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private KeyValuePair<K, T> Contains(List<KeyValuePair<K,T>> list, K key)
        {
            foreach (var item in list)
            {
                if (comparer.Equals(item.Key, key))
                    return item;
            }
            return null;
        }

        private class KeyValuePair<K, T>
        {
            public KeyValuePair(K key, T value)
            {
                Key = key;
                Value = value;
            }

            public K Key { get; private set; }
            public T Value { get; private set; }
        }
    }
}
