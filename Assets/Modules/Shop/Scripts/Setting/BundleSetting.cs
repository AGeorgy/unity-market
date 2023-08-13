using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop.Setting
{
    [Serializable]
    public class BundleSetting
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;

        [SerializeReference, SelectImplementation(typeof(ISpendable))]
        private List<ISpendable> _price;
        [SerializeReference, SelectImplementation(typeof(IReward))]
        private List<IReward> _reward;

        public string Name => _name;
        public Color Color => _color;
        public List<ISpendable> Price => _price;
        public List<IReward> Reward => _reward;
    }
}
