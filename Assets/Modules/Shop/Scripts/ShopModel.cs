using System.Collections.Generic;
using Shop.Setting;

namespace Shop
{
    public class ShopModel
    {
        public List<IBundleSetting> Bundles { get; private set; } = new List<IBundleSetting>();

        public ShopModel(IBundleSettings setting)
        {
            Bundles = setting.Bundles;
        }
    }
}