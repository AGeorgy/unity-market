namespace Core
{
    public interface IValidator
    {
        bool IsValidSpend<T>(T spendable) where T : ISpendable;
    }
}