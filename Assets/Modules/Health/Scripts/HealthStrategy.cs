using Core;
using Health.Model;
using Health.Reward;
using Health.Spendable;

namespace Health
{
    public class HealthStrategy : IResourceStrategy
    {
        private IHealthModel _model;

        public HealthStrategy(IHealthModel model)
        {
            _model = model;
        }
        public void AddReward<T>(T reward) where T : IReward
        {
            var rewardHealth = reward as HealthReward;
            _model.Health += rewardHealth.Amount;
        }

        public bool IsValidSpend<T>(T spendable) where T : ISpendable
        {
            var spendableHealth = spendable as HealthSpendable;
            return _model.Health - spendableHealth.Amount >= 0;
        }

        public void Spend<T>(T spendable) where T : ISpendable
        {
            var spendableHealth = spendable as HealthSpendable;
            _model.Health -= spendableHealth.Amount;
        }
    }
}