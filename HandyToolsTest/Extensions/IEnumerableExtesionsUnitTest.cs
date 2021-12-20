using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyTools.Extensions;
using HandyTools.Helper;
using Xunit;

namespace HandyToolsTest.Extensions;

public class IEnumerableExtesionsUnitTest
{
	#region IsNotEmpty
	[Fact]
	public void Test_IsNotEmpty_SingleElement()
	{
		var input = new List<int> { 1 };
		var actual = input.IsNotEmpty();
		Assert.True(actual);
	}

	[Fact]
	public void Test_IsNotEmpty_ForNull()
	{
		IEnumerable<int> input = null;
		var actual = input.IsNotEmpty();
		Assert.False(actual);
	}

	[Fact]
	public void Test_IsNotEmpty_ForEmptyLit()
	{
		var input = new List<int>();
		var actual = input.IsNotEmpty();
		Assert.False(actual);
	}
	#endregion

	#region IsNullOrEmpty
	[Fact]
	public void Test_IsNullOrEmpty_SingleElement()
	{
		var input = new List<int> { 1 };
		var actual = input.IsNullOrEmpty();
		Assert.False(actual);
	}

	[Fact]
	public void Test_IsNullOrEmpty_ForNull()
	{
		IEnumerable<int> input = null;
		var actual = input.IsNullOrEmpty();
		Assert.True(actual);
	}

	[Fact]
	public void Test_IsNullOrEmpty_ForEmptyLit()
	{
		var input = new List<int>();
		var actual = input.IsNullOrEmpty();
		Assert.True(actual);
	}
	#endregion

	#region NotContains
	[Fact]
	public void Test_NotContains_Contains()
	{
		var input = new List<int> { 1, 2 };
		var actual = input.NotContains(2);
		Assert.False(actual);
	}
	[Fact]
	public void Test_NotContains_NotContains()
	{
		var input = new List<int> { 1, 3 };
		var actual = input.NotContains(2);
		Assert.True(actual);
	}

	[Fact]
	public void Test_NotContains_ForEmptyLit()
	{
		var input = new List<int>();
		var actual = input.NotContains(1);
		Assert.True(actual);
	}
	#endregion

	#region NullIfEmpty
	[Fact]
	public void Test_NullIfEmpty_SingleElement()
	{
		var input = new List<int> { 1 };
		var actual = input.NullIfEmpty();
		Assert.NotNull(actual);
	}

	[Fact]
	public void Test_NullIfEmpty_Null()
	{
		IEnumerable<int> input = null;
		var actual = input.NullIfEmpty();
		Assert.Null(actual);
	}

	[Fact]
	public void Test_NullIfEmpty_Empty()
	{
		var input = new List<int>();
		var actual = input.NullIfEmpty();
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty
	[Fact]
	public void Test_IfEmpty_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(then);
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Test_IfEmpty_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(then);
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(then);
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = input.IfEmpty(then);
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty SingletonValue
	[Fact]
	public void Test_IfEmpty_SingletonValue_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(Singleton.Create<IEnumerable<int>>(() => then));
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Test_IfEmpty_SingletonValue_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(Singleton.Create<IEnumerable<int>>(() => then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_SingletonValue_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(Singleton.Create<IEnumerable<int>>(() => then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_SingletonValue_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = input.IfEmpty(Singleton.Create<IEnumerable<int>>(() => then));
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty SingletonValueAsync
	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(input, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = await input.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty SingletonValueAsync Chain
	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)input)))
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(input, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)input)))
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)input)))
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_SingletonValueAsync_Chain_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = await input
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)input)))
			.IfEmpty(Singleton.CreateAsync(() => Task.FromResult((IEnumerable<int>)then)));
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty Expression
	[Fact]
	public void Test_IfEmpty_Expression_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(() => then);
		Assert.Equal(input, actual);
	}

	[Fact]
	public void Test_IfEmpty_Expression_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(() => then);
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_Expression_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = input.IfEmpty(() => then);
		Assert.Equal(then, actual);
	}

	[Fact]
	public void Test_IfEmpty_Expression_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = input.IfEmpty(() => then);
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty Expression Async
	[Fact]
	public async Task Test_IfEmpty_Expression_Async_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(input, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Async_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Async_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = await input.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Async_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = await input.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Null(actual);
	}
	#endregion

	#region IfEmpty Expression Async Chain
	[Fact]
	public async Task Test_IfEmpty_Expression_Chain_SingleElement()
	{
		var input = new List<int> { 1 };
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)input))
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(input, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Chain_Null()
	{
		IEnumerable<int> input = null;
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)input))
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Chain_Empty()
	{
		var input = new List<int>();
		var then = new List<int> { 2 };
		var actual = await input
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)input))
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Equal(then, actual);
	}

	[Fact]
	public async Task Test_IfEmpty_Expression_Chain_InputEmpty_ThenNull()
	{
		var input = new List<int>();
		IEnumerable<int> then = null;
		var actual = await input
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)input))
			.IfEmpty(() => Task.FromResult((IEnumerable<int>)then));
		Assert.Null(actual);
	}
	#endregion

	#region GetChildren
	private class TestModel
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public static implicit operator TestModel((int id, int? parent) data)
			=> new TestModel { Id = data.id, ParentId = data.parent };
	}

	[Fact]
	public void Test_GetChildren_Throw_ArgumentNull_List()
	{
		List<TestModel> list = null;
		Action act = () => list.GetChildren((1, 2), i => i.Id, i => i.ParentId).ToList();
		Assert.Throws<ArgumentNullException>(act);
	}

	[Fact]
	public void Test_GetChildren_Throw_ArgumentNull_Item()
	{
		var list = new List<TestModel> { (1, 2) };
		Action act = () => list.GetChildren(null, i => i.Id, i => i.ParentId).ToList();
		Assert.Throws<ArgumentNullException>(act);
	}

	[Fact]
	public void Test_GetChildren_Throw_ArgumentNull_GetKey()
	{
		var list = new List<TestModel> { (1, 2) };
		Action act = () => list.GetChildren(list[0], null, i => i.ParentId).ToList();
		Assert.Throws<ArgumentNullException>(act);
	}

	[Fact]
	public void Test_GetChildren_Throw_ArgumentNull_GetParentKey()
	{
		var list = new List<TestModel> { (1, 2) };
		Action act = () => list.GetChildren(list[0], i => i.Id, null).ToList();
		Assert.Throws<ArgumentNullException>(act);
	}

	[Fact]
	public void Test_GetChildren()
	{
		var list = new List<TestModel> {
				(1, null),
				(2, 1),
				(3, 1),
				(4, 2),
				(5, 4)
			};
		var children = list.GetChildren(list[1], i => i.Id, i => i.ParentId);
		Assert.DoesNotContain(list[0], children);
		Assert.Contains(list[1], children);
		Assert.DoesNotContain(list[2], children);
		Assert.Contains(list[3], children);
		Assert.Contains(list[4], children);
	}
	#endregion
}