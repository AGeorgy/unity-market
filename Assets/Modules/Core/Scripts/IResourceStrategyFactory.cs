namespace Core
{
    public interface IResourceStrategyFactory
    {
        IResourceStrategy GetStrategy<T>();
    }
}