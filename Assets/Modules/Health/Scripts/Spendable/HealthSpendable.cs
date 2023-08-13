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

        public bool IsValid(IValidatorFactory validatorFactory)
        {
            return validatorFactory.IsValidSpend(this);
        }
    }
}