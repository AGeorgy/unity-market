using System.Collections.Generic;
using Core;
using Shop.Setting;

namespace Shop.Model
{
    public class ShopModel : IShopModel
    {
        private List<BundleModel> _bundles;
        private List<INotifyUpdateModel> _updateObservers;

        public ShopModel(ShopSetting setting)
        {
            _bundles = new List<BundleModel>();
            _updateObservers = new List<INotifyUpdateModel>();
            foreach (var bundleSetting in setting.Bundles)
            {
                _bundles.Add(new BundleModel(bundleSetting));
            }
        }

        List<IViewBundle> IShopModel.AsViewBundle => GetPurchasableBundle();

        public void AddModelUpdateObserver(INotifyUpdateModel observer)
        {
            _updateObservers.Add(observer);
        }

        public bool ValidateBundleAtIndex(int index)
        {
            return _bundles.Count > index && _bundles[index].IsPurchasable == true;
        }

        public void BuyBundleAtIndex(int index)
        {

        }

        private List<IViewBundle> GetPurchasableBundle()
        {
            var result = new List<IViewBundle>();
            foreach (var bundle in _bundles)
            {
                result.Add(bundle);
            }
            return result;
        }

        private void UpdateObservers()
        {
            foreach (var observer in _updateObservers)
            {
                observer.NotifyUpdateModel();
            }
        }
    }
}