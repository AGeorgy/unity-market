using System.Collections.Generic;
using Shop.Setting;
using UnityEngine;
using Core;

namespace Shop.Model
{
    public class BundleModel : IViewBundle
    {
        private readonly string _name;
        private readonly Color _color;

        private readonly List<ISpendable> _price;
        private readonly List<IReward> _reward;

        public string Name => _name;
        public Color Color => _color;
        public List<ISpendable> Price => _price;

        public BundleModel(BundleSetting setting)
        {
            _name = setting.Name;
            _color = setting.Color;
            _price = setting.Price;
            _reward = setting.Reward;
        }
    }
}