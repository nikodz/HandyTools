using HandyTools.Helper;
using Xunit;

namespace HandyToolsTest.Helper;

public class SingletonValueUnitTest
{
	[Fact]
	public void SingletonValue_CallingOnlyOnce_Integer()
	{
		var counter = 0;
		var singleValue = new SingletonValue<int>(() => ++counter - 1);
		var a = singleValue.Value;
		var b = singleValue.Value;
		Assert.Equal(1, counter);
		Assert.Equal(0, a);
		Assert.Equal(0, b);
	}

	[Fact]
	public void SingletonValue_CallingOnlyOnce_String()
	{
		var counter = 0;
		var singleValue = new SingletonValue<string>(() => "test" + ++counter);
		var a = singleValue.Value;
		var b = singleValue.Value;
		Assert.Equal(1, counter);
		Assert.Equal("test1", a);
		Assert.Equal("test1", b);
	}
}