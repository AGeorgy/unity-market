
namespace Core
{
    public interface ISpendable
    {
        bool IsValid(IResourceStrategyFactory resourceStrategyFactory);
        void Spend(IResourceStrategyFactory resourceStrategyFactory);
    }
}
