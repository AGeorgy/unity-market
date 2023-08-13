
using Core;
using Gold.Model;
using Gold.Spendable;
using Health.Model;
using Health.Spendable;
using Rating.Model;
using Rating.Spendable;

public class Spender : ISpender
{
    private IGoldModel _goldModel;
    private IHealthModel _healthModel;
    private IRatingModel _ratingModel;

    public Spender(IGoldModel goldModel, IHealthModel healthModel, IRatingModel ratingModel)
    {
        _goldModel = goldModel;
        _healthModel = healthModel;
        _ratingModel = ratingModel;
    }

    public void Spend<T>(T spendable) where T : ISpendable
    {
        if (typeof(T) == typeof(GoldSpendable))
        {
            var spendableGold = spendable as GoldSpendable;
            _goldModel.Gold -= spendableGold.Amount;
        }
        else if (typeof(T) == typeof(HealthSpendable))
        {
            var spendableHealth = spendable as HealthSpendable;
            _healthModel.Health -= spendableHealth.Amount;
        }
        else if (typeof(T) == typeof(PercentHealthSpendable))
        {
            var spendableHealth = spendable as PercentHealthSpendable;
            _healthModel.Health -= _healthModel.Health * spendableHealth.Percent / 100;
        }
        else if (typeof(T) == typeof(RatingSpendable))
        {
            var spendableRating = spendable as RatingSpendable;
            _ratingModel.Rating -= spendableRating.Amount;
        }
    }
}