
using System;
using Core.Loader;
using Shop.Setting;
using Shop.View;

namespace Shop
{
    public class ShopManager : IShopShower
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

        private ShopModel _model;
        private readonly IPrefabLoader _prefabLoader;

        public void SowShop()
        {
            _prefabLoader.Load<ShopView>(VIEW_NAME);
        }

        public void NotifyShopViewReady(ShopView view)
        {
            view.SetModel(new ShopViewModel(_model));
        }

        private void LoadSettings()
        {
            var setting = _prefabLoader.Load<ShopSetting>(SETTING_NAME);
            _model = new ShopModel(setting);
        }
    }




}
