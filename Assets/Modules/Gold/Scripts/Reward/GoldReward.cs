using System;
using Core;
using UnityEngine;

namespace Gold.Reward
{
    [Serializable]
    public class GoldReward : IReward
    {
        [SerializeField] private int _amount;

    }
}