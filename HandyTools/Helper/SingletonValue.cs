using System;

namespace HandyTools.Helper;

public class SingletonValue<T>
{
	private bool _HasValue;
	private T _Value;
	private readonly Func<T> _Getter;

	public SingletonValue(Func<T> getter)
	{
		this._Getter = getter;
	}

	public T Value
	{
		get
		{
			if (!_HasValue)
			{
				_Value = this._Getter();
				_HasValue = true;
			}
			return _Value;
		}
	}
}