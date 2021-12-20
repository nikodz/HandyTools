using System;
using System.Threading.Tasks;

namespace HandyTools.Helper;
public static class Singleton
{
	public static SingletonValue<TValue> Create<TValue>(Func<TValue> getter)
		=> new SingletonValue<TValue>(getter);
        
	public static SingletonValueAsync<TValue> CreateAsync<TValue>(Func<Task<TValue>> getter)
		=> new SingletonValueAsync<TValue>(getter);
}