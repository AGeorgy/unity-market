using Shop.Model;
using UnityEngine.UIElements;

namespace Shop.View
{
    public class BundleController
    {
        private const string BUNDLE = "Bundle";
        private const string NAME = "Name";
        private const string BUY_BUTTON = "BuyButton";
        private IValidateNotifier _validateNotifier;
        private IBuyBundleNotifier _shopNotifier;
        private VisualElement _root;
        private Label _name;
        private Button _buyButton;
        private int _index;
        private IViewBundle _model;

        public void SetView(VisualElement visualElement, IBuyBundleNotifier shopNotifier, IValidateNotifier validateNotifier)
        {
            _validateNotifier = validateNotifier;
            _shopNotifier = shopNotifier;
            _root = visualElement.Q<VisualElement>(BUNDLE);
            _name = _root.Q<Label>(NAME);
            _buyButton = _root.Q<Button>(BUY_BUTTON);
        }

        internal void SetData(int index, IViewBundle model)
        {
            _model = model;
            _index = index;

            _name.text = _model.Name;
            _root.style.backgroundColor = _model.Color;

            _buyButton.SetEnabled(_validateNotifier.NotifyValidateAtIndex(_index));
            _buyButton.RegisterCallback<ClickEvent>(Buy);
        }

        private void Buy(ClickEvent evt)
        {
            _shopNotifier.NotifyBuyBundleAtIndex(_index);
        }
    }
}