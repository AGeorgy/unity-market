using UnityEngine;
using UnityEngine.UIElements;
using Shop.Model;
using Core;

namespace Shop.View
{
    public class ShopController : MonoBehaviour, IBuyBundleNotifier, INotifyUpdateModel, IValidateNotifier
    {
        [SerializeField]
        private UIDocument _shopView;
        [SerializeField]
        private VisualTreeAsset _bundleTemplate;
        private IShopModel _model;
        private ShopListController _shopListController;

        void Start()
        {
            _model.AddModelUpdateObserver(this);
            var bundles = _model.AsViewBundle;
            _shopListController = new ShopListController();
            _shopListController.Initialize(_shopView.rootVisualElement, _bundleTemplate, bundles, this, this);
        }

        public void Init(IShopModel model)
        {
            _model = model;
        }

        public void NotifyBuyBundleAtIndex(int index)
        {
            if (_model.ValidateBundleAtIndex(index))
            {
                _model.BuyBundleAtIndex(index);
            }
        }

        public void NotifyUpdateModel()
        {
            // don't need to update model, because it's static
            // _shopListController.UpdateModel(_model.AsPurchasableBundle);
        }

        public bool NotifyValidateAtIndex(int index)
        {
            return _model.ValidateBundleAtIndex(index);
        }
    }
}
