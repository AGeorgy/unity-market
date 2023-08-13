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

        public bool IsValid(IValidator validatorFactory)
        {
            return validatorFactory.IsValidSpend(this);
        }
    }
}