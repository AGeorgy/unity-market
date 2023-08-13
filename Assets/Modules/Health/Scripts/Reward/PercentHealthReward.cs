using System;
using Core;
using UnityEngine;

namespace Health.Reward
{
    [Serializable]
    public class PercentHealthReward : IReward
    {
        [SerializeField] private int _percent;

        public int Percent => _percent;

        public void AddReward(IRewarder rewarder)
        {
            rewarder.AddReward(this);
        }
    }
}