﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for Dictionary.
    /// </summary>
    public static class DictionaryExtensions
    {
        // todo: Needs xml documentation for these methods
        // todo: create unit testing for these methods
        public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return new SortedDictionary<TKey, TValue>(dictionary);
        }

        public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            IComparer<TKey> comparer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return new SortedDictionary<TKey, TValue>(dictionary, comparer);
        }

        public static IDictionary<TKey, TValue> SortByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return
                (new SortedDictionary<TKey, TValue>(dictionary)).OrderBy(kvp => kvp.Value)
                    .ToDictionary(item => item.Key, item => item.Value);
        }

        public static IDictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key);
        }

        public static Hashtable ToHashTable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            var table = new Hashtable();

            foreach (var item in dictionary)
                table.Add(item.Key, item.Value);

            return table;
        }

        /// <summary>
        /// Returns the value of the first entry found with one of the <paramref name="keys"/> received.
        /// <para>Returns <paramref name="defaultValue"/> if none of the keys exists in this collection </para>
        /// </summary>
        /// 
        /// <param name="defaultValue">Default value if none of the keys </param>
        /// <param name="keys"> keys to search for (in order) </param>
        public static TValue GetFirstValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue defaultValue,
            params TKey[] keys)
        {
            foreach (var key in keys)
            {
                if (dictionary.ContainsKey(key))
                    return dictionary[key];
            }
            return defaultValue;
        }
    }
}