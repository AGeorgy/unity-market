using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class PercentHealthSpendable : ISpendable
    {
        [SerializeField] private int _percent;

        public bool IsValid(IValidatorFactory validatorFactory)
        {
            return validatorFactory.IsValidSpend(this);
        }
    }
}