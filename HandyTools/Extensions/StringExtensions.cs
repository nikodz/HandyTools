using System;
using System.Threading.Tasks;
using HandyTools.Helper;

namespace HandyTools.Extensions;

public static class StringExtensions
{
	public static T ToValue<T>(this string input) where T : struct
	{
		if (input == null)
		{
			throw new ArgumentNullException(nameof(input));
		}
		var parameters = new object[] { input, null };
		var method = typeof(T).GetMethod(nameof(int.TryParse), new[] { typeof(string), typeof(T).MakeByRefType() });
		if (method == null)
		{
			throw new MissingMethodException(typeof(T).Name, nameof(int.TryParse));
		}
		if (!(bool)method.Invoke(null, parameters))
		{
			throw new ArgumentException($"Input string cannot be converted to type '{typeof(T).Name}'. Input string = '{input}'");
		}
		return (T)parameters[1];
	}

	public static T ToValueOrDefault<T>(this string input) where T : struct
	{
		var parameters = new object[] { input, null };
		var method = typeof(T).GetMethod(nameof(int.TryParse), new[] { typeof(string), typeof(T).MakeByRefType() });
		return method != null && (bool)method.Invoke(null, parameters)
			? (T)parameters[1]
			: default(T);
	}

	public static T? ToValueOrNull<T>(this string input) where T : struct
	{
		var parameters = new object[] { input, null };
		var method = typeof(T).GetMethod(nameof(int.TryParse), new[] { typeof(string), typeof(T).MakeByRefType() });
		return method != null && (bool)method.Invoke(null, parameters)
			? (T?)parameters[1]
			: null;
	}

	public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);
	public static bool IsNotEmpty(this string text) => !text.IsEmpty();

	public static string NullIfEmpty(this string text) => text.IsEmpty() ? null : text;

	public static T IsNotEmpty<T>(this string text, Func<T> then) => text.IsEmpty() ? default(T) : then();
	public static async Task<T> IsNotEmpty<T>(this string text, Func<Task<T>> then) => text.IsEmpty() ? default(T) : await then();
	public static T IsNotEmpty<T>(this string text, Func<string, T> then) => text.IsEmpty() ? default(T) : then(text);
	public static async Task<T> IsNotEmpty<T>(this string text, Func<string, Task<T>> then) => text.IsEmpty() ? default(T) : await then(text);

	public static bool NotContains(this string text, string search) => !text.Contains(search);

	public static string IfEmpty(this string text, string then) => text.IsEmpty() ? then : text;
	public static string IfEmpty(this string text, SingletonValue<string> then) => text.IsEmpty() ? then.Value : text;
	public static async Task<string> IfEmpty(this string text, SingletonValueAsync<string> then) => text.IsEmpty() ? await then : text;
	public static async Task<string> IfEmpty(this Task<string> text, SingletonValueAsync<string> then) => (await text).IsEmpty() ? await then : await text;

	public static string IfEmpty(this string text, Func<string> then)
		=> text.IsEmpty() ? Singleton.Create(then).Value : text;
	public static async Task<string> IfEmpty(this string text, Func<Task<string>> then)
		=> text.IsEmpty() ? await Singleton.CreateAsync(then) : text;
	public static async Task<string> IfEmpty(this Task<string> text, Func<Task<string>> then)
		=> await (await text).IfEmpty(then);
}