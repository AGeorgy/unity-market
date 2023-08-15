using System;
using Core;
using UnityEngine;

namespace Rating.Spendable
{
    [Serializable]
    public class RatingSpendable : ISpendable
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;

        public bool IsValid(IResourceStrategyFactory resourceStrategyFactory)
        {
            return resourceStrategyFactory.GetStrategy<RatingStrategy>().IsValidSpend(this);
        }

        public void Spend(IResourceStrategyFactory resourceStrategyFactory)
        {
            resourceStrategyFactory.GetStrategy<RatingStrategy>().Spend(this);
        }
    }
}