using System.Threading.Tasks;
using HandyTools.Helper;
using Xunit;

namespace HandyToolsTest.Helper;

public class SingletonValueAsyncUnitTest
{
	[Fact]
	public async Task SingletonValueAsync_CallingOnlyOnce_Integer()
	{
		var counter = 0;
		var singleValue = Singleton.CreateAsync(async () => await Task.FromResult(++counter - 1));
		var a = await singleValue;
		var b = await singleValue;
		Assert.Equal(1, counter);
		Assert.Equal(0, a);
		Assert.Equal(0, b);
	}

	[Fact]
	public async Task SingletonValueAsync_CallingOnlyOnce_String()
	{
		var counter = 0;
		var singleValue = Singleton.CreateAsync(async () => await Task.FromResult("test" + ++counter));
		var a = await singleValue;
		var b = await singleValue;
		Assert.Equal(1, counter);
		Assert.Equal("test1", a);
		Assert.Equal("test1", b);
	}
}