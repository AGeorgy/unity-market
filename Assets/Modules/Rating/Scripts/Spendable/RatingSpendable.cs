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

        public bool IsValid(IValidator validatorFactory)
        {
            return validatorFactory.IsValidSpend(this);
        }
    }
}