using UnityEngine;

namespace Shop.View
{
    public interface IShopViewBundle
    {
        string Name { get; }
        Color Color { get; }
        bool IsPurchasable { get; }
    }
}