
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop.Setting
{
    public interface IBundleSetting
    {
        public string Name { get; }

        public Color Color { get; }
        public List<ISpendable> Price { get; }

        public List<IReward> Reward { get; }
    };
}
