using System.Threading.Tasks;
using HandyTools.Helper;
using Xunit;

namespace HandyToolsTest.Helper
{
	public class SingletonValueAsyncUnitTest
	{
		[Fact]
		public async Task SingletonValueAsync_CallingOnlyOnce_Integer()
		{
			var counter = 0;
			var singleValue = new SingletonValueAsync<int>(async () => { counter++; return counter - 1; });
			var a = await singleValue.Get();
			var b = await singleValue.Get();
			Assert.Equal(1, counter);
			Assert.Equal(0, a);
			Assert.Equal(0, b);
		}

		[Fact]
		public async Task SingletonValueAsync_CallingOnlyOnce_String()
		{
			var counter = 0;
			var singleValue = new SingletonValueAsync<string>(async () => { counter++; return "test" + counter; });
			var a = await singleValue.Get();
			var b = await singleValue.Get();
			Assert.Equal(1, counter);
			Assert.Equal("test1", a);
			Assert.Equal("test1", b);
		}
	}
}