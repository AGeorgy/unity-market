using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class PercentHealthSpendable : ISpendable
    {
        [SerializeField] private int _percent;

        public int Percent => _percent;

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