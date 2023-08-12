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

        public bool IfCanSpend => GoldManager.Instance.ValidSpend(_amount);
    }
}