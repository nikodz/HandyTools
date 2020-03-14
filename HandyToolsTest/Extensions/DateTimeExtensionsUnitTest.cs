using System;
using System.Collections.Generic;
using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions
{
	public class DateTimeExtensionsUnitTest
	{
		[Theory]
		[MemberData(nameof(AgeCalculationData))]
		public void Test_CalculateAge(DateTime dateofBirth, DateTime atDate, int expected)
		{
			var actual = dateofBirth.CalculateAge(atDate);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> AgeCalculationData
		{
			get
			{
				yield return new object[] { new DateTime(1990, 3, 4), new DateTime(2004, 3, 3), 13 };
				yield return new object[] { new DateTime(1990, 3, 4), new DateTime(2004, 3, 4), 14 };
				yield return new object[] { new DateTime(1990, 3, 4), new DateTime(2004, 3, 5), 14 };

				yield return new object[] { new DateTime(1992, 2, 29), new DateTime(2020, 2, 28), 27 };
				yield return new object[] { new DateTime(1992, 2, 29), new DateTime(2020, 2, 29), 28 };
				yield return new object[] { new DateTime(1992, 2, 29), new DateTime(2020, 3, 1), 28 };
			}
		}
	}
}