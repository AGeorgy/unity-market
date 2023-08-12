using System.Collections.Generic;
using Core;

namespace Shop.View
{
    public class ShopViewModel
    {
        public List<IShopViewBundle> Bundles { get; private set; } = new List<IShopViewBundle>();

        public ShopViewModel(ShopModel model)
        {
            foreach (var bundle in model.Bundles)
            {
                var isPurchasable = IsPurchasable(bundle.Price);
                Bundles.Add(new ShopViewBundleModel(bundle.Name, bundle.Color, isPurchasable));
            }

        }

        private bool IsPurchasable(List<ISpendable> price)
        {
            foreach (var spendable in price)
            {
                if (!spendable.IfCanSpend)
                {
                    return false;
                }
            }
            return true;
        }
    }
}