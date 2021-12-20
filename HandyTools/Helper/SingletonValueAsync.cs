using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HandyTools.Helper;
public class SingletonValueAsync<TValue>
{
	private bool _HasValue;
	private TValue _Value;
	private readonly Func<Task<TValue>> _Getter;

	internal SingletonValueAsync(Func<Task<TValue>> getter) => this._Getter = getter;

	protected async Task<TValue> Get()
	{
		if (!_HasValue)
		{
			_Value = await this._Getter();
			_HasValue = true;
		}
		return _Value;
	}

	public TaskAwaiter<TValue> GetAwaiter() => Get().GetAwaiter();
}