
namespace Core
{
    public interface ISpendable
    {
        bool IsValid(IValidatorFactory validatorFactory);
    }
}
