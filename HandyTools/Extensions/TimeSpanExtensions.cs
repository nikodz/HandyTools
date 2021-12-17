using System;

namespace HandyTools.Extensions;

public static class TimeSpanExtensions
{
	public static bool EqualsInSeconds(this TimeSpan a, TimeSpan b)
		=> (int)a.TotalSeconds == (int)b.TotalSeconds;
	public static bool EqualsInSeconds(this TimeSpan a, TimeSpan? b)
		=> a.EqualsInSeconds(b ?? TimeSpan.Zero);
	public static bool EqualsInSeconds(this TimeSpan? a, TimeSpan? b)
		=> (a ?? TimeSpan.Zero).EqualsInSeconds(b);
}