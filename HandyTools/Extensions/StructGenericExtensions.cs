using System.Collections.Generic;

namespace HandyTools.Extensions
{
	public static class StructGenericExtensions
	{
		public static bool IsBetween<T>(this T i, T start, T end) where T : struct
			=> Comparer<T>.Default.Compare(start, i) <= 0
			&& Comparer<T>.Default.Compare(i, end) <= 0;
		public static bool IsBetween<T>(this T? i, T start, T end) where T : struct
			=> i.HasValue && i.Value.IsBetween(start, end);

		public static T BetweenOrDefault<T>(this T i, T start, T end) where T : struct
			=> i.IsBetween(start, end) ? i : default(T);
		public static T? BetweenOrDefault<T>(this T? i, T start, T end) where T : struct
			=> i.IsBetween(start, end) ? i : null;

		public static T BetweenOr<T>(this T i, T start, T end, T value) where T : struct
			=> i.IsBetween(start, end) ? i : value;
		public static T BetweenOr<T>(this T? i, T start, T end, T value) where T : struct
			=> i.IsBetween(start, end) ? i.Value : value;

		public static bool IsDefault<T>(this T i) where T : struct => default(T).Equals(i);
		public static bool IsDefault<T>(this T? i) where T : struct => default(T).Equals(i.GetValueOrDefault());
		public static bool IsNotDefault<T>(this T i) where T : struct => !i.IsDefault();
		public static bool IsNotDefault<T>(this T? i) where T : struct => !i.IsDefault();

		public static T DefaultOr<T>(this T i, T value) where T : struct => IsDefault(i) ? value : i;
		public static T? DefaultOr<T>(this T? i, T? value) where T : struct => IsDefault(i) ? value : i;
		public static T? DefaultOr<T>(this T i, T? value) where T : struct => IsDefault(i) ? value : i;
		public static T DefaultOr<T>(this T? i, T value) where T : struct => IsDefault(i) ? value : i.Value;
	}
}