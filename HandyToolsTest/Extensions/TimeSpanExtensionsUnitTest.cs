using System;
using System.Collections.Generic;
using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions
{
	public class TimeSpanExtensionsUnitTest
	{
		[Fact]
		public void Test_TimeSpan_EqualsInSeconds()
		{
			TimeSpan? a = new TimeSpan(1, 2, 3, 4, 5);
			TimeSpan? b = new TimeSpan(1, 2, 3, 4, 6);
			Assert.True(a.EqualsInSeconds(b));
			Assert.True(a.Value.EqualsInSeconds(b.Value));
			a = null;
			Assert.False(a.EqualsInSeconds(b));
			Assert.False(b.EqualsInSeconds(a));
		}
	}
}