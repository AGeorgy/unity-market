using System.Collections.Generic;
using Core;
using Shop.Setting;

namespace Shop.Model
{
    public class ShopModel : IShopModel
    {
        private IValidator _validator;
        private ISpender _spender;
        private IRewarder _rewarder;
        private List<BundleModel> _bundles;
        private List<INotifyUpdateModel> _updateObservers;

        public ShopModel(ShopSetting setting, IValidator validator, ISpender spender, IRewarder rewarder)
        {
            _validator = validator;
            _spender = spender;
            _rewarder = rewarder;
            _bundles = new List<BundleModel>();
            _updateObservers = new List<INotifyUpdateModel>();
            foreach (var bundleSetting in setting.Bundles)
            {
                _bundles.Add(new BundleModel(bundleSetting));
            }
        }

        public List<IViewBundle> AsViewBundle => GetPurchasableBundle();

        public void AddModelUpdateObserver(INotifyUpdateModel observer)
        {
            _updateObservers.Add(observer);
        }

        public bool ValidateBundleAtIndex(int index)
        {
            if (_bundles.Count <= index)
            {
                return false;
            }
            var price = _bundles[index].Price;

            foreach (var spendable in price)
            {
                if (!spendable.IsValid(_validator))
                {
                    return false;
                }
            }
            return true;
        }

        public void BuyBundleAtIndex(int index)
        {
            if (_bundles.Count <= index)
            {
                return;
            }
            var spendables = _bundles[index].Price;
            var rewards = _bundles[index].Reward;

            foreach (var spend in spendables)
            {
                _spender.Spend(spend);
            }
            foreach (var reward in rewards)
            {
                _rewarder.AddReward(reward);
            }
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