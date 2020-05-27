using System.Threading.Tasks;
using HandyTools.Helper;
using Xunit;

namespace HandyToolsTest.Helper
{
	public class SingletonObjectUnitTest
	{
		[Fact]
		public async Task SingletonValue_CallingOnlyOnce_Integer()
		{
			var counter = 0;
			var singleValue = new SingletonValue<int>(async () => { counter++; return counter - 1; });
			var a = await singleValue.Get();
			var b = await singleValue.Get();
			Assert.Equal(1, counter);
			Assert.Equal(0, a);
			Assert.Equal(0, b);
		}

		[Fact]
		public async Task SingletonValue_CallingOnlyOnce_String()
		{
			var counter = 0;
			var singleValue = new SingletonValue<string>(async () => { counter++; return "test" + counter; });
			var a = await singleValue.Get();
			var b = await singleValue.Get();
			Assert.Equal(1, counter);
			Assert.Equal("test1", a);
			Assert.Equal("test1", b);
		}
	}
}