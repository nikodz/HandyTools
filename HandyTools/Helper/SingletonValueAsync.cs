using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HandyTools.Helper
{
	public class SingletonValueAsync<T>
	{
		private bool _HasValue;
		private T _Value;
		private readonly Func<Task<T>> _Getter;

		public SingletonValueAsync(Func<Task<T>> getter)
		{
			this._Getter = getter;
		}

		protected async Task<T> Get()
		{
			if (!_HasValue)
			{
				_Value = await this._Getter();
				_HasValue = true;
			}
			return _Value;
		}

		public TaskAwaiter<T> GetAwaiter() => Get().GetAwaiter();
	}
}