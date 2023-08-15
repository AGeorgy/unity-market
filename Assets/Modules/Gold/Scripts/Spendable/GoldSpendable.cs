using System;
using Core;
using UnityEngine;

namespace Gold.Spendable
{
    [Serializable]
    public class GoldSpendable : ISpendable
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public bool IsValid(IResourceStrategyFactory resourceStrategyFactory)
        {
            return resourceStrategyFactory.GetStrategy<GoldStrategy>().IsValidSpend(this);
        }

        public void Spend(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<GoldStrategy>().Spend(this);
        }
    }
}