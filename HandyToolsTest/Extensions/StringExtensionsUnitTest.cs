using System;
using System.Threading.Tasks;
using HandyTools.Extensions;
using HandyTools.Helper;
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

	#region IsNotEmpty Then
	[Fact]
	public async Task Test_IsNotEmpty_Then()
	{
		string stringNull = null;
		var stringEmpty = string.Empty;
		Assert.Equal(0, stringEmpty.IsNotEmpty(() => 1));
		Assert.Equal(0, stringNull.IsNotEmpty(() => 2));
		Assert.Equal(0, await stringEmpty.IsNotEmpty(() => Task.FromResult(3)));
		Assert.Equal(0, await stringNull.IsNotEmpty(() => Task.FromResult(4)));
		Assert.Equal(5, "5".IsNotEmpty(() => 5));
		Assert.Equal(6, await "6".IsNotEmpty(() => Task.FromResult(6)));
		Assert.Equal(7, "7".IsNotEmpty(input => input.ToValue<int>()));
		Assert.Equal(8, await "8".IsNotEmpty(input => Task.FromResult(input.ToValue<int>())));
		Assert.Equal("9", "9".IsNotEmpty(input => input));
		Assert.Equal("10", await "10".IsNotEmpty(input => Task.FromResult(input)));
	}
	#endregion

	#region NotContains
	[Theory]
	[InlineData("", "a")]
	[InlineData("abcdfgh", "e")]
	[InlineData("a", "b")]
	public void Test_NotContains_True(string input, string search)
	{
		var actual = input.NotContains(search);
		Assert.True(actual);
	}

	[Theory]
	[InlineData("a", "a")]
	[InlineData("abcdefgh", "e")]
	public void Test_NotContains_False(string input, string search)
	{
		var actual = input.NotContains(search);
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

	#region IfEmpty SingletonValue
	[Theory]
	[InlineData("a", "b")]
	public void Test_IfEmpty_SingletonValue_ReturnInput(string input, string then)
	{
		var actual = input.IfEmpty(new SingletonValue<string>(() => then));
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public void Test_IfEmpty_SingletonValue_ReturnThen(string input, string then)
	{
		var actual = input.IfEmpty(new SingletonValue<string>(() => then));
		Assert.Equal(then, actual);
	}
	#endregion

	#region IfEmpty SingletonValueAsync
	[Theory]
	[InlineData("a", "b")]
	public async Task Test_IfEmpty_SingletonValueAsync_ReturnInput(string input, string then)
	{
		var actual = await input.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(then)));
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public async Task Test_IfEmpty_SingletonValueAsync_ReturnThen(string input, string then)
	{
		var actual = await input.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(then)));
		Assert.Equal(then, actual);
	}
	#endregion

	#region IfEmpty SingletonValueAsync chain
	[Theory]
	[InlineData("a", "b")]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_ReturnInput(string input, string then)
	{
		var actual = await input
			.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(input)))
			.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(then)));
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_ReturnThen(string input, string then)
	{
		var actual = await input
			.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(input)))
			.IfEmpty(new SingletonValueAsync<string>(() => Task.FromResult(then)));
		Assert.Equal(then, actual);
	}
	#endregion

	#region IfEmpty Expression
	[Theory]
	[InlineData("a", "b")]
	public void Test_IfEmpty_Expression_ReturnInput(string input, string then)
	{
		var actual = input.IfEmpty(() => then);
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public void Test_IfEmpty_Expression_ReturnThen(string input, string then)
	{
		var actual = input.IfEmpty(() => then);
		Assert.Equal(then, actual);
	}
	#endregion

	#region IfEmpty Expression Async
	[Theory]
	[InlineData("a", "b")]
	public async Task Test_IfEmpty_Expression_Async_ReturnInput(string input, string then)
	{
		var actual = await input.IfEmpty(() => Task.FromResult(then));
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public async Task Test_IfEmpty_Expression_Async_ReturnThen(string input, string then)
	{
		var actual = await input.IfEmpty(() => Task.FromResult(then));
		Assert.Equal(then, actual);
	}
	#endregion

	#region IfEmpty Expression Async chain
	[Theory]
	[InlineData("a", "b")]
	public async Task Test_IfEmpty_Expression_Async_Chain_ReturnInput(string input, string then)
	{
		var actual = await input
			.IfEmpty(() => Task.FromResult(input))
			.IfEmpty(() => Task.FromResult(then));
		Assert.Equal(input, actual);
	}

	[Theory]
	[InlineData(null, "a")]
	[InlineData("", "a")]
	[InlineData(" ", "a")]
	[InlineData("\t", "a")]
	[InlineData("\r", "a")]
	[InlineData("\n", "a")]
	public async Task Test_IfEmpty_Expression_Async_Chain_ReturnThen(string input, string then)
	{
		var actual = await input
			.IfEmpty(() => Task.FromResult(input))
			.IfEmpty(() => Task.FromResult(then));
		Assert.Equal(then, actual);
	}
	#endregion
}