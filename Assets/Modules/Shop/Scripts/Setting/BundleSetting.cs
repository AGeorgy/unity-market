using Core;
using UnityEngine;

namespace Shop.Setting
{
    [System.Serializable]
    public class BundleSetting
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _color;

        [SerializeField] private ISpendable _price;
        [SerializeField] private IReward _reward;

        public string Name => _name;
        public Color Color => _color;
        public ISpendable Price => _price;
        public IReward Reward => _reward;
    }
}
