namespace Common.Logic.Factory
{
	public interface IFactory<T>
	{
		T Create();
	}
}
