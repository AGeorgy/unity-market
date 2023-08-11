using System;
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
        private BundleSetting _setting;

        public void SetView(VisualElement visualElement)
        {
            _root = visualElement.Q<VisualElement>("Bundle");
            _name = _root.Q<Label>("Name");
            _buyButton = _root.Q<Button>("BuyButton");
        }

        internal void SetData(int index, IBundleSettings bundleSettings)
        {
            _index = index;
            _setting = bundleSettings.Bundles[_index];

            _name.text = _setting.Name;
            _root.style.backgroundColor = _setting.Color;

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