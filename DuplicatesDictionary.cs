using System;
using System.Collections.Generic;

namespace BalloonProblem
{
    /// <summary>
    /// A dictionary that allows duplicates, quite surprised this doesn't already exist in BCL
    /// </summary>
    public class DuplicatesDictionary<K, V>
    {
        private DuplicatesDictionaryEntryList<K, V>[] _table;

        public DuplicatesDictionary()
        {
            _table = new DuplicatesDictionaryEntryList<K, V>[1000];
            for(int i = 0; i < 1000; i++)
            {
                _table[i] = new DuplicatesDictionaryEntryList<K, V>();
            }
        }

        public void Add(K key, V value)
        {
            var entry = new DuplicatesDictionaryEntry<K, V> { Key = key, Value = value };
            var hash = Hash(entry);
            _table[hash].Entries.Add(entry);
        }

        public void Remove(K key)
        {
            var entry = new DuplicatesDictionaryEntry<K, V> { Key = key};
            var hash = Hash(entry);
            var entries = _table[hash].Entries;
            if (entries.Count != 0)
            {
                entries.RemoveAt(0);
            }
        }

        private int Hash(DuplicatesDictionaryEntry<K, V> entry)
        {
            return Math.Abs(entry.Key.GetHashCode()) % _table.Length;
        }


        private class DuplicatesDictionaryEntryList<K, V>
        {
            public List<DuplicatesDictionaryEntry<K, V>> Entries { get; set; } = new List<DuplicatesDictionaryEntry<K, V>>();
                
        }

        private class DuplicatesDictionaryEntry<K, V>
        {            
            public K Key { get; set; }
            public V Value { get; set; }
        }
    }

    
}
