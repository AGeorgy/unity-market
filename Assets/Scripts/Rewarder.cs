
using Core;
using Gold.Model;
using Gold.Reward;
using Health.Model;
using Health.Reward;
using Rating.Model;
using Rating.Reward;

public class Rewarder : IRewarder
{
    private IGoldModel _goldModel;
    private IHealthModel _healthModel;
    private IRatingModel _ratingModel;

    public Rewarder(IGoldModel goldModel, IHealthModel healthModel, IRatingModel ratingModel)
    {
        _goldModel = goldModel;
        _healthModel = healthModel;
        _ratingModel = ratingModel;
    }

    public void AddReward<T>(T reward) where T : IReward
    {
        if (typeof(T) == typeof(GoldReward))
        {
            var rewardGold = reward as GoldReward;
            _goldModel.Gold += rewardGold.Amount;
        }
        else if (typeof(T) == typeof(HealthReward))
        {
            var rewardHealth = reward as HealthReward;
            _healthModel.Health += rewardHealth.Amount;
        }
        else if (typeof(T) == typeof(PercentHealthReward))
        {
            var rewardHealth = reward as PercentHealthReward;
            _healthModel.Health += _healthModel.Health * rewardHealth.Percent / 100;
        }
        else if (typeof(T) == typeof(RatingReward))
        {
            var rewardRating = reward as RatingReward;
            _ratingModel.Rating += rewardRating.Amount;
        }
    }
}