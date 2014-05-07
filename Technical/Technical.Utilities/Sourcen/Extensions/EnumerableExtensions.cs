using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for all kinds of (typed) enumerable data (Array, List, ...)
    /// </summary>
    public static class EnumerableExtensions
    {

        ///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
        ///<param name="items">The enumerable to search.</param>
        ///<param name="predicate">The expression to test the items against.</param>
        ///<returns>The index of the first matching item, or -1 if no items match.</returns>
        public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int retVal = 0;
            foreach (var item in items)
            {
                if (predicate(item)) return retVal;
                retVal++;
            }
            return -1;
        }

        /// <summary>
        /// 	Converts all items of a list and returns them as enumerable.
        /// </summary>
        /// <typeparam name = "TSource">The source data type</typeparam>
        /// <typeparam name = "TTarget">The target data type</typeparam>
        /// <param name = "source">The source data.</param>
        /// <returns>The converted data</returns>
        /// <example>
        /// 	var values = new[] { "1", "2", "3" };
        /// 	values.ConvertList&lt;string, int&gt;().ForEach(Console.WriteLine);
        /// </example>
        public static IEnumerable<TTarget> ConvertList<TSource, TTarget>(this IEnumerable<TSource> source)
        {
            return source.Select(value => value.ConvertTo<TTarget>());
        }

        /// <summary>
        /// Casts all items of a list and returns them as enumerable.
        /// </summary>
        /// <typeparam name="TSource">The source data type</typeparam>
        /// <typeparam name="TTarget">The target data type</typeparam>
        /// <param name="source">The source data.</param>
        /// <returns>The converted data</returns>  
        public static IEnumerable<TTarget> CastList<TSource, TTarget>(this IEnumerable<TSource> source)
        {
            foreach (var value in source)
            {
                yield return value.CastTo<TTarget>();
            }
        }

        /// <summary>
        /// 	Performs an action for each item in the enumerable
        /// </summary>
        /// <typeparam name = "T">The enumerable data type</typeparam>
        /// <param name = "values">The data values.</param>
        /// <param name = "action">The action to be performed.</param>
        /// <example>
        /// 	var values = new[] { "1", "2", "3" };
        /// 	values.ConvertList&lt;string, int&gt;().ForEach(Console.WriteLine);
        /// </example>
        /// <remarks>
        /// 	This method was intended to return the passed values to provide method chaining. Howver due to defered execution the compiler would actually never run the entire code at all.
        /// </remarks>
        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var value in values)
                action(value);
        }

        /// <summary>
        /// 	Performs an action for each item in the enumerable
        /// </summary>
        /// <typeparam name = "T">The enumerable data type</typeparam>
        /// <param name = "values">The data values.</param>
        /// <param name = "action">The action to be performed. Index is for each element is available</param>
        /// <example>
        /// 	var values = new[] { "One", "Two", "Three" };
        /// 	values.ForEach((d, i) => Console.WriteLine("[{0}] {1}", i, d));
        ///     // output:
        ///     // [0] One
        ///     // [1] Two
        ///     // [2] Three
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> values, Action<T, int> action)
        {
            var i = 0;
            foreach (var value in values)
                action(value, i++);
        }

        ///<summary>
        ///	Returns enumerable object based on target, which does not contains null references.
        ///	If target is null reference, returns empty enumerable object.
        ///</summary>
        ///<typeparam name = "T">Type of items in target.</typeparam>
        ///<param name = "target">Target enumerable object. Can be null.</param>
        ///<example>
        ///	object[] items = null;
        ///	foreach(var item in items.NotNull()){
        ///	// result of items.NotNull() is empty but not null enumerable
        ///	}
        /// 
        ///	object[] items = new object[]{ null, "Hello World!", null, "Good bye!" };
        ///	foreach(var item in items.NotNull()){
        ///	// result of items.NotNull() is enumerable with two strings
        ///	}
        ///</example>
        ///<remarks>
        ///	Contributed by tencokacistromy, http://www.codeplex.com/site/users/view/tencokacistromy
        ///</remarks>
        public static IEnumerable<T> IgnoreNulls<T>(this IEnumerable<T> target)
        {
            if (ReferenceEquals(target, null))
                yield break;

            foreach (var item in target.Where(item => !ReferenceEquals(item, null)))
                yield return item;
        }

        /// <summary>
        /// 	Returns the maximum item based on a provided selector.
        /// </summary>
        /// <typeparam name = "TItem">The item type</typeparam>
        /// <typeparam name = "TValue">The value item</typeparam>
        /// <param name = "items">The items.</param>
        /// <param name = "selector">The selector.</param>
        /// <param name = "maxValue">The max value as output parameter.</param>
        /// <returns>The maximum item</returns>
        /// <example>
        /// 	<code>
        /// 		int age;
        /// 		var oldestPerson = persons.MaxItem(p =&gt; p.Age, out age);
        /// 	</code>
        /// </example>
        public static TItem MaxItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, out TValue maxValue) where TItem : class where TValue : IComparable
        {
            TItem maxItem = null;
            maxValue = default(TValue);

            foreach (var item in items)
            {
                if (item == null)
                    continue;

                var itemValue = selector(item);

                if ((maxItem != null) && (itemValue.CompareTo(maxValue) <= 0))
                    continue;

                maxValue = itemValue;
                maxItem = item;
            }

            return maxItem;
        }

        /// <summary>
        /// 	Returns the maximum item based on a provided selector.
        /// </summary>
        /// <typeparam name = "TItem">The item type</typeparam>
        /// <typeparam name = "TValue">The value item</typeparam>
        /// <param name = "items">The items.</param>
        /// <param name = "selector">The selector.</param>
        /// <returns>The maximum item</returns>
        /// <example>
        /// 	<code>
        /// 		var oldestPerson = persons.MaxItem(p =&gt; p.Age);
        /// 	</code>
        /// </example>
        public static TItem MaxItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector) where TItem : class where TValue : IComparable
        {
            TValue maxValue;

            return items.MaxItem(selector, out maxValue);
        }

        /// <summary>
        /// 	Returns the minimum item based on a provided selector.
        /// </summary>
        /// <typeparam name = "TItem">The item type</typeparam>
        /// <typeparam name = "TValue">The value item</typeparam>
        /// <param name = "items">The items.</param>
        /// <param name = "selector">The selector.</param>
        /// <param name = "minValue">The min value as output parameter.</param>
        /// <returns>The minimum item</returns>
        /// <example>
        /// 	<code>
        /// 		int age;
        /// 		var youngestPerson = persons.MinItem(p =&gt; p.Age, out age);
        /// 	</code>
        /// </example>
        public static TItem MinItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, out TValue minValue) where TItem : class where TValue : IComparable
        {
            TItem minItem = null;
            minValue = default(TValue);

            foreach (var item in items)
            {
                if (item == null)
                    continue;
                var itemValue = selector(item);

                if ((minItem != null) && (itemValue.CompareTo(minValue) >= 0))
                    continue;
                minValue = itemValue;
                minItem = item;
            }

            return minItem;
        }

        /// <summary>
        /// 	Returns the minimum item based on a provided selector.
        /// </summary>
        /// <typeparam name = "TItem">The item type</typeparam>
        /// <typeparam name = "TValue">The value item</typeparam>
        /// <param name = "items">The items.</param>
        /// <param name = "selector">The selector.</param>
        /// <returns>The minimum item</returns>
        /// <example>
        /// 	<code>
        /// 		var youngestPerson = persons.MinItem(p =&gt; p.Age);
        /// 	</code>
        /// </example>
        public static TItem MinItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector) where TItem : class where TValue : IComparable
        {
            TValue minValue;

            return items.MinItem(selector, out minValue);
        }

        ///<summary>
        ///	Get Distinct
        ///</summary>
        ///<param name = "source"></param>
        ///<param name = "expression"></param>
        ///<typeparam name = "T"></typeparam>
        ///<typeparam name = "TKey"></typeparam>
        ///<returns></returns>
        /// <remarks>
        /// 	Contributed by Michael T, http://about.me/MichaelTran
        /// </remarks>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> expression)
        {
            return source == null ? Enumerable.Empty<T>() : source.GroupBy(expression).Select(i => i.First());
        }

        ///<summary>
        ///	Remove item from a list
        ///</summary>
        ///<param name = "source"></param>
        ///<param name = "predicate"></param>
        ///<typeparam name = "T"></typeparam>
        ///<returns></returns>
        /// <remarks>
        /// 	Contributed by Michael T, http://about.me/MichaelTran
        /// </remarks>
        public static IEnumerable<T> RemoveAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
                return Enumerable.Empty<T>();

            var list = source.ToList();
            list.RemoveAll(predicate);
            return list;
        }

        ///<summary>
        /// Turn the list of objects to a string of Common Seperated Value
        ///</summary>
        ///<param name="source"></param>
        ///<param name="separator"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        /// <example>
        /// 	<code>
        /// 		var values = new[] { 1, 2, 3, 4, 5 };
        ///			string csv = values.ToCSV(';');
        /// 	</code>
        /// </example>
        /// <remarks>
        /// 	Contributed by Moses, http://mosesofegypt.net
        /// </remarks>
        public static string ToCSV<T>(this IEnumerable<T> source, char separator)
        {
            if (source == null)
                return string.Empty;

            var csv = new StringBuilder();
            source.ForEach(value => csv.AppendFormat("{0}{1}", value, separator));
            return csv.ToString(0, csv.Length - 1);
        }

        ///<summary>
        /// Turn the list of objects to a string of Common Seperated Value
        ///</summary>
        ///<param name="source"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        /// <example>
        /// 	<code>
        /// 		var values = new[] {1, 2, 3, 4, 5};
        ///			string csv = values.ToCSV();
        /// 	</code>
        /// </example>
        /// <remarks>
        /// 	Contributed by Moses, http://mosesofegypt.net
        /// </remarks>
        public static string ToCSV<T>(this IEnumerable<T> source)
        {
            return source == null ? string.Empty : source.ToCSV(',');
        }

        /// <summary>
        /// Returns true if the <paramref name="source"/> is null or without any items.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null || !source.Any());
        }

        /// <summary>
        /// Returns true if the <paramref name="source"/> is contains at least one item.
        /// </summary>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return !source.IsNullOrEmpty();
        }

        /// <summary>
        /// Returns the first item or the <paramref name="defaultValue"/> if the <paramref name="source"/>
        /// does not contain any item.
        /// </summary>
        public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            return (source.IsNotEmpty() ? source.First() : defaultValue);
        }
    }
}
