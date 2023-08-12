using System;
using System.Collections.Generic;
using Shop.Setting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Shop.View
{
    public class BundleController : IDisposable
    {
        private VisualElement _root;
        private Label _name;
        private Button _buyButton;
        private int _index;
        private IShopViewBundle _bundleModel;

        public void SetView(VisualElement visualElement)
        {
            _root = visualElement.Q<VisualElement>("Bundle");
            _name = _root.Q<Label>("Name");
            _buyButton = _root.Q<Button>("BuyButton");
        }

        internal void SetData(int index, List<IShopViewBundle> bundleModels)
        {
            _index = index;
            _bundleModel = bundleModels[_index];

            _name.text = _bundleModel.Name;
            _root.style.backgroundColor = _bundleModel.Color;

            _buyButton.SetEnabled(_bundleModel.IsPurchasable);
            _buyButton.clickable.clicked += BuyBundle;
        }

        public void Dispose()
        {
            _buyButton.clickable.clicked -= BuyBundle;
        }

        private void BuyBundle()
        {
            Debug.Log($"Buy bundle {_index}");
        }
    }
}