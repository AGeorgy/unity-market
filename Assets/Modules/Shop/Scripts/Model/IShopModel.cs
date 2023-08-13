using System.Collections.Generic;
using Core;

namespace Shop.Model
{
    public interface IShopModel
    {
        List<IViewBundle> AsViewBundle { get; }

        void AddModelUpdateObserver(INotifyUpdateModel observer);
        void BuyBundleAtIndex(int index);
        bool ValidateBundleAtIndex(int index);
    }
}
