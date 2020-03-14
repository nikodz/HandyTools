using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions
{
	public class BitOperationsHasBitUnitTest
	{
		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(1, 1, 2)]
		[InlineData(2, 1, 2)]
		[InlineData(0, -1, 1)]
		public void Test_IsBetween_True(int a, int from, int till)
		{
			var actual = a.IsBetween<int>(from, till);

			Assert.True(actual);
		}

		[Theory]
		[InlineData(2, 1, 1)]
		[InlineData(0, 1, 2)]
		[InlineData(3, -1, 1)]
		[InlineData(5, 10, 1)]
		public void Test_IsBetween_False(int a, int from, int till)
		{
			var actual = a.IsBetween<int>(from, till);

			Assert.False(actual);
		}

		[Theory]
		[InlineData(1, 1, 1)]
		[InlineData(1, 1, 2)]
		[InlineData(2, 1, 2)]
		[InlineData(0, -1, 1)]
		public void Test_IsBetween_Nullable_True(int? a, int from, int till)
		{
			var actual = a.IsBetween<int>(from, till);

			Assert.True(actual);
		}

		[Theory]
		[InlineData(2, 1, 1)]
		[InlineData(0, 1, 2)]
		[InlineData(3, -1, 1)]
		[InlineData(5, 10, 1)]
		[InlineData(null, 1, 10)]
		public void Test_IsBetween_Nullable_False(int? a, int from, int till)
		{
			var actual = a.IsBetween<int>(from, till);

			Assert.False(actual);
		}

		[Theory]
		[InlineData(1, 1, 1, 1)]
		[InlineData(1, 1, 2, 1)]
		[InlineData(2, 1, 2, 2)]
		[InlineData(0, -1, 1, 0)]
		[InlineData(10, 1, 1, 0)]
		public void Test_BetweenOrDefault_True(int a, int from, int till, int expected)
		{
			var actual = a.BetweenOrDefault<int>(from, till);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1, 1, 1)]
		[InlineData(1, 1, 2, 1)]
		[InlineData(2, 1, 2, 2)]
		[InlineData(0, -1, 1, 0)]
		[InlineData(10, 1, 1, null)]
		[InlineData(null, 1, 1, null)]
		public void Test_BetweenOrDefault_Nullable_True(int? a, int from, int till, int? expected)
		{
			var actual = a.BetweenOrDefault<int>(from, till);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1, 1, 11, 1)]
		[InlineData(1, 1, 2, 11, 1)]
		[InlineData(2, 1, 2, 11, 2)]
		[InlineData(0, -1, 1, 11, 0)]
		[InlineData(10, 1, 1, 11, 11)]
		public void Test_BetweenOr_True(int a, int from, int till, int orValue, int expected)
		{
			var actual = a.BetweenOr<int>(from, till, orValue);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 1, 1, 11, 1)]
		[InlineData(1, 1, 2, 11, 1)]
		[InlineData(2, 1, 2, 11, 2)]
		[InlineData(0, -1, 1, 11, 0)]
		[InlineData(10, 1, 1, 11, 11)]
		[InlineData(null, 1, 1, 11, 11)]
		public void Test_BetweenOr_Nullable_True(int? a, int from, int till, int orValue, int expected)
		{
			var actual = a.BetweenOr<int>(from, till, orValue);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(0)]
		public void Test_IsDefault_True(int? a)
		{
			var actual = a.IsDefault();

			Assert.True(actual);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(-1)]
		[InlineData(int.MaxValue)]
		public void Test_IsDefault_False(int? a)
		{
			var actual = a.IsDefault();

			Assert.False(actual);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(-1)]
		[InlineData(int.MaxValue)]
		public void Test_IsNotDefault_True(int a)
		{
			var actual = a.IsNotDefault();

			Assert.True(actual);
		}

		[Theory]
		[InlineData(0)]
		public void Test_IsNotDefault_False(int a)
		{
			var actual = a.IsNotDefault();

			Assert.False(actual);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(-1)]
		[InlineData(int.MaxValue)]
		public void Test_IsNotDefault_Nullable_True(int? a)
		{
			var actual = a.IsNotDefault();

			Assert.True(actual);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(0)]
		public void Test_IsNotDefault_Nullable_False(int? a)
		{
			var actual = a.IsNotDefault();

			Assert.False(actual);
		}

		[Theory]
		[InlineData(1, 2, 1)]
		[InlineData(0, 2, 2)]
		[InlineData(0, 0, 0)]
		public void Test_DefaultOr_True(int a, int b, int expected)
		{
			var actual = a.DefaultOr(b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 2, 1)]
		[InlineData(0, 2, 2)]
		[InlineData(0, 0, 0)]
		[InlineData(null, 0, 0)]
		public void Test_DefaultOr_Nullable_A_True(int? a, int b, int expected)
		{
			var actual = a.DefaultOr(b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 2, 1)]
		[InlineData(0, 2, 2)]
		[InlineData(0, 0, 0)]
		[InlineData(0, null, null)]
		public void Test_DefaultOr_Nullable_B_True(int a, int? b, int? expected)
		{
			var actual = a.DefaultOr(b);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(1, 2, 1)]
		[InlineData(0, 2, 2)]
		[InlineData(0, 0, 0)]
		[InlineData(null, 0, 0)]
		[InlineData(0, null, null)]
		[InlineData(null, null, null)]
		public void Test_DefaultOr_Nullable_AB_True(int? a, int? b, int? expected)
		{
			var actual = a.DefaultOr(b);

			Assert.Equal(expected, actual);
		}
	}
}
