using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions;

public class BitOperationsPutBitUnitTest
{
	#region byte
	[Theory]
	[InlineData(1, 1)]
	[InlineData(8, 0x80)]
	public void Test_PutBit_Byte_ToZero(int bit, byte expected)
	{
		var actual = ((byte)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x7F, 8, 0xFF)]
	public void Test_PutBit_Byte_ToNumber(byte number, int bit, byte expected)
	{
		var actual = ((byte)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1)]
	[InlineData(7, 0x40)]
	public void Test_PutBit_SByte_ToZero(int bit, sbyte expected)
	{
		var actual = ((sbyte)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x3F, 7, 0x7F)]
	public void Test_PutBit_SByte_ToNumber(sbyte number, int bit, sbyte expected)
	{
		var actual = ((sbyte)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region short
	[Theory]
	[InlineData(1, 1)]
	[InlineData(15, 0x4000)]
	public void Test_PutBit_Shorte_ToZero(int bit, short expected)
	{
		var actual = ((short)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x3FFF, 15, 0x7FFF)]
	public void Test_PutBit_Short_ToNumber(short number, int bit, short expected)
	{
		var actual = ((short)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1)]
	[InlineData(16, 0x8000)]
	public void Test_PutBit_UShort_ToZero(int bit, ushort expected)
	{
		var actual = ((ushort)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x7FFF, 16, 0xFFFF)]
	public void Test_PutBit_UShort_ToNumber(ushort number, int bit, ushort expected)
	{
		var actual = ((ushort)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region int
	[Theory]
	[InlineData(1, 1)]
	[InlineData(31, 0x40000000)]
	public void Test_PutBit_Int_ToZero(int bit, int expected)
	{
		var actual = ((int)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x3FFFFFFF, 31, 0x7FFFFFFF)]
	public void Test_PutBit_Int_ToNumber(int number, int bit, int expected)
	{
		var actual = ((int)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1)]
	[InlineData(32, 0x80000000)]
	public void Test_PutBit_UInte_ToZero(int bit, uint expected)
	{
		var actual = ((uint)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x7FFFFFFF, 32, 0xFFFFFFFF)]
	public void Test_PutBit_UInt_ToNumber(uint number, int bit, uint expected)
	{
		var actual = ((uint)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion

	#region long
	[Theory]
	[InlineData(1, 1)]
	[InlineData(63, 0x4000000000000000)]
	public void Test_PutBit_Long_ToZero(int bit, long expected)
	{
		var actual = ((long)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x3FFFFFFFFFFFFFFF, 63, 0x7FFFFFFFFFFFFFFF)]
	public void Test_PutBit_Long_ToNumber(long number, int bit, long expected)
	{
		var actual = ((long)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1)]
	[InlineData(64, 0x8000000000000000)]
	public void Test_PutBit_ULonge_ToZero(int bit, ulong expected)
	{
		var actual = ((ulong)0).PutBit(bit);
		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(1, 1, 1)]
	[InlineData(2, 1, 3)]
	[InlineData(0x7FFFFFFFFFFFFFFF, 64, 0xFFFFFFFFFFFFFFFF)]
	public void Test_PutBit_ULong_ToNumber(ulong number, int bit, ulong expected)
	{
		var actual = ((ulong)number).PutBit(bit);
		Assert.Equal(expected, actual);
	}
	#endregion
}