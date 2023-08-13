namespace Core
{
    public interface ISpender
    {
        void Spend<T>(T spendable) where T : ISpendable;
    }
}