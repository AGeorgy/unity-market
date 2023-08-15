
using Core;
using Rating.Model;
using Rating.Reward;
using Rating.Spendable;

namespace Rating
{
    public class RatingStrategy : IResourceStrategy
    {
        private IRatingModel _model;

        public RatingStrategy(IRatingModel model)
        {
            _model = model;
        }
        public void AddReward<T>(T reward) where T : IReward
        {
            var rewardRating = reward as RatingReward;
            _model.Rating += rewardRating.Amount;
        }

        public bool IsValidSpend<T>(T spendable) where T : ISpendable
        {
            var spendableRating = spendable as RatingSpendable;
            return _model.Rating - spendableRating.Amount >= 0;
        }

        public void Spend<T>(T spendable) where T : ISpendable
        {
            var spendableRating = spendable as RatingSpendable;
            _model.Rating -= spendableRating.Amount;
        }
    }
}