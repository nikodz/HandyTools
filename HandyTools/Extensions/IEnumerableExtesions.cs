using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyTools.Helper;

namespace HandyTools.Extensions;

public static class IEnumerableExtesions
{
	public static bool IsNotEmpty<T>(this IEnumerable<T> list) => list != null && list.Any();
	public static bool IsNullOrEmpty<T>(this IEnumerable<T> list) => !list.IsNotEmpty();
	public static bool NotContains<T>(this IEnumerable<T> list, T search) => !list.Contains(search);
	public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> list) => list.IsNotEmpty() ? list : null;
	public static IEnumerable<T> IfEmpty<T>(this IEnumerable<T> list, IEnumerable<T> next) => list.IsNotEmpty() ? list : next;
	public static IEnumerable<T> IfEmpty<T>(this IEnumerable<T> list, SingletonValue<IEnumerable<T>> next) => list.IsNotEmpty() ? list : next.Value;
	public static async Task<IEnumerable<T>> IfEmpty<T>(this IEnumerable<T> list, SingletonValueAsync<IEnumerable<T>> next) => list.IsNotEmpty() ? list : await next;
	public static async Task<IEnumerable<T>> IfEmpty<T>(this Task<IEnumerable<T>> list, SingletonValueAsync<IEnumerable<T>> next) => (await list).IsNotEmpty() ? await list : await next;
	public static IEnumerable<T> IfEmpty<T>(this IEnumerable<T> list, Func<IEnumerable<T>> next)
		=> list.IfEmpty(Singleton.Create(next));
	public static async Task<IEnumerable<T>> IfEmpty<T>(this IEnumerable<T> list, Func<Task<IEnumerable<T>>> next)
		=> await list.IfEmpty(Singleton.CreateAsync(next));
	public static async Task<IEnumerable<T>> IfEmpty<T>(this Task<IEnumerable<T>> list, Func<Task<IEnumerable<T>>> next)
		=> await (await list).IfEmpty(next);

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