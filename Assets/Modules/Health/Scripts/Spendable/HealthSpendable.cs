using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class HealthSpendable : ISpendable
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public bool IsValid(IResourceStrategyFactory resourceStrategyFactory)
        {
            return resourceStrategyFactory.GetStrategy<HealthStrategy>().IsValidSpend(this);
        }

        public void Spend(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<HealthStrategy>().Spend(this);
        }
    }
}