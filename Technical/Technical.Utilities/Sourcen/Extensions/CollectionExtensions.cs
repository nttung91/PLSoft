using System;
using System.Collections.Generic;
using System.Linq;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for all kind of Collections implementing the ICollection&lt;T&gt; interface
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 	Adds a value uniquely to to a collection and returns a value whether the value was added or not.
        /// </summary>
        /// <typeparam name = "T">The generic collection value type</typeparam>
        /// <param name = "collection">The collection.</param>
        /// <param name = "value">The value to be added.</param>
        /// <returns>Indicates whether the value was added or not</returns>
        /// <example>
        /// 	<code>
        /// 		list.AddUnique(1); // returns true;
        /// 		list.AddUnique(1); // returns false the second time;
        /// 	</code>
        /// </example>
        public static bool AddUnique<T>(this ICollection<T> collection, T value)
        {
            if (collection.Contains(value) == false)
            {
                collection.Add(value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 	Adds a range of value uniquely to a collection and returns the amount of values added.
        /// </summary>
        /// <typeparam name = "T">The generic collection value type.</typeparam>
        /// <param name = "collection">The collection.</param>
        /// <param name = "values">The values to be added.</param>
        /// <returns>The amount if values that were added.</returns>
        public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                if (collection.AddUnique(value))
                    count++;
            }
            return count;
        }

        ///<summary>
        ///	Remove an item from the collection with predicate
        ///</summary>
        ///<param name = "collection"></param>
        ///<param name = "predicate"></param>
        ///<typeparam name = "T"></typeparam>
        ///<exception cref = "ArgumentNullException"></exception>
        /// <remarks>
        /// 	Contributed by Michael T, http://about.me/MichaelTran
        /// </remarks>
        public static void RemoveAll<T>(this ICollection<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            var deleteList = collection.Where(child => predicate(child)).ToList();
            deleteList.ForEach(t => collection.Remove(t));
        }

        ///<summary>
        ///	Check if the index is within the collection
        ///</summary>
        ///<param name = "source"></param>
        ///<param name = "index"></param>
        ///<returns></returns>
        public static bool WithinIndex<T>(this ICollection<T> collection, int index)
        {
            return collection != null && index >= 0 && index < collection.Count;
        }
    }
}