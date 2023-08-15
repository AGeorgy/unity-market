using System;
using Core;
using UnityEngine;

namespace Gold.Reward
{
    [Serializable]
    public class GoldReward : IReward
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public void AddReward(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<GoldStrategy>().AddReward(this);
        }

    }
}