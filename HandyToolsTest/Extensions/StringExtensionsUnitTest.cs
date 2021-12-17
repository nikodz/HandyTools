using System;
using HandyTools.Extensions;
using Xunit;

namespace HandyToolsTest.Extensions;

public class StringExtensionsUnitTest
{
	#region ToValue
	[Fact]
	public void Test_ToValue_Int()
	{
		var original = 10;
		var input = original.ToString();
		var actual = input.ToValue<int>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValue_Double()
	{
		var original = -10.15123D;
		var input = original.ToString();
		var actual = input.ToValue<double>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValue_Throws_ArgumentNull()
	{
		string input = null;
		Action act = () => input.ToValue<double>();
		Assert.Throws<ArgumentNullException>(act);
	}

	private struct TestStruct { }
	[Fact]
	public void Test_ToValue_Throws_MissingMethod()
	{
		var input = string.Empty;
		Assert.Throws<MissingMethodException>(() => input.ToValue<TestStruct>());
	}

	[Fact]
	public void Test_ToValue_Throws_Argument()
	{
		var input = string.Empty;
		Assert.Throws<ArgumentException>(() => input.ToValue<int>());
	}
	#endregion

	#region ToValueOrDefault
	[Fact]
	public void Test_ToValueOrDefault_Int_Value()
	{
		var original = 10;
		var input = original.ToString();
		var actual = input.ToValueOrDefault<int>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValueOrDefault_Int_Default()
	{
		var input = string.Empty;
		var actual = input.ToValueOrDefault<int>();
		Assert.Equal(0, actual);
	}
	[Fact]
	public void Test_ToValueOrDefault_Double_Value()
	{
		var original = -10.364233;
		var input = original.ToString();
		var actual = input.ToValueOrDefault<double>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValueOrDefault_Double_Default()
	{
		var input = string.Empty;
		var actual = input.ToValueOrDefault<double>();
		Assert.Equal(0, actual);
	}
	#endregion

	#region ToValueOrNull
	[Fact]
	public void Test_ToValueOrNull_Int_Value()
	{
		var original = 10;
		var input = original.ToString();
		var actual = input.ToValueOrNull<int>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValueOrNull_Int_Null()
	{
		var input = string.Empty;
		var actual = input.ToValueOrNull<int>();
		Assert.Null(actual);
	}
	[Fact]
	public void Test_ToValueOrNull_Double_Value()
	{
		var original = -10.364233;
		var input = original.ToString();
		var actual = input.ToValueOrNull<double>();
		Assert.Equal(original, actual);
	}

	[Fact]
	public void Test_ToValueOrNull_Double_Null()
	{
		var input = string.Empty;
		var actual = input.ToValueOrNull<double>();
		Assert.Null(actual);
	}
	#endregion

	#region IsEmpty
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("\t")]
	[InlineData("\r")]
	[InlineData("\n")]
	public void Test_IsEmpty_True(string input)
	{
		var actual = input.IsEmpty();
		Assert.True(actual);
	}

	[Theory]
	[InlineData("a")]
	public void Test_IsEmpty_False(string input)
	{
		var actual = input.IsEmpty();
		Assert.False(actual);
	}
	#endregion

	#region IsNotEmpty
	[Theory]
	[InlineData("a")]
	public void Test_IsNotEmpty_True(string input)
	{
		var actual = input.IsNotEmpty();
		Assert.True(actual);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("\t")]
	[InlineData("\r")]
	[InlineData("\n")]
	public void Test_IsNotEmpty_False(string input)
	{
		var actual = input.IsNotEmpty();
		Assert.False(actual);
	}
	#endregion

	#region IfEmpty
	[Theory]
	[InlineData("a", "b")]
	public void Test_IfEmpty_ReturnInput(string input, string then)
	{
		var actual = input.IfEmpty(then);
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public void Test_IfEmpty_ReturnThen(string input, string then)
	{
		var actual = input.IfEmpty(then);
		Assert.Equal(then, actual);
	}
	#endregion
}