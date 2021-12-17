using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions;

public class BitOperationsRemoveBitUnitTest
{
	#region byte
	[Theory]
	[InlineData(1, 0)]
	[InlineData(8, 0x0)]
	public void Test_RemoveBit_Byte_ToZero(int bit, byte expected)
	{
		var actual = ((byte)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0xFF, 8, 0x7F)]
	public void Test_RemoveBit_Byte_ToNumber(byte number, int bit, byte expected)
	{
		var actual = ((byte)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 0)]
	[InlineData(7, 0x0)]
	public void Test_RemoveBit_SByte_ToZero(int bit, sbyte expected)
	{
		var actual = ((sbyte)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0x7F, 7, 0x3F)]
	public void Test_RemoveBit_SByte_ToNumber(sbyte number, int bit, sbyte expected)
	{
		var actual = ((sbyte)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region short
	[Theory]
	[InlineData(1, 0)]
	[InlineData(15, 0x0)]
	public void Test_RemoveBit_Shorte_ToZero(int bit, short expected)
	{
		var actual = ((short)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0x7FFF, 15, 0x3FFF)]
	public void Test_RemoveBit_Short_ToNumber(short number, int bit, short expected)
	{
		var actual = ((short)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 0)]
	[InlineData(16, 0x0)]
	public void Test_RemoveBit_UShort_ToZero(int bit, ushort expected)
	{
		var actual = ((ushort)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0xFFFF, 16, 0x7FFF)]
	public void Test_RemoveBit_UShort_ToNumber(ushort number, int bit, ushort expected)
	{
		var actual = ((ushort)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region int
	[Theory]
	[InlineData(1, 0)]
	[InlineData(31, 0x0)]
	public void Test_RemoveBit_Int_ToZero(int bit, int expected)
	{
		var actual = ((int)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0x7FFFFFFF, 31, 0x3FFFFFFF)]
	public void Test_RemoveBit_Int_ToNumber(int number, int bit, int expected)
	{
		var actual = ((int)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 0)]
	[InlineData(32, 0x0)]
	public void Test_RemoveBit_UInte_ToZero(int bit, uint expected)
	{
		var actual = ((uint)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0xFFFFFFFF, 32, 0x7FFFFFFF)]
	public void Test_RemoveBit_UInt_ToNumber(uint number, int bit, uint expected)
	{
		var actual = ((uint)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region long
	[Theory]
	[InlineData(1, 0)]
	[InlineData(63, 0x0)]
	public void Test_RemoveBit_Long_ToZero(int bit, long expected)
	{
		var actual = ((long)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0x7FFFFFFFFFFFFFFF, 63, 0x3FFFFFFFFFFFFFFF)]
	public void Test_RemoveBit_Long_ToNumber(long number, int bit, long expected)
	{
		var actual = ((long)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 0)]
	[InlineData(64, 0x0)]
	public void Test_RemoveBit_ULonge_ToZero(int bit, ulong expected)
	{
		var actual = ((ulong)0).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 0)]
	[InlineData(3, 1, 2)]
	[InlineData(0xFFFFFFFFFFFFFFFF, 64, 0x7FFFFFFFFFFFFFFF)]
	public void Test_RemoveBit_ULong_ToNumber(ulong number, int bit, ulong expected)
	{
		var actual = ((ulong)number).RemoveBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion
}