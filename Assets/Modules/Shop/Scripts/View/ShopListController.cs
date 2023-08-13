using System.Collections.Generic;
using Shop.Model;
using UnityEngine.UIElements;

namespace Shop.View
{
    public class ShopListController
    {
        private const string LIST = "List";
        private IBuyBundleNotifier _shopNotifier;
        private IValidateNotifier _validateNotifier;
        private ListView _list;
        private List<IViewBundle> _bundleModels;

        public void Initialize(VisualElement rootVisualElement, VisualTreeAsset entryTemplate, List<IViewBundle> bundleModels,
        IBuyBundleNotifier shopNotifier, IValidateNotifier validateNotifier)
        {
            _shopNotifier = shopNotifier;
            _validateNotifier = validateNotifier;
            _list = rootVisualElement.Q<ListView>(LIST);

            FillList(entryTemplate, bundleModels);
        }

        public void UpdateModel(List<IViewBundle> bundleModels)
        {
            _bundleModels = bundleModels;
            _list.itemsSource = bundleModels;
        }

        private void FillList(VisualTreeAsset entryTemplate, List<IViewBundle> bundleModels)
        {
            UpdateModel(bundleModels);

            _list.makeItem = () =>
            {
                var entryView = entryTemplate.Instantiate();
                var entryController = new BundleController();
                entryView.userData = entryController;
                entryController.SetView(entryView, _shopNotifier, _validateNotifier);
                return entryView;
            };

            _list.bindItem = (item, index) =>
            {
                var bundleController = item.userData as BundleController;
                var bundleModel = _bundleModels[index];
                bundleController.SetData(index, bundleModel);
            };

            _list.fixedItemHeight = 100;
        }
    }
}
