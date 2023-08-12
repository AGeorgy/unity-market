using System;
using Core;
using UnityEngine;

namespace Health.Reward
{
    [Serializable]
    public class PercentHealthReward : IReward
    {
        [SerializeField] private int _percent;
    }
}