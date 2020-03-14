using System;

namespace HandyTools.Extensions
{
	public static class DateTimeExtensions
	{
		public static int CalculateAge(this DateTime dateOfBirth)
			=> dateOfBirth.CalculateAge(DateTime.Today);

		public static int CalculateAge(this DateTime dateOfBirth, DateTime atDate)
			=> (atDate.ToString("yyyyMMdd").ToValue<int>() - dateOfBirth.Date.ToString("yyyyMMdd").ToValue<int>()) / 10000;
	}
}