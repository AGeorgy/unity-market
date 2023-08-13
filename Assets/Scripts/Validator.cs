
using Core;
using Gold.Model;
using Gold.Spendable;
using Health.Model;
using Health.Spendable;
using Rating.Model;
using Rating.Spendable;

public class Validator : IValidator
{
    private IGoldModel _goldModel;
    private IHealthModel _healthModel;
    private IRatingModel _ratingModel;

    public Validator(IGoldModel goldModel, IHealthModel healthModel, IRatingModel ratingModel)
    {
        _goldModel = goldModel;
        _healthModel = healthModel;
        _ratingModel = ratingModel;
    }

    public bool IsValidSpend<T>(T spendable) where T : ISpendable
    {
        if (typeof(T) == typeof(GoldSpendable))
        {
            var spendableGold = spendable as GoldSpendable;
            return _goldModel.Gold - spendableGold.Amount >= 0;
        }
        else if (typeof(T) == typeof(HealthSpendable))
        {
            var spendableHealth = spendable as HealthSpendable;
            return _healthModel.Health - spendableHealth.Amount >= 0;
        }
        else if (typeof(T) == typeof(PercentHealthSpendable))
        {
            return _healthModel.Health - _healthModel.Health > 0;
        }
        else if (typeof(T) == typeof(RatingSpendable))
        {
            var spendableRating = spendable as RatingSpendable;
            return _ratingModel.Rating - spendableRating.Amount >= 0;
        }
        else
        {
            return false;
        }
    }
}