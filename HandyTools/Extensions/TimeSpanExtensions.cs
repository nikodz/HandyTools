using System;

namespace HandyTools.Extensions
{
	public static class TimeSpanExtensions
	{
		public static bool EqualsInSeconds(this TimeSpan a, TimeSpan b)
			=> (int)a.TotalSeconds == (int)b.TotalSeconds;
		public static bool EqualsInSeconds(this TimeSpan? a, TimeSpan? b)
			=> (int)(a?.TotalSeconds ?? 0) == (int)(b?.TotalSeconds ?? 0);
	}
}