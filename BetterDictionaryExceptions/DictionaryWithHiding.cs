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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterDictionaryExceptions
{
    /// <summary>
    /// Access of key that does not exist will throw exception message including the ToString representation of the key.
    /// 
    /// Callers referencing IDictionary will not get keys in the exception message due to use of member hiding. See
    /// CheckedDictionary for a fuller implementation.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class DictionaryWithHiding<TKey, TValue> : Dictionary<TKey, TValue>
    {
        new public TValue this[TKey key] 
        {
            get
            {
                if (!base.ContainsKey(key))
                {
                    throw new KeyNotFoundException(String.Format("The key {0} is not present in the dictionary", key));
                }

                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
        
    }
}
