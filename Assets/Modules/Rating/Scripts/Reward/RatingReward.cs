using System;
using Core;
using UnityEngine;

namespace Rating.Reward
{
    [Serializable]
    public class RatingReward : IReward
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public void AddReward(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<RatingStrategy>().AddReward(this);
        }
    }
}