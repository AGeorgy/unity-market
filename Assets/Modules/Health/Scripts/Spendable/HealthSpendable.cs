using System;
using Core;
using UnityEngine;

namespace Health.Spendable
{
    [Serializable]
    public class HealthSpendable : ISpendable
    {
        [SerializeField] private int _amount;

        public bool IfCanSpend => HealthManager.Instance.ValidSpend(_amount);
    }
}