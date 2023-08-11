using UnityEngine;
using UnityEngine.UIElements;

namespace Shop.View
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _shopView;
        [SerializeField]
        private VisualTreeAsset _bundleTemplate;

        void Start()
        {
            var settings = ShopManager.Instance.ShopSetting;
            var shopListController = new ShopListController();
            shopListController.Initialize(_shopView.rootVisualElement, _bundleTemplate, settings);
        }
    }
}
