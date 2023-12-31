using System;
using Core;
using UnityEngine;

namespace Health.Reward
{
    [Serializable]
    public class HealthReward : IReward
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public void AddReward(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<HealthStrategy>().AddReward(this);
        }
    }
}