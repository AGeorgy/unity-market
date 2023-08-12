using System.Collections.Generic;
using Shop.Setting;
using UnityEngine.UIElements;

namespace Shop.View
{
    public class ShopListController
    {
        private ListView _list;

        public void Initialize(VisualElement rootVisualElement, VisualTreeAsset entryTemplate, List<IShopViewBundle> bundleModels)
        {
            _list = rootVisualElement.Q<ListView>("List");

            FillList(entryTemplate, bundleModels);
        }

        private void FillList(VisualTreeAsset entryTemplate, List<IShopViewBundle> bundleModels)
        {
            _list.makeItem = () =>
            {
                var entryView = entryTemplate.Instantiate();
                var entryController = new BundleController();
                entryView.userData = entryController;
                entryController.SetView(entryView);
                return entryView;
            };

            _list.destroyItem = (item) =>
            {
                (item.userData as BundleController).Dispose();
            };

            _list.bindItem = (item, index) =>
            {
                (item.userData as BundleController).SetData(index, bundleModels);
            };

            _list.fixedItemHeight = 100;
            _list.itemsSource = bundleModels;
        }
    }
}
