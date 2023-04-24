using UnityEngine;

namespace Common.Logic.Factory
{
	public abstract class Factory_SO<T> : ScriptableObject, IFactory<T>
	{
		public abstract T Create();
	}
}
