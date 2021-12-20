using System;

namespace HandyTools.Helper;
public class SingletonValue<TValue>
{
	private bool _HasValue;
	private TValue _Value;
	private readonly Func<TValue> _Getter;

	internal SingletonValue(Func<TValue> getter) => this._Getter = getter;

	public TValue Value
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