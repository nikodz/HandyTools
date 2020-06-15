using System;

namespace HandyTools.Extensions
{
	public static class DateTimeExtensions
	{
		public static int CalculateAge(this DateTime dateOfBirth)
			=> dateOfBirth.CalculateAge(DateTime.Today);

		public static int CalculateAge(this DateTime dateOfBirth, DateTime atDate)
			=> (atDate.ToString("yyyyMMdd").ToValue<int>() - dateOfBirth.Date.ToString("yyyyMMdd").ToValue<int>()) / 10000;
		
		public static bool EqualsInSeconds(this DateTime a, DateTime b)
			=> a.Ticks / TimeSpan.TicksPerSecond == b.Ticks / TimeSpan.TicksPerSecond;
		public static bool EqualsInSeconds(this DateTime? a, DateTime? b)
			=> a.HasValue == b.HasValue && (!a.HasValue || a.Value.EqualsInSeconds(b.Value));
	}
}