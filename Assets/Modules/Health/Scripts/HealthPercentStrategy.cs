using Core;
using Health.Model;
using Health.Reward;
using Health.Spendable;

namespace Health
{
    public class HealthPercentStrategy : IResourceStrategy
    {
        private IHealthModel _model;

        public HealthPercentStrategy(IHealthModel model)
        {
            _model = model;
        }
        public void AddReward<T>(T reward) where T : IReward
        {
            var rewardHealth = reward as PercentHealthReward;
            _model.Health += _model.Health * rewardHealth.Percent / 100;
        }

        public bool IsValidSpend<T>(T spendable) where T : ISpendable
        {
            return _model.Health - _model.Health > 0;
        }

        public void Spend<T>(T spendable) where T : ISpendable
        {
            var spendableHealth = spendable as HealthSpendable;
            _model.Health -= spendableHealth.Amount;
        }
    }
}