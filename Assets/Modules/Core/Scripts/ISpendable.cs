
namespace Core
{
    public interface ISpendable
    {
        bool IsValid(IValidator validatorFactory);
        void Spend(ISpender spender);
    }
}
