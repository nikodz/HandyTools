using System;
using System.Collections.Generic;
using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions;

public class BitOperationsUnitTest
{
	private static IEnumerable<object[]> GetHasBitDataForUnsigned<T>(int size)
	where T : struct
	{
		size *= 8;
		for (int power = 1; power < size; power++)
		{
			var number = 1UL << power; // 2^power
			T castedNumber = (T)Convert.ChangeType(number, typeof(T));
			yield return new object[] { castedNumber, power + 1 };
			number--; // 2^power - 1
			castedNumber = (T)Convert.ChangeType(number, typeof(T));
			for (int bit = 1; bit <= power; bit++)
			{
				yield return new object[] { castedNumber, bit };
			}
		}
	}
	private static IEnumerable<object[]> GetHasBitDataForSigned<T>(int size)
	where T : struct
	{
		size *= 8;
		T castedNumber;
		for (int power = 1; power < size; power++)
		{
			var number = 1UL << power; // 2^power
			if (power < size - 1)
			{
				castedNumber = (T)Convert.ChangeType(number, typeof(T));
				yield return new object[] { castedNumber, power + 1 };
			}
			number--; // 2^power - 1
			castedNumber = (T)Convert.ChangeType(number, typeof(T));
			for (int bit = 1; bit <= power; bit++)
			{
				yield return new object[] { castedNumber, bit };
			}
		}
	}

	#region byte
	[Theory]
	[MemberData(nameof(HasBit_Byte_Data))]
	public void Test_HasBit_Byte_True(byte number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	[Theory]
	[MemberData(nameof(HasBit_SByte_Data))]
	public void Test_HasBit_SByte_True(sbyte number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	public static IEnumerable<object[]> HasBit_Byte_Data
		=> GetHasBitDataForUnsigned<byte>(sizeof(byte));

	public static IEnumerable<object[]> HasBit_SByte_Data
		=> GetHasBitDataForSigned<sbyte>(sizeof(sbyte));
	#endregion

	#region short
	[Theory]
	[MemberData(nameof(HasBit_Short_Data))]
	public void Test_HasBit_Short_True(short number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	[Theory]
	[MemberData(nameof(HasBit_UShort_Data))]
	public void Test_HasBit_UShort_True(ushort number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	public static IEnumerable<object[]> HasBit_Short_Data
		=> GetHasBitDataForSigned<short>(sizeof(short));

	public static IEnumerable<object[]> HasBit_UShort_Data
		=> GetHasBitDataForUnsigned<ushort>(sizeof(ushort));
	#endregion

	#region int
	[Theory]
	[MemberData(nameof(HasBit_Int_Data))]
	public void Test_HasBit_Int_True(int number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	[Theory]
	[MemberData(nameof(HasBit_UInt_Data))]
	public void Test_HasBit_UInt_True(uint number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	public static IEnumerable<object[]> HasBit_Int_Data
		=> GetHasBitDataForSigned<int>(sizeof(int));

	public static IEnumerable<object[]> HasBit_UInt_Data
		=> GetHasBitDataForUnsigned<uint>(sizeof(uint));
	#endregion

	#region long
	[Theory]
	[MemberData(nameof(HasBit_Long_Data))]
	public void Test_HasBit_Long_True(long number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	[Theory]
	[MemberData(nameof(HasBit_ULong_Data))]
	public void Test_HasBit_ULong_True(ulong number, int bit)
	{
		var actual = number.HasBit(bit);
		Assert.True(actual);
	}

	public static IEnumerable<object[]> HasBit_Long_Data
		=> GetHasBitDataForSigned<long>(sizeof(long));

	public static IEnumerable<object[]> HasBit_ULong_Data
		=> GetHasBitDataForUnsigned<ulong>(sizeof(ulong));
	#endregion
}