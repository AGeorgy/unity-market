
using Core;
using Gold.Model;
using Gold.Reward;
using Gold.Spendable;

namespace Gold
{
    public class GoldStrategy : IResourceStrategy
    {
        private IGoldModel _model;

        public GoldStrategy(IGoldModel model)
        {
            _model = model;
        }
        public void AddReward<T>(T reward) where T : IReward
        {
            var rewardGold = reward as GoldReward;
            _model.Gold += rewardGold.Amount;
        }

        public bool IsValidSpend<T>(T spendable) where T : ISpendable
        {
            var spendableGold = spendable as GoldSpendable;
            return _model.Gold - spendableGold.Amount >= 0;
        }

        public void Spend<T>(T spendable) where T : ISpendable
        {
            var spendableGold = spendable as GoldSpendable;
            _model.Gold -= spendableGold.Amount;
        }
    }
}