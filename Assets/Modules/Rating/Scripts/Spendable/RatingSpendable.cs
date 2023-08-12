using System;
using Core;
using UnityEngine;

namespace Rating.Spendable
{
    [Serializable]
    public class RatingSpendable : ISpendable
    {
        [SerializeField] private int _amount;

        public bool IfCanSpend => RatingManager.Instance.ValidSpend(_amount);
    }
}