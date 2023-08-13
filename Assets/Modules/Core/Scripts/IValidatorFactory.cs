namespace Core
{
    public interface IValidatorFactory
    {
        bool IsValidSpend<T>(T spendable) where T : ISpendable;
    }
}