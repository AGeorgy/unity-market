using UnityEngine;

namespace Shop.View
{
    public class ShopViewBundleModel : IShopViewBundle
    {
        public string Name => _name;
        public Color Color => _color;
        public bool IsPurchasable => _isPurchasable;

        private readonly string _name;
        private readonly Color _color;
        private readonly bool _isPurchasable;

        public ShopViewBundleModel(string name, Color color, bool isPurchasable)
        {
            _name = name;
            _color = color;
            _isPurchasable = isPurchasable;
        }
    }
}