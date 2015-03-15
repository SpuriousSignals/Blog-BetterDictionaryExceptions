/*
Copyright 2015 Nick Bushby

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDictionaryExceptions
{
    /// <summary>
    /// Access of key that does not exist will throw exception message including the ToString representation of the key.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class CheckedDictionary<TKey,TValue> : IDictionary<TKey,TValue>
    {
        private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

        /// <summary>
        /// If key is not present in dictionary, exception will include ToString of key.
        /// </summary>
        public TValue this[TKey key]
        {
            get
            {
                TValue value = default(TValue);

                bool found = _dict.TryGetValue(key, out value);

                if (!found)
                {
                    throw new KeyNotFoundException(String.Format("The key {0} is not present in the dictionary", key));
                }

                return value;
            }
            set
            {
                _dict[key] = value;
            }
        }

        // Alternative approach. Was 40% slower for me when executing the non-exception path. About the same
        // when executing the exception path, since the exception throw/catch time outweights the dictionary access.
        //public TValue this[TKey key]
        //{
        //    get
        //    {
        //        if (!_dict.ContainsKey(key))
        //        {
        //            throw new KeyNotFoundException(String.Format("The key {0} is not present in the dictionary", key));
        //        }

        //        return _dict[key];
        //    }
        //    set
        //    {
        //        _dict[key] = value;
        //    }
        //}

        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
        }

        void ICollection<KeyValuePair<TKey,TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Add(item);
        }

        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return _dict.Keys; }
        }

        public bool Remove(TKey key)
        {
            return _dict.Remove(key);
        }

        bool ICollection<KeyValuePair<TKey,TValue>>.Remove(KeyValuePair<TKey,TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dict.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return _dict.Values; }
        }

        public void Clear()
        {
            _dict.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dict.Contains(item);
        }

        void ICollection<KeyValuePair<TKey,TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)_dict).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<TKey, TValue>>)_dict).IsReadOnly; }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
    }
}
