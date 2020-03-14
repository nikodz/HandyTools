using System;
using System.Collections.Generic;
using System.Linq;

namespace HandyTools.Extensions
{
	public static class IEnumerableExtesions
	{
		public static bool IsNotEmpty<T>(this IEnumerable<T> list) => list != null && list.Any();
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) => !list.IsNotEmpty();
		public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> list) => list.IsNotEmpty() ? list : null;
		public static IEnumerable<T> IfEmpty<T>(this IEnumerable<T> list, IEnumerable<T> next) => list.IsNotEmpty() ? list : next;

		public static IEnumerable<TObject> GetChildren<TObject, TKey>(this IEnumerable<TObject> list, TObject item, Func<TObject, TKey> getKey, Func<TObject, TKey> getParentKey)
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			if (getKey == null)
			{
				throw new ArgumentNullException(nameof(getKey));
			}
			if (getParentKey == null)
			{
				throw new ArgumentNullException(nameof(getParentKey));
			}
			if (getKey(item) == null)
			{
				throw new ArgumentException("Key of initial item can not be null.", nameof(item));
			}
			if (list.Any())
			{
				var taken = new LinkedList<TObject>();
				taken.AddLast(item);
				var notTaken = list.Where(i => getKey(i) != null && getParentKey(i) != null && !getKey(item).Equals(getKey(i))).ToList();
				while (taken.Any())
				{
					var currentItem = taken.First();
					yield return currentItem;
					foreach (var i in notTaken.Where(i => getKey(currentItem).Equals(getParentKey(i))))
					{
						taken.AddLast(i);
					}
					taken.RemoveFirst();
				}
			}
		}
	}
}