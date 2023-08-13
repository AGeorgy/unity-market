
using System;
using Core.Loader;
using Shop.Setting;
using Shop.View;
using Shop.Model;

namespace Shop
{
    public class ShopManager
    {
        private const string SETTING_NAME = "ShopSetting";
        private const string VIEW_NAME = "ShopView";

        private ShopManager(IPrefabLoader prefabLoader)
        {
            _prefabLoader = prefabLoader;
            LoadSettings();

        }
        private ShopManager() { }
        private static Lazy<ShopManager> _instance;
        public static ShopManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public static void Initialize(IPrefabLoader prefabLoader)
        {
            _instance = new(() => new ShopManager(prefabLoader));
        }

        private IShopModel _model;
        private readonly IPrefabLoader _prefabLoader;

        public void SowShop()
        {
            _prefabLoader.Load<ShopController>(VIEW_NAME);
        }

        public void NotifyShopViewReady(ShopController shop)
        {
            shop.SetModel(_model);
        }

        private void LoadSettings()
        {
            var setting = _prefabLoader.Load<ShopSetting>(SETTING_NAME);
            _model = new ShopModel(setting);
        }
    }




}
